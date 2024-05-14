using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeed = 5.0f;
    [SerializeField]
    private float _runSpeed = 10.0f;
    [SerializeField]
    private float _jumpPower = 10.0f;

    private float _moveSpeed;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _body2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _body2D.AddForce(Vector2.up * _jumpPower);
            _animator.SetBool("IsAir", true);
        }

        _animator.SetFloat("Velocity", _body2D.velocity.y);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = _runSpeed;
        }
        else
        {
            _moveSpeed = _walkSpeed;
        }

        transform.Translate(Vector2.right * horizontal * _moveSpeed * Time.deltaTime);

        _animator.SetFloat("Speed", Mathf.Abs(horizontal) * _moveSpeed);

        if (horizontal < 0.0f)
            _spriteRenderer.flipX = true;
        else if (horizontal > 0.0f)
            _spriteRenderer.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Tile")
        {
            _animator.SetBool("IsAir", false);
        }
    }

    /*
    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    */
}
