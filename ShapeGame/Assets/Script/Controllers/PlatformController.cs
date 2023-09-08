using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _xStart;
    [SerializeField] private float _yStart;
    [SerializeField] private bool _isVertical = true;
    [SerializeField] private float _timeMoving = 1f;
    [SerializeField] private float _xEnd;
    [SerializeField] private float _yEnd;

    private bool _isMoving = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isMoving)
        {
            _funPlatformWait1();
            _isMoving = true;
        }
    }
    private void _funPlatformWait1()
    {
        LeanTween.delayedCall(1.5f, _funStartMovingUp);
    }
    private void _funPlatformWait2()
    {
        LeanTween.delayedCall(4f, _funStartMovingDown);
    }
    private void _funStartMovingUp()
    {
        if (_isVertical)
            LeanTween.moveLocalY(gameObject, _yEnd, _timeMoving).setOnComplete(_funPlatformWait2);
        else
            LeanTween.moveLocalX(gameObject, _xEnd, _timeMoving).setOnComplete(_funPlatformWait2);
    }
    private void _funStartMovingDown()
    {
        if (_isVertical)
            LeanTween.moveLocalY(gameObject, _yStart, _timeMoving).setOnComplete(_funEndMoving);
        else
            LeanTween.moveLocalX(gameObject, _xStart, _timeMoving).setOnComplete(_funEndMoving);
    }
    private void _funEndMoving()
    {
        _isMoving = false;
    }
}
