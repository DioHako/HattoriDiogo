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
        if ( GameManager.Instance.Lives >= 1 )
        {
            GameManager.Instance.Lives -= damage;
            GameManager.Instance.UpdateHealthUI(GameManager.Instance.Lives);
            _animator.SetTrigger("isHit");
        }
        if ( GameManager.Instance.Lives <= 0 )
        {
            _animator.SetTrigger("Death");
        }
    }

    // Animation Event linked to Death animation
    public void LoadGameOver()
    {
        GameManager.Instance.ResetHealthUI(false);
        GameManager.Instance.LoadScene("GameOver");
    }
}
