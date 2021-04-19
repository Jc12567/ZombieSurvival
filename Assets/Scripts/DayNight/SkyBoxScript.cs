using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScript : MonoBehaviour
{
    public Material skyDay;
    public Material skyNight;
    void Start()
    {
        RenderSettings.skybox = skyDay;
        StartCoroutine(SwapToNight());

    }

    IEnumerator SwapToNight()
    {
        yield return new WaitForSecondsRealtime(300);

        RenderSettings.skybox = skyNight;
        StartCoroutine(SwapToDay());
        
    }

    IEnumerator SwapToDay()
    {
        yield return new WaitForSecondsRealtime(300);

        RenderSettings.skybox = skyDay;
        StartCoroutine(SwapToNight());

    }
}
