using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SplineCurve
{

    public class Hermite
    {
        private float d1;
        private float d2;

        public Hermite(float d1, float d2)
        {
            this.d1 = d1;
            this.d2 = d2;
        }

        public float GetLine(float p1, float p2, float t)
        {
            return
                p1 * MuitCalc(new float[] { 2, -3, 1 }, new float[] { 3, 2, 0 }, t) +
                p2 * MuitCalc(new float[] { -2, 3 }, new float[] { 3, 2 }, t) +
                d1 * MuitCalc(new float[] { 1, -2, 1 }, new float[] { 3, 2, 1 }, t) +
                d2 * MuitCalc(new float[] { 1, -1 }, new float[] { 3, 2 }, t);

        }
        private float MuitCalc(float[] arg, float[] pow, float value)
        {
            Debug.Assert(pow.Length == arg.Length);
            var result = 0f;
            for (int i = 0; i < arg.Length; i++)
            {
                result += arg[i] * Mathf.Pow(value, pow[i]);
            }
            return result;
        }
    }
}