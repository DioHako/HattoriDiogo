using UnityEngine;

public class KidPowerUps : MonoBehaviour
{
    [SerializeField] AudioClip _henshin;

    private Animator _animator;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Henshin(Collectables powerups, int diamonds)
    {
        switch (powerups.PowerUp)
        {
            case PowerUPs.Berserker:
                Debug.Log(" HENSHIN ===> BERSERKER!");
                break;
            case PowerUPs.IronKnight:
                Debug.Log(" HENSHIN ===> IRON KNIGHT!");
                _audioSource.PlayOneShot(_henshin);
                _animator.SetTrigger("IronKnightIN");
                _animator.SetLayerWeight(1, 1);
                break;
        }
        // if (powerups is NOT on)
        // henshin

        // else if (powerUp is on)
        // increase diamonds++


        //Debug.Log("!!! H-E-N-S-H-I-N !!!");
        // Play animation
        // Transform into the a new Character based on the Mask
    }
}
