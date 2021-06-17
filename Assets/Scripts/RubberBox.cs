using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RubberBox : MonoBehaviour
{
    [SerializeField] private AudioClip _bounce;
    [SerializeField] private float _bounceForce;
    
    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var kidJump = collision.gameObject.GetComponent<KidJump>();
        if (kidJump != null)
        {
            _animator.SetTrigger("isTouched");

            var velocity = kidJump.GetComponent<Rigidbody2D>();

            var normal = collision.GetContact(0).normal;

            if ( normal.y < 0 )
            {
                _audioSource.PlayOneShot(_bounce);
                velocity.AddForce(Vector2.up * _bounceForce);
            }
            else if (normal.y > 0)
            {
                _audioSource.PlayOneShot(_bounce);
                velocity.velocity += Vector2.down;
            }
        }
    }
}
