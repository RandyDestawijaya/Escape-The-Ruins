using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBottomTrigger : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            playerController.OnGround(true);
        }
    }
}
