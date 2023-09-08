using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    private SpriteRenderer _spriteObject;

    void Start()
    {
        LeanTween.delayedCall(Random.Range(0.1f, 0.9f), _funFlyingObject);
        _spriteObject = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GlobalVariables.isCoinPick = true;
            LeanTween.moveLocalY(gameObject, gameObject.transform.position.y - 0.2f, 1.5f).setOnStart(_funDisappearObject);
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        }
    }
    private void _funFlyingObject()
    {
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 0.125f, 1.6f).setEaseInOutSine().setLoopPingPong();
    }
    private void _funDisappearObject()
    {
        LeanTween.value(1, 0, 1).setOnUpdate((float value) =>
        {
            _spriteObject.color = new Color(255f / 255f, 218f / 255f, 219f / 255f, value);
        }).setOnComplete(_funDestroyObject);
    }

    private void _funDestroyObject()
    {
            Destroy(gameObject);
    }
}
