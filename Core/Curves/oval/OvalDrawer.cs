using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Sprites;
using UnityEngine.Scripting;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using UnityEngine.Assertions.Comparers;
using System.Collections;
using System.Collections.Generic;

public class OvalDrawer : MonoBehaviour
{
    //[SerializeField]
    //private NetDataObj netDataObj;
    [SerializeField, Header("长半轴与短半轴关系")]
    private float span = 5;
    [SerializeField, Header("椭圆最大半短半轴")]
    private float roundMax = 20;
    [SerializeField,Header("椭圆数")]
    private int roundCount = 20;
    [SerializeField, Header("椭圆顶点数")]
    private int roundvetix = 300;
    private const int lineCount = 9;//"曲线数"
    [SerializeField]
    private bool show;
    [SerializeField]
    private Material lineMaterial;
    //[SerializeField]
    //private bool renderData;
    private int linevetix { get { return roundCount * 2; } }

    private List<Vector3[]> rounds = new List<Vector3[]>();
    private List<Vector3[]> lines = new List<Vector3[]>();
    private float[] retios = new float[lineCount];
    private List<LineRenderer> rounds_render = new List<LineRenderer>();
    private List<LineRenderer> lines_render = new List<LineRenderer>();
    private void Awake()
    {
        InitPoints();
        InitLineRender();
    }

    private void Update()
    {
        UpdatePoints();
        if (show) UpdateLineRenders();
    }
//    private void OnDisable()
//    {
//#if UNITY_EDITOR
//        UnityEditor.EditorUtility.SetDirty(netDataObj);
//#endif
//    }
    /// <summary>
    /// 更新点信息
    /// </summary>
    private void UpdatePoints()
    {
        var roundspan = roundMax / roundCount;
        var angleSpan = 2 * Mathf.PI / (roundvetix - 1);
        for (int i = 0; i < roundCount; i++)
        {
            var b = roundspan * (i + 1);
            for (int j = 0; j < roundvetix; j++)
            {
                var angle = angleSpan * j;
                rounds[i][j] = OvalUtil.GetPosition(b, span,angle);
            }

            for (int j = 0; j < retios.Length; j++)
            {
                var upindex = FindClosestPoint(roundvetix, retios[j]);
                /*var up =*/ lines[j][roundCount + i] = rounds[i][upindex];//曲线上面的点
                lines[j][roundCount - i - 1] = rounds[i][roundvetix - upindex - 1];//曲线下面的点

                //if (renderData) netDataObj.TryInsetData(up, retios[j]);
            }
        }


    }
    /// <summary>
    /// 找到最近的点
    /// </summary>
    private int FindClosestPoint(int pointCount, float ratio)
    {
        return Mathf.RoundToInt((pointCount - 1) * 0.5f * ratio);
    }

    /// <summary>
    /// 更新曲线显示 
    /// </summary>
    private void UpdateLineRenders()
    {
        for (int i = 0; i < roundCount; i++)
        {
            rounds_render[i].SetVertexCount(roundvetix);
            rounds_render[i].SetPositions(rounds[i]);
        }

        for (int i = 0; i < lineCount; i++)
        {
            lines_render[i].SetVertexCount(linevetix);
            lines_render[i].SetPositions(lines[i]);
        }
    }

    /// <summary>
    /// 初始化显示线
    /// </summary>
    private void InitLineRender()
    {
        var roundParent = new GameObject("rounds");
        roundParent.transform.SetParent(transform);
        var lineParent = new GameObject("lines");
        lineParent.transform.SetParent(transform);
        for (int i = 0; i < roundCount; i++)
        {
            var lineRender = CreateLineRenderer("round_" + (i + 1), lineMaterial, Color.green);
            lineRender.transform.SetParent(roundParent.transform);
            rounds_render.Add(lineRender);
        }
        for (int i = 0; i < lineCount; i++)
        {
            var lineRender = CreateLineRenderer("line_" + (i + 1), lineMaterial, Color.red);
            lineRender.transform.SetParent(lineParent.transform);
            lines_render.Add(lineRender);
        }
    }


    /// <summary>
    /// 初始化点信息
    /// </summary>
    private void InitPoints()
    {
        for (int i = 0; i < lineCount; i++)
        {
            retios[i] = (i + 1f) / (lineCount + 1f);
        }
        for (int i = 0; i < roundCount; i++)
        {
            rounds.Add(new Vector3[roundvetix]);
        }
        for (int i = 0; i < lineCount; i++)
        {
            lines.Add(new Vector3[linevetix]);
        }
    }

    /// <summary>
    /// lineRender的创建
    /// </summary>
    /// <param name="name"></param>
    /// <param name="count"></param>
    /// <param name="lineMaterial"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public static LineRenderer CreateLineRenderer(string name, Material lineMaterial, Color color)
    {
        var lineRenderObj = new GameObject(name, typeof(LineRenderer));
        var lineRender = lineRenderObj.GetComponent<LineRenderer>();
        lineRender.material = lineMaterial;
        lineRender.SetColors(color, color);
        lineRender.SetVertexCount(0);
        lineRender.SetWidth(0.2f, 0.2f);
        return lineRender;
    }
}
