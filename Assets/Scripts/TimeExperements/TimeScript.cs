using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI procText1;
    public Slider prog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //даты начало, сейчас, конец.
        DateTime dt_start = new DateTime(2023, 8, 13);
        DateTime dt_now = DateTime.Now;
        DateTime dt_end = new DateTime(2023, 10, 1);

        //секунды всего
        TimeSpan waitSpan = dt_end - dt_start;
        //int waitElaps = (int)Math.Round(waitSpan.TotalSeconds, 0, MidpointRounding.ToEven);

        //секунды прошло
        TimeSpan lastSpan = dt_now - dt_start;
        //int lastElaps = (int)Math.Round(lastSpan.TotalSeconds, 0, MidpointRounding.ToEven);

        //вычисление процентов
        //decimal proc = (lastElaps * 100m) / waitElaps;
        //proc = Math.Round(proc, 5);

        //вывод текста
        //procText1.text = $"{proc}%";

        double proc = (lastSpan.TotalMilliseconds * 100) / waitSpan.TotalMilliseconds;
        proc = Math.Round(proc, 5);
        procText1.text = $"{proc}%";
        prog.value = (float)proc;
    }
}
