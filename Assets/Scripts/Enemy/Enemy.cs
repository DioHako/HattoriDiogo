using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var kidjump = collision.GetComponent<KidJump>();
        var jump = kidjump.GetComponent<Rigidbody2D>();
        if (kidjump != null)
        {
            gameObject.SetActive(false);
            jump.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }
    }
}
