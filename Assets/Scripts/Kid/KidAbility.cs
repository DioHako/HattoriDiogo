using System;
using UnityEngine;

public class KidAbility : MonoBehaviour
{
    public event Action OnRolling;

    [Header("Abilities")]
    [SerializeField] private float _rubberJumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private float _checkLength;
    [SerializeField] private LayerMask _isRubberBlock;

    public PowerUPs _powerUps;

    private Animator _animator;
    private KidJump _kidJump;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _kidJump = GetComponent<KidJump>();
    }

    private void Update()
    {
        RollAbility();
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
        Gizmos.DrawLine(transform.position + _groundCheckOffset, transform.position + _groundCheckOffset + Vector3.right * _checkLength);
    }
}
