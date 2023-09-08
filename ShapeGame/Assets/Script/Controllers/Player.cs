using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedHorizontal;
    [SerializeField] private float _speedVertical;
    [SerializeField] private float _groudCheckRadius;
    [SerializeField] GameObject _objectPlayerFoot;
    [SerializeField] private float _timeJumping;

    private Rigidbody2D _rbPlayer;
    private float _movementHorizontal = 0f;
    private float _timerJumping = 0;
    private bool _isJumping = true;
    private bool _isStartWalking = false;
    private bool jumpForScaling = false;

    void Start()
    {
        _rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        _rbPlayer.gravityScale = GlobalVariables.GravityScale;
    }
    void Update()
    {
        _movementHorizontal = Input.GetAxis("Horizontal");
        _funPlayerMovement();
        _funPlayerJumping();
    }

    private void _funPlayerMovement()
    {
        _rbPlayer.velocity = new Vector2(_movementHorizontal * _speedHorizontal, _rbPlayer.velocity.y);
        if (_movementHorizontal != 0f && !_isStartWalking && _isGrounded())
        {
            _isStartWalking = true;
            LeanTween.scale(gameObject, new Vector2(0.65f, 1f), 0.3f).setOnComplete(_funScaleOriginal);
        }
    }
    private void _funScaleOriginal()
    {
        LeanTween.scale(gameObject, new Vector2(0.58f, 1.1677f), 0.3f).setOnComplete(_funPlayerJumping).setOnComplete(_funSetWalkingFalse);
    }
    private void _funSetWalkingFalse()
    {
        _isStartWalking = false;
    }
    private void _funPlayerJumping()
    {
        bool pressedSpace = Input.GetKeyDown(KeyCode.Space);

        if (_isGrounded() && pressedSpace)
        {
            _isJumping = true;
            _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _speedVertical);
            _timerJumping = _timeJumping;
            GlobalVariables.isJump = true;
        }
        else GlobalVariables.isJump = false;
        if (Input.GetKey(KeyCode.Space) && _isJumping)
        {
            if (_timerJumping > 0)
            {
                _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, _speedVertical);
                _timerJumping -= Time.deltaTime;
            }
            else _isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            _isJumping = false;
        if (GlobalVariables.isJump)
        {
            LeanTween.scale(gameObject, new Vector2(0.5f, 1.3f), 0.3f).setOnComplete(_funJumpForScalingSetTrue);
        }
        if (_isGrounded() && jumpForScaling)
        {
            LeanTween.scale(gameObject, new Vector2(0.58f, 1.1677f), 0.3f);
            jumpForScaling = false;
        }

    }
    private void _funJumpForScalingSetTrue()
    {
        jumpForScaling = true;
    }
    private bool _isGrounded()
    {
        LayerMask layerGround = LayerMask.GetMask("Ground");
        LayerMask layerMovableObject = LayerMask.GetMask("MovableObject");
        bool Ground = Physics2D.OverlapBox(_objectPlayerFoot.transform.position, new Vector2(1, 0), _groudCheckRadius, layerGround);
        bool MovableObject = Physics2D.OverlapBox(_objectPlayerFoot.transform.position, new Vector2(1, 0), _groudCheckRadius, layerMovableObject);
        if (Ground || MovableObject)
            return true;
        else
            return false;
    }

}
