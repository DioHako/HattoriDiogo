using UnityEngine;

public class KidJump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    [Header("Ground Check")]
    [SerializeField] private float _groundCheckLenght;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private LayerMask _isGround;

    public bool IsGrounded { get; private set; }
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool _canJump;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInputs();
        JumpAction();
    }

    private void FixedUpdate()
    {
    }

    private void JumpAction()
    {
        if (_canJump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckInputs()
    {
        IsGrounded = Physics2D.Raycast(transform.position + _groundCheckOffset, Vector2.down, _groundCheckLenght, _isGround) ||
                      Physics2D.Raycast(transform.position - _groundCheckOffset, Vector2.down, _groundCheckLenght, _isGround);

        // Jump ANIMATION
        _animator.SetBool("isGrounded", IsGrounded);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + _groundCheckOffset, transform.position + _groundCheckOffset + Vector3.down * _groundCheckLenght);
        Gizmos.DrawLine(transform.position - _groundCheckOffset, transform.position - _groundCheckOffset + Vector3.down * _groundCheckLenght);
    }

    public void SetJumpForce(float newJumpForce)
    {
        _jumpForce = newJumpForce;
    }
}


