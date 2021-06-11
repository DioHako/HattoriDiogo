using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class ItemBox : MonoBehaviour
{
    public enum BoxTypes
    {
        ConcreteBox,
        ItemBox,
        MetalBox
    }

    [SerializeField] BoxTypes BoxType;

    [SerializeField] List<AudioClip> _clip;

    private Animator _animator;
    private AudioSource _source;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
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

                switch ( BoxType )
                {
                    case BoxTypes.ConcreteBox:
                        _source.PlayOneShot(_clip[0]);
                        break;
                    case BoxTypes.ItemBox:
                        _source.PlayOneShot(_clip[0]);
                        break;
                    case BoxTypes.MetalBox:
                        _source.PlayOneShot(_clip[1]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
