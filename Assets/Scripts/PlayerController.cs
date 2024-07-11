using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    private bool isGrounded = true;
    private float jumpingGravity = -9.18f;
    private float fallingGravity = -29.43f;
    Animator animator;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    [SerializeField]
    GameObject PauseMenu;

    private bool canMove = true; // Flag to control movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
        //LoadPlayerPosition();
    }

    void Update()
    {
        if (canMove) // Only allow movement if canMove is true
        {
            Movement();
            Facing();
        }
        Animation();
        Pause();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Physics2D.gravity = new Vector2(0, jumpingGravity);
            rb.velocity = Vector3.up * jumpPower;
            audioSource.clip = audioclips[0];
            audioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics2D.gravity = new Vector2(0, fallingGravity);
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isPaused = Time.timeScale == 0f;
            Time.timeScale = isPaused ? 1f : 0f;
            PauseMenu.SetActive(!isPaused);
        }
    }

    void Facing()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    void Animation()
    {
        animator.SetFloat("Moving", Mathf.Abs(horizontalInput));
        animator.SetBool("OnGround", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            isGrounded = true;
        }

        if (col.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
            isGrounded = true;
        }

        if (col.tag == "Spike")
        {
            StartCoroutine(SpikeDeathScene());
            audioSource.clip = audioclips[1];
            audioSource.Play();
        }

        if (col.tag == "FallTrigger")
        {
            StartCoroutine(FallDeathScene());
            audioSource.clip = audioclips[1];
            audioSource.Play();
        }

        if (col.tag == "Arrow")
        {
            StartCoroutine(ArrowDeathScene());
            audioSource.clip = audioclips[1];
            audioSource.Play();
        }

        if (col.tag == "Finish")
        {
            StartCoroutine(Epilogue());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boulder"))
        {
            StartCoroutine(BoulderDeathScene());
            audioSource.clip = audioclips[1];
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            isGrounded = false;
        }

        if (col.tag == "MovingPlatform")
        {
            transform.parent = null;
            isGrounded = false;
        }
    }


    IEnumerator SpikeDeathScene()
    {
        canMove = false; // Disable movement

        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("SpikeGameover");
    }

    IEnumerator FallDeathScene()
    {
        canMove = false; // Disable movement

        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("FallGameover");
    }

    IEnumerator ArrowDeathScene()
    {
        canMove = false; // Disable movement

        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("ArrowGameover");
    }

    IEnumerator BoulderDeathScene()
    {
        canMove = false; // Disable movement

        animator.SetTrigger("Death");

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("BoulderGameover");
    }

    IEnumerator Epilogue()
    {
        PlayerPrefs.SetInt("RelicIndex" + 4, 4);
        PlayerPrefs.Save();
        yield return new WaitForEndOfFrame(); 
        SceneManager.LoadScene("Epilogue");
    }

    private void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && SceneManager.GetActiveScene().name == "Level1")
        {
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");
            transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
        }
    }

    public void UpdateCheckpoint(Vector3 checkpointPosition)
    {
        PlayerPrefs.SetFloat("PlayerPosX", checkpointPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", checkpointPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", checkpointPosition.z);
        PlayerPrefs.Save();
    }
}