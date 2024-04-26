using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DestinationDoor;
    public GameObject Player;
    public GameObject textObject;
    private bool interaction = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            Player.transform.position = DestinationDoor.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interaction = true;
            textObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interaction = false;
            textObject.SetActive(false);
        }
    }
}
