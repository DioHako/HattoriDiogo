using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float _walkSpeed = 10f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private CircleCollider2D _head;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _head = GetComponentInChildren<CircleCollider2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(-_walkSpeed, _rigidbody2D.velocity.y);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    private void EnemyDeath()
    {
        _walkSpeed = 0;
        _head.gameObject.SetActive(false);
        _animator.SetTrigger("Death");
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var kidjump = collision.GetComponent<KidJump>();
        //var jump = kidjump.GetComponent<Rigidbody2D>();
        if (kidjump != null)
        {
            EnemyDeath();
            //jump.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }
    }




}



