using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    public float speed = 40f; // The speed of the egg
    private Rigidbody2D rb; // Reference to the egg's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the egg's rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the egg in its current direction
        rb.velocity = transform.up * speed;

        // Destroy the egg if it goes offscreen
        if (GlobalBehavior.sTheGlobalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds) == GlobalBehavior.WorldBoundStatus.Outside)
        {
            Destroy(gameObject);
            GlobalBehavior.sTheGlobalBehavior.DecEggCount();
        }
    }

    // Set the velocity of the egg's rigidbody to the specified vector
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
