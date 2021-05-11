using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(BoxCollider2D))]
public class Collectables : MonoBehaviour
{
    public CollectableType type;

    public event Action OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var kidinventory = collision.GetComponent<KidInventory>();

        if (kidinventory != null)
        {
            OnPickUp?.Invoke();
            kidinventory.Pickup(this);
            gameObject.SetActive(false);
        }
    }

    //private void OnValidate()
    //{
    //    var collider = GetComponent<CircleCollider2D>();
    //    collider.isTrigger = true;
    //}
}
