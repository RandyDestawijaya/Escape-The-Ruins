using UnityEngine;
using UnityEngine.Video;

public class PrologueStart : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float pauseDuration = 5f; // Pause duration in seconds
    private float timer = 0f;
    private bool timerStarted = false;

    void Start()
    {
        // Do not auto-play the video
        videoPlayer.playOnAwake = false;
    }

    void Update()
    {
        if (!timerStarted)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the timer has reached the pause duration
            if (timer >= pauseDuration)
            {
                // Start playing the video
                videoPlayer.Play();
                timerStarted = true;
            }
        }
    }
}
