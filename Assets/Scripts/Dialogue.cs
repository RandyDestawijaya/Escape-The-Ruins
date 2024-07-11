using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject characterIcon;

    [SerializeField]
    PlayerController PlayerController;

    private int index;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    private bool Dialog = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
        string sceneName = SceneManager.GetActiveScene().name;
        gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Dialog" + sceneName) == 0)
        {
            gameObject.SetActive(true);
            PlayerPrefs.SetInt("Dialog" + sceneName, 1);
            PlayerPrefs.Save();
            StartDialogue();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) && Dialog)
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

    public void StartDialogue()
    {
        Dialog = true;
        Time.timeScale = 0f;
        index = 0;
        StartCoroutine(TypeLine());
        audioSource.clip = audioclips[0];
        audioSource.Play();
        SetCharacterIcon(dialogueLines[index].characterIcon);
        PlayerController.enabled = false;
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
            Dialog = false;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            PlayerController.enabled = true;
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
