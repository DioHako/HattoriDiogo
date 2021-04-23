using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;

    private Rigidbody2D _rigidbody2D;

    private float _moveInput;
    private bool _facingRight = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Movements();
    }

    private void Movements()
    {
        _rigidbody2D.velocity = new Vector2(_moveInput * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        if (!_facingRight && _moveInput > 0)
        {
            Flip();
        }
        else if (_facingRight && _moveInput < 0)
        {
            Flip();
        }
    }

    private void MoveInput()
    {
        _moveInput = Input.GetAxisRaw("Horizontal") * _walkSpeed;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
