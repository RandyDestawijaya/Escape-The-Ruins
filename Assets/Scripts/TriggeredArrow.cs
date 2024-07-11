using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredArrow : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    bool inwall = true;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (inwall == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, distance);

            Debug.DrawRay(transform.position, Vector2.left * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    speed = 30;
                    rb.velocity = Vector2.left * speed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            speed = 0;
            rb.velocity = Vector2.left * speed;
            if (ArrowTrap.remainingArrow > 1)
            {
                Destroy(gameObject, 5f);
                ArrowTrap.RemoveArrow();
            }    
        }
    }
}
