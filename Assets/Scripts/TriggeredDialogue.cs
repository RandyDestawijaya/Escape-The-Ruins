using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TriggeredDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject characterIcon;

    private int index;

    [SerializeField]
    Achievement achievement;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        gameObject.SetActive(true);
        Time.timeScale = 0f;
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

    IEnumerator TypeLine()
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
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            if (characterIcon != null)
            {
                characterIcon.SetActive(false);
            }
            achievement.StartDialogue();
        }
    }
}
