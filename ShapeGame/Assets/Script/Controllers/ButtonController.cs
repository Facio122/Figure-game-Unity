using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool _isClicked = false;
    [SerializeField] private GameObject _deadArea;
    [SerializeField] private GameObject _lamp1;
    [SerializeField] private GameObject _lamp2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            _isClicked = !_isClicked;
            _funClick();
        }      
    }
    private void _funClick()
    {
        if (_isClicked)
        {
            _deadArea.SetActive(false);
            _lamp1.SetActive(true);
            _lamp2.SetActive(true);
        }
        else
        {
            _deadArea.SetActive(true);
            _lamp1.SetActive(false);
            _lamp2.SetActive(false);
        }
    }
}
