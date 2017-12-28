using System;
using System.Collections.Generic;
using UnityEngine;

namespace SplineCurve
{

    public class BSpline
    {
        //根据t值和三个顶点获取二阶B样条曲线的点
        public static Vector3 GetBStylePoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            Vector3 point = Vector3.zero;
            float f0 = (t - 1) * (t - 1) / 2;
            float f1 = (-2 * t * t + 2 * t + 1) / 2;
            float f2 = t * t / 2;
            point = (f0 * p0 + f1 * p1 + f2 * p2);
            return point;
        }
        //根据t值和四个顶点获取四阶B样条曲线的点
        public static Vector3 GetBStylePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, double t)
        {
            Vector3 point = Vector3.zero;
            double f0 = (t * t * t * (-1) + 3 * t * t - 3 * t + 1) / 6;
            double f1 = (3 * t * t * t - 6 * t * t + 4) / 6;
            double f2 = (3 * t * t * t * (-1) + 3 * t * t + 3 * t + 1) / 6;
            double f3 = t * t * t / 6;
            point.x = (int)(f0 * p0.x + f1 * p1.x + f2 * p2.x + f3 * p3.x);
            point.y = (int)(f0 * p0.y + f1 * p1.y + f2 * p2.y + f3 * p3.y);
            return point;
        }
        public static Vector3 CalculateBSplinePoint(float t, params Vector3[] points)
        {
            Vector3 point = Vector3.zero;
            var n = points.Length - 1;
            for (int i = 0; i <= n; i++)
            {
                point += points[i] * BaseFunction(i, n, t);
            }
            return point;
        }

        /// <summary>
        /// 基函数
        /// </summary>
        /// <param name="i">第i个</param>
        /// <param name="n">控制点数目</param>
        /// <param name="t">(0-1)</param>
        /// <returns></returns>
        private static float BaseFunction(int i, int n, float t)
        {
            float value = 0;
            for (int j = 0; j <= n - i; j++)
            {
                value += Mathf.Pow(-1, j) * ArrangeUtility.Combination(n + 1, j) * Mathf.Pow(t + n - i - j, n);
            }
            return value / ArrangeUtility.Arranged(n);
        }
    }
}