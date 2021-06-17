using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _playerBounce;
    [SerializeField] private AudioClip[] _hitSound;

    private Animator _animator;
    private Enemy _enemy;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var kidStatus = collision.gameObject.GetComponent<KidStatus>();
        if (kidStatus != null)
        {
            var jump = kidStatus.GetComponent<Rigidbody2D>();
            var normal = collision.contacts[0].normal;
            if ( normal.y < 0 )
            {
                var randomClip = Random.Range(0, _hitSound.Length);
                jump.velocity += Vector2.up * _playerBounce;
                if ( _health > 1 )
                {
                    _audioSource.PlayOneShot(_hitSound[randomClip]);
                    _health--;
                }
                else if ( _health <= 1 )
                {
                    _audioSource.PlayOneShot(_hitSound[randomClip]);
                    _animator.SetTrigger("Death");
                    _enemy.SetWalkSpeed(0);
                }
            }
            else
            {
                kidStatus.GetHit(1);
            }
        }
    }

    public void GetHit(int damage)
    {
        if (_health > 1)
        {
            _health -= damage;
        }
        else if (_health <= 1)
        {
            Destroy(gameObject);
        }
    }

    // Animation Events
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void ChangeLayer()
    {
        this.gameObject.layer = 12;
    }
}
