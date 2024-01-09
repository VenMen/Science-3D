using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDistributor : MonoBehaviour
{
    [SerializeField] private Color intervalColor = new();
    [SerializeField] private Color _finalColor = new();
    [SerializeField] private Color _startColor = new();
    [SerializeField] private Color[] _intervalColors = new Color[3];
    public void GenerateFinalColor()
    {
        _finalColor = GenerateRandomColor();
    }

    public void GenerateStartColor()
    {
        int randomIntervalColor = Random.Range(0, _intervalColors.Length);
        float Blend = 0.5f;
        intervalColor = _intervalColors[randomIntervalColor];
        //float RedColor = _finalColor.r + (_intervalColor.r - _finalColor.r) * Blend;
        //float GreenColor = _finalColor.g + (_intervalColor.g - _finalColor.g) * Blend;
        //float BlueColor = _finalColor.b + (_intervalColor.b - _finalColor.b) * Blend;
        float RedColor = (_finalColor.r / Blend) - intervalColor.r;
        float GreenColor = (_finalColor.g / Blend) - intervalColor.g;
        float BlueColor = (_finalColor.b / Blend) - intervalColor.b;
        _startColor = new Color(RedColor, GreenColor, BlueColor, 1f);
    }
    public void GenerateIntervalColor(int count)
    {
        _intervalColors[count] = GenerateRandomColor();
    }

    private Color GenerateRandomColor()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);
        intervalColor = new Color(r, g, b, 1);
        return intervalColor;
    }

    private void Start()
    {
        GenerateFinalColor();
        for (int i = 0; i < _intervalColors.Length; i++)
        {
            GenerateIntervalColor(i);
        }
        GenerateStartColor();
    }
}
