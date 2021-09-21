using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private Material dayNightSkybox;
    private Color[] dayColors = new Color[2];
    private Color[] nightColors = new Color[2];
    private string day1 = "#f2b63d";
    private string day2 = "#d46e33";
    private string night1 = "#2f2b5c";
    private string night2 = "#449489";

    public float duration = 60; // duration in seconds
    private float t = 0; // lerp control variable

    private bool isDay;

    // Start is called before the first frame update
    void Awake()
    {
        dayNightSkybox = RenderSettings.skybox;
        isDay = true;

        Color newCol1;
        Color newCol2;
        if (ColorUtility.TryParseHtmlString(day1, out newCol1) && ColorUtility.TryParseHtmlString(day2, out newCol2))
        {
            dayColors[0] = newCol1;
            dayColors[1] = newCol2;
        }
        if (ColorUtility.TryParseHtmlString(night1, out newCol1) && ColorUtility.TryParseHtmlString(night2, out newCol2))
        {
            nightColors[0] = newCol1;
            nightColors[1] = newCol2;
        }
    }

    void Start() 
    {
        dayNightSkybox.SetColor("_Top", dayColors[0]);
        dayNightSkybox.SetColor("_Bottom", nightColors[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDay) {
            t += Time.deltaTime;
            if (t >= duration) isDay = false;
            dayNightSkybox.SetColor("_Top", Color.Lerp(dayColors[0], nightColors[0], t/duration));
            dayNightSkybox.SetColor("_Bottom", Color.Lerp(dayColors[1], nightColors[1], t/duration));
        } 
        else 
        {
            t -= Time.deltaTime;
            dayNightSkybox.SetColor("_Top", Color.Lerp(nightColors[0], dayColors[0], (duration - t)/duration));
            dayNightSkybox.SetColor("_Bottom", Color.Lerp(nightColors[1], dayColors[1], (duration - t)/duration));
        }

        Debug.Log(t);
        DynamicGI.UpdateEnvironment();
    }
}
