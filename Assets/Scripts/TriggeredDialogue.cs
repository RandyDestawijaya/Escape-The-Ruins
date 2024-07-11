using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TriggeredDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject characterIcon;

    private int index;
    [SerializeField]
    private GameObject Achievement;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    [SerializeField]
    PlayerController playerController;

    private Image imageComponent;
    [SerializeField] GameObject Gambar;
    private bool lastDialog = false,Dialog = false ;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
        imageComponent = GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) && Dialog)
        {
            if (lastDialog)
            {
                Dialog = false;
                Time.timeScale = 1f;
                StartCoroutine(StartAchivement());
            }
            else if (textComponent.text == lines[index])
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
        Gambar.SetActive(false);
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
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }
    private IEnumerator StartAchivement()
    {
        Achievement.SetActive(true);
        Achievement achievement = Achievement.GetComponent<Achievement>();
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
        achievement.StartDialogue();
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
            textComponent.enabled = false;
            imageComponent.enabled = false;
            if (characterIcon != null)
            {
                characterIcon.SetActive(false);
            }
            Gambar.SetActive(true);
            lastDialog = true;
            playerController.enabled = true;
        }
    }
}
