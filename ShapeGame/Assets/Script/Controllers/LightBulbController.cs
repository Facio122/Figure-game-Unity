using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBulbController : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _intensity;
    [SerializeField] private float _radius;
  
    void Start()
    {
        _funChangeGlowing();
    }
    private void _funChangeGlowing()
    {
        LeanTween.value(1, Random.Range(1f, 1.06f), Random.Range(0.1f, 0.4f)).setLoopPingPong().setOnUpdate((value) =>
        {
        _light.intensity = value * 1f;
        _light.pointLightOuterRadius = value * 10f;
        });

    }

    
        
}
