using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    [SerializeField] private float slipFactor = 0.5f; // Slip factor determines how much velocity is retained while slipping

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D component
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply horizontal slip to the Rigidbody2D's velocity
            Vector2 slipVelocity = new Vector2(rb.velocity.x * slipFactor, rb.velocity.y);
            rb.velocity = slipVelocity;
        }
    }
}
