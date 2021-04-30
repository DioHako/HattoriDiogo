using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(BoxCollider2D))]
public class Collectables : MonoBehaviour
{
    public event Action OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var henshin = collision.GetComponent<KidPowerUps>();

        if (henshin != null)
        {
            henshin.Henshin();
            
            OnPickUp?.Invoke();

            gameObject.SetActive(false);
        }
    }
}
