using UnityEngine;

public class KidPowerUps : MonoBehaviour
{

    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
                _animator.SetTrigger("IronKnightIN");
                _animator.SetLayerWeight(1, 1);
                Debug.Log(_animator.runtimeAnimatorController);
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
