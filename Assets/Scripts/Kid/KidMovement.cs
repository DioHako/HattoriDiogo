using UnityEngine;

public class KidMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private float _moveInput;
    private bool _facingRight = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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

        // Walk ANIMATION
        _animator.SetFloat("isRunning", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        // REVISED THIS SECTION
        // Hisham showed a better way to implement this section
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

    // REVISED THIS FUNCTION
    // Hisham showed a better way to implement this function.
    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
