using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLigthChangeColour : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] lightColors;

    int colorIndex = 0;

    float t = 0f;

    int len;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeLightsColour();
        len = lightColors.Length;
    }

    public void changeLightsColour()
    {
        Object[] lights = FindObjectsOfType(typeof(Light));

        foreach (Light obj in lights)
        {
            if (obj.type == LightType.Point)
            {
                //obj.color = new Color(Random.value, Random.value, Random.value, 1.0f);
                obj.color = Color.Lerp(obj.color, lightColors[colorIndex], lerpTime * Time.deltaTime);

                t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
                if (t > .9f)
                {
                    t = 0f;
                    colorIndex++;

                    // reset colorIndex when it is >= length
                    colorIndex = (colorIndex >= len) ? 0 : colorIndex;
                }
            }
        }
    }
}
