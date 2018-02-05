using UnityEngine;
using System;

public static class OvalUtil {
    /// <summary>
    /// 按坐标获取角度（0~2pi）
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="span"></param>
    /// <returns></returns>
    public static float GetRadian(Vector2 pos,float span)
    {
       var b = Calcute_B(pos.x, pos.y, span);
        var a = Calcute_A(b, span);
        var radian = Mathf.Acos(pos.x / a);
        if (pos.y < 0){
            radian  = - radian + Mathf.PI * 2;
        }
       return radian;
    }
    /// <summary>
    /// 按t（0~2pi）生成坐标
    /// </summary>
    /// <param name="b"></param>
    /// <param name="span"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vector2 GetPosition(float b, float span, float t)
    {
        var x = Calcute_A(b, span) * Mathf.Cos(t);
        var y = b * Mathf.Sin(t);
        return new Vector2(x, y);
    }

    private static float Calcute_A(float b, float span)
    {
        return Mathf.Sqrt(b * b + span * span);
    }
    private static float Calcute_B(float x, float y, float span)
    {
        var arg0 = (x * x + y * y - span * span);
        var arg1 = Mathf.Sqrt(arg0 * arg0 + 4 * y * y * span * span);
        var b = Mathf.Sqrt((arg0 + arg1) / 2);
        return b;
    }
}
