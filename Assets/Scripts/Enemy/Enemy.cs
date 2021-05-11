using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float _walkSpeed = 10f;
    [SerializeField] private int _hitCount;
    [SerializeField] private float _playerBounce;

    [Header("Patrolling State")]
    [SerializeField] private float _checkDistance;
    [SerializeField] private Vector2 _rayCastOffset;
    [SerializeField] private LayerMask _checkWalls;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private float _directionSmooth = 1;
    private float _direction = -1;
    private float _changeDirectionEase = 1;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 move = Vector2.zero;
        _directionSmooth += (_direction - _directionSmooth) * Time.deltaTime * _changeDirectionEase;
        move.x = 1 * _directionSmooth;


        if (move.x < -0.01f)
        {
            if (transform.localScale.x == -1)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (move.x > 0.01f)
        {
            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }


        // Detect left wall
        var leftWall = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), Vector2.left, _checkDistance, _checkWalls);

        if (leftWall.collider != null)
        {
            _direction = 1;
        }


        // Detect right wall
        var rightWall = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), Vector2.right, _checkDistance, _checkWalls);

        if (rightWall.collider != null)
        {
            _direction = -1;
        }

        _rigidbody2D.velocity = new Vector2(move.x * _walkSpeed, _rigidbody2D.velocity.y);
    }

    private void Flip(Vector2 move)
    {
        
    }

    private void EnemyDeath()
    {
        _walkSpeed = 0;
        _animator.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var kidjump = collision.GetComponent<KidJump>();
        if (kidjump != null)
        {
            var jump = kidjump.GetComponent<Rigidbody2D>();
            jump.AddForce(Vector2.up * _playerBounce, ForceMode2D.Impulse);
            if (_hitCount > 1)
            {
                _hitCount--;
            }
            else
            {
                EnemyDeath();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y) + Vector2.left * _checkDistance);
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), new Vector2 (transform.position.x, transform.position.y + _rayCastOffset.y) + Vector2.right * _checkDistance);
    }

    // Event Animations
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void ChangeLayer()
    {
        this.gameObject.layer = 12;
    }
}



