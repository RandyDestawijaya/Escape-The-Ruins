using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class InteractionRelic : MonoBehaviour
{
    [SerializeField] private GameObject InfoUI;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject Relic;
    [SerializeField] private GameObject InfoNull;
    private bool interaction = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            if (Relic.activeInHierarchy)
            {
                InfoUI.SetActive(true);
            }
            else 
            {
                InfoNull.SetActive(true);
            }
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
