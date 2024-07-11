using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetRelicInChest : MonoBehaviour
{
    [SerializeField] private int relic;
    private Animator animator;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject textObject;
    private TextMeshPro text;
    private bool interaction = false,isOpen = false ;
    [SerializeField] private GameObject TriggeredDialogue;
    private void Start()
    {
        animator = GetComponent<Animator>();
        text = textObject.GetComponent<TextMeshPro>();
        if (PlayerPrefs.HasKey("RelicIndex" + relic))
        {
            isOpen = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interaction)
        {
            animator.SetBool("openChest", true);
            if (!isOpen)
            {
                UpdateInfo("");
                StartCoroutine(MoveItemUp(item));
                PlayerPrefs.SetInt("RelicIndex" + relic, relic);
                PlayerPrefs.Save();
                isOpen = true;
            }
            else 
            {
                UpdateInfo("Chest Empty!");
            } 
        }
    }
    private IEnumerator MoveItemUp(GameObject item)
    {
        yield return new WaitForSeconds(1);
        item.SetActive(true);
        while (item.transform.position.y < point.transform.position.y)
        {
            float step = 2f * Time.deltaTime;
            item.transform.Translate(Vector3.up * step);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        TriggeredDialogue.SetActive(true);
        TriggeredDialogue dialogue = TriggeredDialogue.GetComponent<TriggeredDialogue>();
        yield return new WaitForEndOfFrame();
        item.SetActive(false);
        dialogue.StartDialogue();
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
            animator.SetBool("openChest", false);
            textObject.SetActive(false);
        }
    }
    private void UpdateInfo(string info)
    {
        text.text = info;
    }
}
