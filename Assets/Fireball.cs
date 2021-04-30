using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float lifetime;

    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(fireballSpeed, 0);
        Destroy(gameObject, lifetime);
    }
}