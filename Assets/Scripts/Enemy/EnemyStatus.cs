using System;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _playerBounce;

    public event Action CannotMove; 

    private Animator _animator;

    public bool CanMove { get; private set; }
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var kidjump = collision.GetComponent<KidJump>();
        if (kidjump != null)
        {
            var jump = kidjump.GetComponent<Rigidbody2D>();
            Vector2 forceToAdd = new Vector2(0, _playerBounce);
            jump.velocity += forceToAdd;

            if (_health > 1)
            {
                _health--;
            }
            else if (_health <= 1)
            {
                _animator.SetTrigger("Death");
                CannotMove?.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var kidStatus = collision.gameObject.GetComponent<KidMovement>();
        if (kidStatus != null)
        {
            GameManager.Instance.Lives--;
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
