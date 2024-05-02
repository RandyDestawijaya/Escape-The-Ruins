using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    private bool isGrounded = true;
    private float jumpingGravity = -9.81f;
    private float fallingGravity = -29.43f;
    Animator animator;

    [SerializeField]
    AudioClip[] audioclips;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Facing();
        Animation();
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

    void Facing()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Animation()
    {
        animator.SetFloat("Moving", Mathf.Abs(horizontalInput));
        animator.SetBool("OnGround", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spike")
        {
            SceneManager.LoadScene("SpikeGameover");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
