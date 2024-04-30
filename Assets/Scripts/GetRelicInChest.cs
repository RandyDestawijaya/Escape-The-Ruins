using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetRelicInChest : MonoBehaviour
{
    [SerializeField] private float relic;
    [SerializeField] private GameObject textObject;
    private TextMeshPro text;
    private bool interaction = false;
    [SerializeField] GameObject[] chest;
    bool isOpen = false;
    [SerializeField] TriggeredDialogue TriggeredDialogue;
    private void Start()
    {
        if (PlayerPrefs.HasKey("RelicIndex" + relic))
        {
            isOpen = true;
            Debug.Log("udah ada");
        }
        text = textObject.GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            chest[0].SetActive(false);
            chest[1].SetActive(true);
            if (!isOpen)
            {
                PlayerPrefs.SetInt("RelicIndex" + relic, 0);
                PlayerPrefs.Save();
                Debug.Log("Dapet 1");
                isOpen = true;
                TriggeredDialogue.StartDialogue();
            }
            else 
            {
                UpdateInfo("Chest Empty!");
            } 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interaction = true;
            textObject.SetActive(true);
            UpdateInfo("E|Open Chest");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interaction = false;
            chest[0].SetActive(true);
            chest[1].SetActive(false);
            textObject.SetActive(false);
        }
    }
    private void UpdateInfo(string info)
    {
        text.text = info;
    }
}
