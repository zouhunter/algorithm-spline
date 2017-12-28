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

/// <summary>
/// 排列组合公式
/// </summary>
public static class ArrangeUtility
{
    /// <summary>
    /// 排列循环方法
    /// </summary>
    /// <param name="N"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    public static long Arranged(int N, int R = 1)
    {
        if (R == 0) return 1;
        if (R > N || R <= 0 || N <= 0) Debug.LogError("N:" + N + "\nR:" + R);
        long t = 1;
        int i = N;
        while (i != N - R)
        {
            try
            {
                checked
                {
                    t *= i;
                }
            }
            catch
            {
                Debug.LogError("overflow happens!");
            }
            --i;
        }
        return t;
    }
    /// <summary>
    /// 组合
    /// </summary>
    /// <param name="N"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    public static long Combination(int N, int R)
    {
        return Arranged(N, R) / Arranged(R, R);
    }
}
