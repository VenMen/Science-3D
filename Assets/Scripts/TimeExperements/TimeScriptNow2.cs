using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class TimeScriptNow2 : MonoBehaviour
{
    public TextMeshProUGUI procTextNow2;
    public Slider progNow2;
    public Slider progNow3;
    public Slider progNow4;
    public Slider progNow5;
    DateTime dt_startNow2;
    // Start is called before the first frame update
    void Start()
    {
        dt_startNow2 = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt_nowNow2 = DateTime.Now;
        DateTime dt_endNow2 = new DateTime(2023, 11, 1);

        TimeSpan waitSpanNow2 = dt_endNow2 - dt_startNow2;

        TimeSpan lastSpanNow2 = dt_nowNow2 - dt_startNow2;

        double procNow2 = (lastSpanNow2.TotalMilliseconds * 100) / waitSpanNow2.TotalMilliseconds;
        procNow2 = Math.Round(procNow2, 5);
        procTextNow2.text = $"{procNow2}%";
        progNow2.value = (float)procNow2;
        progNow3.value = (float)procNow2;
        progNow4.value = (float)procNow2;
        progNow5.value = (float)procNow2;

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
