using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    private List<Vector2> _vec2posCamera = new List<Vector2>();

    void Start()
    {
        _funSetCameraPositions();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalVariables.IndexCameraPosition = int.Parse(gameObject.name);
            _funChangeCameraPosition();
        }
    }
    private void _funChangeCameraPosition()
    {
        LeanTween.move(_camera, _vec2posCamera[GlobalVariables.IndexCameraPosition], 2f).setEaseInOutSine();
    }
    private void _funSetCameraPositions()
    {
        _vec2posCamera.Add(new Vector2(0, 0));
        _vec2posCamera.Add(new Vector2(19, 0));
        _vec2posCamera.Add(new Vector2(19, 10f));
        _vec2posCamera.Add(new Vector2(19, 23f));
        _vec2posCamera.Add(new Vector2(5, 22f));
    }
}
