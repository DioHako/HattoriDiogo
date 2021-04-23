using UnityEngine;

public class KidAbility : MonoBehaviour
{
    private Animator _animator;
    private CircleCollider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        // ROLLING ABILITY
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 && Input.GetKeyDown(KeyCode.J))
        {
            _animator.SetTrigger("isRolling");
        }

        // FLASHING ABILITY
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1 && Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetTrigger("isFlashing");
        }
    }
}
