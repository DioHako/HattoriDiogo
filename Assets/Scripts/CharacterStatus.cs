using UnityEngine;

public abstract class CharacterStatus : MonoBehaviour
{
    [SerializeField] protected int _health;

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
}
