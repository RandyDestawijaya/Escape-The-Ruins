using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; // Import the Playables namespace
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Achievement : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public PlayableDirector timeline; // Reference to the PlayableDirector component

    private int index;

    public float ChangeTime;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTime -= Time.deltaTime;
        if (ChangeTime <= 0)
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        index = 0;

        textComponent.text = lines[index];

        // Play the timeline animation
        if (timeline != null)
        {
            timeline.Play();
        }

        audioSource.clip = audioclips[0];
        audioSource.Play();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartDialogue();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
