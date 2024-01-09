using UnityEngine;

public class NameChanger : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    private void Start()
    {
        float r = Random.Range(0, 1);
        float g = Random.Range(0, 1);
        float b = Random.Range(0, 1);
        endColor = new Color(r, g, b, 1);

        r = Random.Range(0, 1);
        g = Random.Range(0, 1);
        b = Random.Range(0, 1);
        startColor = new Color(r, g, b, 1);

        while (startColor.r > endColor.r - 0.2f & startColor.r < endColor.r + 0.2f)
        {
            r = Random.Range(0, 1);
            g = Random.Range(0, 1);
            b = Random.Range(0, 1);
            startColor = new Color(r, g, b, 1);
        }
    }
}
