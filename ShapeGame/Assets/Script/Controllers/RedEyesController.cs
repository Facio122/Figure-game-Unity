using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEyesController : MonoBehaviour
{
    private Vector2 _originalScale;
    void Start()
    {
        _originalScale = gameObject.transform.localScale;
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        yield return new WaitForSecondsRealtime(Random.Range(2f, 8f));
        gameObject.transform.localScale = Vector2.zero;
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.5f));
        gameObject.transform.localScale = _originalScale;
        StartCoroutine(blink());
    }
}
