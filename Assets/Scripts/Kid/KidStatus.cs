using UnityEngine;

public class KidStatus : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetHit(int damage)
    {
        if (GameManager.Instance.Lives > 1)
        {
            GameManager.Instance.Lives -= damage;
            _animator.SetTrigger("isHit");
        }
        else if (GameManager.Instance.Lives <= 1)
        {
            _animator.SetTrigger("Death");
        }
    }

    // Animation Events
    public void LoadGameOver()
    {
        GameManager.Instance.LoadScene("GameOver");
    }
}
