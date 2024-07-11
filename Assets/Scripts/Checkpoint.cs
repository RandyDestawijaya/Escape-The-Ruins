using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerController controller;
    private void Awake()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        controller = Player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.UpdateCheckpoint(transform.position);
        }
    }
}
