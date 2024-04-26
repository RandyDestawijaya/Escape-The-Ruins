using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float distance;
    bool inground = true;
    public float distanceToMove = 5f; // Distance to move in the X-axis
    private bool hasMoved = false; // Flag to track if the object has moved
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (inground == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, distance);

            Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    if (!hasMoved)
                    {
                        // Calculate the new position based on the distance to move
                        float newYPosition = transform.position.y + distanceToMove;

                        // Update the object's position only along the X-axis
                        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

                        // Set the flag to indicate that the object has moved
                        hasMoved = true;
                    }
                }
            }

        }
    }
}
