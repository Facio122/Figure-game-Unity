using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private Light2D _light;

    private void Start()
    {
        _funWaitRandomTime();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalVariables.isPlayerAlive = false;
        }
    }

    private void  _funWaitRandomTime()
    {
        LeanTween.delayedCall(Random.Range(5f, 10f), _funBlinkLightOn);
    }

    private void _funBlinkLightOn()
    {
        LeanTween.value(_light.intensity, 1.5f, 0.2f).setOnUpdate((value) =>
        {
            _light.intensity = (float)value;
        }).setOnComplete(_funBlinkLightOff);
    }

    private void _funBlinkLightOff()
    {
        LeanTween.value(_light.intensity, 0f, 0.2f).setOnUpdate((value) =>
        {
            _light.intensity = (float)value;
        }).setOnComplete(_funWaitRandomTime);
    }


}
