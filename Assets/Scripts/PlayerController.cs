using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private bool ground = false;
    [SerializeField] private float doubleJump = 1;
    private float jumpingGravity = -9.81f;
    private float fallingGravity = -29.43f;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0)
        {
            Physics2D.gravity = new Vector2(0, jumpingGravity);
            rb.velocity = Vector3.up * jumpPower;
            doubleJump--;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics2D.gravity = new Vector2(0, fallingGravity);
        }
        if (ground)
        {
            doubleJump = 1;
        }
    }

    void Facing()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void OnGround(bool x)
    {
        ground = x;
    }

    void Animation()
    {
        animator.SetFloat("Moving", Mathf.Abs(horizontalInput));
    }
}
