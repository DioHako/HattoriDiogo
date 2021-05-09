using System;
using UnityEngine;

public class KidAbility : MonoBehaviour
{
    public event Action OnRolling;
    
    [Header("Abilities")]
    [SerializeField] private float _length;
    [SerializeField] private float _rubberJumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private LayerMask _isRubberBlock;

    private Animator _animator;
    private KidJump _kidJump;

    private RaycastHit2D _rubberBlock;
    private Rigidbody2D _rigidbody2D;
    private Animator _rubberBlockAnim;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _kidJump = GetComponent<KidJump>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        RollAbility();

        _rubberBlock = Physics2D.Raycast(transform.position + _groundCheckOffset, Vector2.right, _length, _isRubberBlock);

        if (_rubberBlock)
        {
            _rubberBlock.collider.GetComponent<Animator>().SetTrigger("isTouched");
            Vector2 forceToAdd = new Vector2(0, _rubberJumpForce);
            _rigidbody2D.AddForce(forceToAdd);
        }
    }

    private void RollAbility()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 && Input.GetKeyDown(KeyCode.J) && _kidJump.IsGrounded)
        {
            OnRolling?.Invoke();
            _animator.SetTrigger("isRolling");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + _groundCheckOffset, transform.position + _groundCheckOffset + Vector3.right * _length);

    }
}
