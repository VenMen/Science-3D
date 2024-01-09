using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class TimeScriptNow : MonoBehaviour
{
    public TextMeshProUGUI procTextNow1;
    public Slider progNow;
    DateTime dt_startNow;
    // Start is called before the first frame update
    void Start()
    {
        dt_startNow = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt_nowNow = DateTime.Now;
        DateTime dt_endNow = new DateTime(2023, 10, 1);

        TimeSpan waitSpanNow = dt_endNow - dt_startNow;

        TimeSpan lastSpanNow = dt_nowNow - dt_startNow;

        double procNow = (lastSpanNow.TotalMilliseconds * 100) / waitSpanNow.TotalMilliseconds;
        procNow = Math.Round(procNow, 5);
        procTextNow1.text = $"{procNow}%";
        progNow.value = (float)procNow;
    }
}
