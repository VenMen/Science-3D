using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderCounte: MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public TextMeshProUGUI CounterX;
    public TextMeshProUGUI CounterY;
    public int counrX;
    public int counrY;
    public int xForMaze;
    public int yForMaze;

    // Start is called before the first frame update
    void Start()
    {
        CounterX.text = counrX.ToString("0");
        CounterY.text = counrY.ToString("0");
        slider1.onValueChanged.AddListener((v) => { CounterX.text = v.ToString("0"); });
        slider2.onValueChanged.AddListener((v) => { CounterY.text = v.ToString("0"); });
    }

    // Update is called once per frame
    void Update()
    {
        xForMaze = (int) (slider2.value);
        yForMaze = (int) (slider1.value);
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("XMaze", xForMaze);
        PlayerPrefs.SetInt("YMaze", yForMaze);
        PlayerPrefs.Save();
    }
}
