using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(BoxCollider2D))]
public class Collectables : MonoBehaviour
{
    public CollectableType collectableTypes;
    public PowerUPs PowerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var kidinventory = collision.GetComponent<KidInventory>();

        if (kidinventory != null)
        {
            kidinventory.Pickup(this);
            gameObject.SetActive(false);
        }
    }
}
