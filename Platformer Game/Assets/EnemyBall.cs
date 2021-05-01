using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    private const float FireBallSpeed = -2f;

    [SerializeField] public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * FireBallSpeed;
        rb.velocity = new Vector2(1 * FireBallSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().SendMessage("PlayerShot");
        }

        Destroy(gameObject);
    }
}
