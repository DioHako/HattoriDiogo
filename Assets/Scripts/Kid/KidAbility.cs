using System;
using UnityEngine;

public class KidAbility : MonoBehaviour
{
    public event Action OnRolling;

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
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 && Input.GetKeyDown(KeyCode.J) && _kidJump._isGrounded)
        {
            OnRolling?.Invoke();
            _animator.SetTrigger("isRolling");
        }
    }
}
