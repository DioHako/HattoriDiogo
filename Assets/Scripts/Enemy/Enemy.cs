using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public bool Stationery;

    [Header("Status")]
    [SerializeField] private float _walkSpeed = 10f;

    [Header("Projectile Properties")]
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;
    [SerializeField] private Fireball _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;

    [Header("Patrolling State")]
    [SerializeField] private float _checkDistance;
    [SerializeField] private Vector2 _rayCastOffset;
    [SerializeField] private LayerMask _checkWalls;

    [Header("Character Detection")]
    [SerializeField] private int _detectionRadius;
    [SerializeField] private LayerMask _detectionLayer;

    private float characterDistance;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private EnemyStatus _enemyStatus;

    private float _fireRateCounter;

    private float _directionSmooth = 1;
    private float _direction = -1;
    private float _changeDirectionEase = 1;

    private RaycastHit2D isDetected;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyStatus = GetComponent<EnemyStatus>();

        _fireRateCounter = _fireRate;
    }

    private void OnEnable()
    {
        _enemyStatus.CannotMove += CannotMove;
    }
    private void OnDisable()
    {
        _enemyStatus.CannotMove -= CannotMove;
    }


    private void Update()
    {
        PlayerDetection();

        if (Stationery)
        {
            _animator.SetBool("isStationery", true);
            _rigidbody2D.velocity = Vector2.zero;
            if (_fireRateCounter <= 0 && isDetected)
            {
                _animator.SetTrigger("isShooting");
                _fireRateCounter = _fireRate;
            }
            else
            {
                _fireRateCounter -= Time.deltaTime;
            }
        }
        else
            Walking();
    }

    private void PlayerDetection()
    {
        isDetected = Physics2D.CircleCast(transform.position, _detectionRadius, Vector2.zero, _detectionRadius, _detectionLayer);

        if (isDetected)
        {
            characterDistance = isDetected.collider.gameObject.transform.position.x - transform.position.x;

            if (characterDistance < 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void Walking()
    {
        _animator.SetBool("isStationery", false);
        Vector2 move = Vector2.zero;
        _directionSmooth += (_direction - _directionSmooth) * Time.deltaTime * _changeDirectionEase;
        move.x = 1 * _directionSmooth;

        Flip(move);
        WallDetection();

        _rigidbody2D.velocity = new Vector2(move.x * _walkSpeed, _rigidbody2D.velocity.y);
    }

    private void Flip(Vector2 move)
    {
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
    }

    private void WallDetection()
    {
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y) + Vector2.left * _checkDistance);
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y), new Vector2(transform.position.x, transform.position.y + _rayCastOffset.y) + Vector2.right * _checkDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

    private void CannotMove()
    {
        _walkSpeed = 0;
    }

    public void Shooting()
    {
        if (transform.localScale.x == -1)
        {
            Fireball projectileInstance = Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
            projectileInstance.GetComponent<SpriteRenderer>().flipX = true;
            projectileInstance.Damage = _damage;
        }
        else
        {
            Fireball projectileInstance = Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
            projectileInstance.fireballSpeed *= -1;
            projectileInstance.Damage = _damage;
        }
    }

}



