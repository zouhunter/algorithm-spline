using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineCurve;
[ExecuteInEditMode]
public class HermiteTest : MonoBehaviour {
    // Use this for initialization
    public int count = 10;
    public LineRenderer lineRender;
    public Transform p1;
    public Transform p2;

    private Hermite xH;
    private Hermite yH;
    private Hermite zH;

    private Vector3 posTemp;
    void Start () {
        xH = new Hermite(1, 1);
        yH = new Hermite(1, 1);
        zH = new Hermite(1, 1);
        lineRender.positionCount = count;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < count; i++)
        {
            posTemp.x = xH.GetLine(p1.position.x, p2.position.x, i / (count - 1f));
            posTemp.y = yH.GetLine(p1.position.y, p2.position.y, i / (count - 1f));
            posTemp.z = zH.GetLine(p1.position.z, p2.position.z, i / (count - 1f));
            lineRender.SetPosition(i, posTemp);
        }

    }
}
