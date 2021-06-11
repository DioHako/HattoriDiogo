using System.Collections;
using UnityEngine;

public class KidInventory : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    private int _diamonds;
    private KidPowerUps _powerUp;
    private AudioSource _audioSource;


    // TEMP
    private KidJump _kidJump;
    private bool setNewJump;

    private void Awake()
    {
        _powerUp = GetComponent<KidPowerUps>();
        _audioSource = GetComponent<AudioSource>();
        

        // TEMP
        _kidJump = GetComponent<KidJump>();
    }

    public void Pickup(Collectables item)
    {

        if (item.collectableTypes == CollectableType.Diamond)
        {
            _audioSource.PlayOneShot(_clip);
            GameManager.Instance.Diamond++;
        }
        else if (item.collectableTypes == CollectableType.PowerUp)
        {
            _powerUp.Henshin(item, _diamonds);
        }
        else if (item.collectableTypes == CollectableType.Cross)
        {
            _audioSource.PlayOneShot(_clip);
            GameManager.Instance.Cross++;
            Debug.Log("You now have a new jump force!");
            StartCoroutine(NewJumpForce());
        }
    }


    // TEMP
    private IEnumerator NewJumpForce()
    {
        _kidJump.SetJumpForce(7f);
        yield return new WaitForSeconds(5f);
        _kidJump.SetJumpForce(5.5f);
    }
}
