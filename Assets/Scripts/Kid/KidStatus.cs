using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KidStatus : MonoBehaviour
{
    [SerializeField] List<AudioClip> _clips;

    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void GetHit(int damage)
    {
        if ( GameManager.Instance.Lives >= 1 )
        {
            GameManager.Instance.Lives -= damage;
            GameManager.Instance.UpdateHealthUI(GameManager.Instance.Lives);
            var randomClip = Random.Range(0, _clips.Count);
            _audioSource.PlayOneShot(_clips[randomClip]);
            _animator.SetTrigger("isHit");
        }
        if ( GameManager.Instance.Lives <= 0 )
        {
            var randomClip = Random.Range(0, _clips.Count);
            _audioSource.PlayOneShot(_clips[randomClip]);
            _animator.SetTrigger("Death");
        }
    }

    // Animation Event linked to Death animation
    public void LoadGameOver()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.Play(2);
        GameManager.Instance.ResetHealthUI(false);
        GameManager.Instance.LoadScene("GameOver");
    }
}
