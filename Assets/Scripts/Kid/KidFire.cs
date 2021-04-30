using UnityEngine;

public class KidFire : MonoBehaviour
{
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Fireball fireBallPrefab;

    public float projectileSpeed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (!spawnPointRight || !fireBallPrefab || !spawnPointLeft)
            Debug.LogWarning("Unity Inspector Values not set!");
    }

    private void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1 && Input.GetKeyDown(KeyCode.K))
        {
            _animator.SetTrigger("isFlashing");
        }
    }

    public void Fireball()
    {
        if (_spriteRenderer.flipX)
        {
            // Hisham, is there a better way to code this behaviour on the projectile FLIP when shooting to the left?

            Fireball projectileInstance = Instantiate(fireBallPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.fireballSpeed = -projectileSpeed;
            projectileInstance.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            Fireball projectileInstance = Instantiate(fireBallPrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.fireballSpeed = projectileSpeed;
        }
    }
}
