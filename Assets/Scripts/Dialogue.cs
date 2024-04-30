using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string line;
    public Sprite characterIcon;
}

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public List<DialogueLine> dialogueLines;
    public float textSpeed;
    public GameObject characterIcon; // Reference to the character icon GameObject

    private int index;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (textComponent.text == dialogueLines[index].line)
            {
                NextLine();
                audioSource.clip = audioclips[0];
                audioSource.Play();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueLines[index].line;
                SetCharacterIcon(dialogueLines[index].characterIcon);
            }
        }
    }

    void StartDialogue()
    {
        Time.timeScale = 0f;
        index = 0;
        StartCoroutine(TypeLine());
        audioSource.clip = audioclips[0];
        audioSource.Play();
        SetCharacterIcon(dialogueLines[index].characterIcon);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogueLines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            characterIcon.SetActive(false);
        }
    }

    void SetCharacterIcon(Sprite icon)
    {
        if (characterIcon != null)
        {
            characterIcon.GetComponent<SpriteRenderer>().sprite = icon;
            characterIcon.SetActive(true);
        }
    }
}
