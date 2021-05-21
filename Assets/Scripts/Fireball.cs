using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float lifetime;
    public int Damage = 1;

    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(fireballSpeed, 0);
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }

        var kidStatus = collision.GetComponent<KidStatus>();
        if (kidStatus != null)
        {
            Destroy(gameObject);
            kidStatus.GetHit(Damage);
        }
    }
}
