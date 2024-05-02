using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotDialogueTrigger : MonoBehaviour
{
    [SerializeField]
    TriggeredDialogue TriggeredDialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            TriggeredDialogue.StartDialogue();
        }
    }
}
