using System.Collections;
using UnityEngine;

public class KidInventory : MonoBehaviour
{
    private int _diamonds;
    private KidPowerUps _powerUp;

    // TEMP
    private KidJump _kidJump;
    private bool setNewJump;

    private void Awake()
    {
        _powerUp = GetComponent<KidPowerUps>();
        

        // TEMP
        _kidJump = GetComponent<KidJump>();
    }

    public void Pickup(Collectables item)
    {

        if (item.collectableTypes == CollectableType.Diamond)
        {
            GameManager.Instance.Diamond++;
        }
        else if (item.collectableTypes == CollectableType.PowerUp)
        {
            _powerUp.Henshin(item, _diamonds);
        }
        else if (item.collectableTypes == CollectableType.Cross)
        {
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
