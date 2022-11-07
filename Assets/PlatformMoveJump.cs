using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveJump : MonoBehaviour
{
    bool isGrounded = false;
    Rigidbody2D rb;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float jumpForce = 3f;
    [SerializeField]
    private KeyCode jumpButton;
    float horizontal = 0;
    [SerializeField]
    Transform groundCheckTransform;
    [SerializeField]
    float groundCheckRadius = 0.05f;
    [SerializeField]
    LayerMask groundCheckLayer;
    [SerializeField]
    int maxJump = 2;
    [SerializeField]
    int jumpCount = 0;
    bool facingRight = false; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //capture input
        horizontal = Input.GetAxis("Horizontal");

        //Move left and right
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //check ground
        isGrounded = Grounded();

        //jump
        if (Input.GetKeyDown(jumpButton))
        {
            if(isGrounded || jumpCount < maxJump)
            {
                rb.velocity = new Vector2(horizontal * speed, jumpForce);
                jumpCount++;
            }
        }

        //adjust jump
        if(Input.GetKeyUp(jumpButton) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y * 0.5f);
        }

        // flip
        flip(); 
    }

    public bool Grounded()
    {
      if(Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer))
        {
            jumpCount = 0; 
            return true; 
        } else
        {
            return false; 
        }
    }

    public void flip()
    {
        if((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0)); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb"))
        {
            Debug.Log($"Collided with {collision.gameObject.name}");
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name} with a isTriggerCollider");
        Destroy(collision.gameObject); 
    }

}


