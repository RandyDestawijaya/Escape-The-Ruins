using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class InteractionRelic : MonoBehaviour
{
    [SerializeField] private float relic;
    [SerializeField] private GameObject textObject;
    private bool interaction = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            PlayerPrefs.SetInt("RelicIndex" + relic, 1);
            PlayerPrefs.Save();    
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
