using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject characterIcon;

    [SerializeField]
    PlayerController playerController;

    private int index;
    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    private bool Dialog = false;
    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) && Dialog)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                audioSource.clip = audioclips[0];
                audioSource.Play();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        Dialog = true;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        playerController.enabled = false;
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
        audioSource.clip = audioclips[0];
        audioSource.Play();

        if (characterIcon != null)
        {
            characterIcon.SetActive(true);
        }
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Dialog = false;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            playerController.enabled = true;
            if (characterIcon != null)
            {
                characterIcon.SetActive(false);
            }
        }
    }
}
