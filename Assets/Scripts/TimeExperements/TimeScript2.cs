using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class TimeScript2 : MonoBehaviour
{
    public TextMeshProUGUI procText2;
    public Slider prog2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ������, ������, �����.
        DateTime dt_start2 = new DateTime(2023, 8, 13);
        DateTime dt_now2 = DateTime.Now;
        DateTime dt_end2 = new DateTime(2023, 10, 22);

        //������� �����
        TimeSpan waitSpan2 = dt_end2 - dt_start2;
        //int waitElaps = (int)Math.Round(waitSpan.TotalSeconds, 0, MidpointRounding.ToEven);

        //������� ������
        TimeSpan lastSpan2 = dt_now2 - dt_start2;
        //int lastElaps = (int)Math.Round(lastSpan.TotalSeconds, 0, MidpointRounding.ToEven);

        //���������� ���������
        //decimal proc = (lastElaps * 100m) / waitElaps;
        //proc = Math.Round(proc, 5);

        //����� ������
        //procText1.text = $"{proc}%";

        double proc2 = (lastSpan2.TotalMilliseconds * 100) / waitSpan2.TotalMilliseconds;
        proc2 = Math.Round(proc2, 5);
        procText2.text = $"{proc2}%";
        prog2.value = (float)proc2;
    }
}
