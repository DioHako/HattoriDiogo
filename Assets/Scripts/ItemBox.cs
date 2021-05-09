using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var kid = collision.gameObject.GetComponent<KidJump>();
        if (kid != null)
        {
            var normal = collision.contacts[0].normal;
            if (normal.y > 0)
            {
                _animator.SetTrigger("isHit");
            }
        }
    }
}
