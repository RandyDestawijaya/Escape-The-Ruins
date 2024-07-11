using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotDialogueTrigger : MonoBehaviour
{
    [SerializeField]
    DialogueTrigger dialogueTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            dialogueTrigger.StartDialogue();
        }
    }
}
