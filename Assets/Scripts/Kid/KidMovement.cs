using System;
using UnityEngine;

public class KidMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _rollSpeed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private KidAbility _kidAbility;

    private float _moveInput;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _kidAbility = GetComponent<KidAbility>();
    }

    private void OnEnable()
    {
        _kidAbility.OnRolling += Roll;
    }
    private void OnDisable()
    {
        _kidAbility.OnRolling -= Roll;
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
        _rigidbody2D.velocity = new Vector2(_moveInput * _walkSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        // Walk ANIMATION
        _animator.SetFloat("isRunning", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        
        if (_spriteRenderer.flipX && _moveInput > 0 || !_spriteRenderer.flipX && _moveInput < 0)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }

    private void MoveInput()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    // Tried to implement a roll/dash mechanic through Event Action
    // The Event Action is working, but the Roll itself not
    private void Roll()
    {
        Debug.Log("The KID is ROLLING!!!");
        _rigidbody2D.AddForce(new Vector2(_moveInput * _rollSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y), ForceMode2D.Impulse);
    }
}
