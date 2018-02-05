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

public class PrintV : MonoBehaviour {
    public float v = 10;
    public float span = 5;
    private void Update()
    {
        print(OvalUtil.GetRadian(transform.position, span));
    }
}
