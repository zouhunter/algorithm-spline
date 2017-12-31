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
using SplineCurve;
using System;

public class BSplineTest : MonoBehaviour
{
    public int pointCount;
    private Vector3[] points;
    [SerializeField]
    private LineRenderer lineRender;

    //private BSpline bSpline;
    private void Awake()
    {
        //bSpline = new SplineCurve.BSpline();
        lineRender.SetVertexCount(pointCount);
    }
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (transform.childCount > 0)
            {
                if (points == null || points.Length != transform.childCount)
                {
                    points = new Vector3[transform.childCount];
                }
                for (int i = 0; i < transform.childCount; i++)
                {
                    points[i] = transform.GetChild(i).transform.position;
                }

                for (int i = 0; i < pointCount; i++)
                {
                    var t = (i + 0f) / (pointCount - 1);
                    Vector3 point = BSpline.GetBStylePoint(points[0],points[1],points[2],t);
                    lineRender.SetPosition(i,point);
                }
            }
        }

    }
}
