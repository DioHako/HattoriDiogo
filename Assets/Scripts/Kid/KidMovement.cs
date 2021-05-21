using UnityEngine;

public class KidMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _moveInput;
    private bool _canMove = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
        if (_canMove)
        {
            _rigidbody2D.velocity = new Vector2(_moveInput * _walkSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

            // Walk ANIMATION
            _animator.SetFloat("isRunning", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        
            if (_spriteRenderer.flipX && _moveInput > 0 || !_spriteRenderer.flipX && _moveInput < 0)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
            }
        }
    }

    private void MoveInput()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    // Animation Event
    public void CanMove()
    {
        _canMove = true;
    }  
    public void CannotMove()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _canMove = false;
    }
}
