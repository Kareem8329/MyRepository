using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovementScript : MonoBehaviour
{
    // Public variables
    public Animator animator;

    public Transform range;
    public float spaceFromPlayer;

    // Private variables
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed;
    public float JumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool isRunning;





    public string enemyTag = "Enemy";
    public int damage = 10;
    public float damageInterval = 3f;
    public int playerHealth = 500;
    private float lastDamageTime;

    bool CanMove;
    
    bool hasDied = false;









    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component of the player object
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        // Get the SpriteRenderer component of the player object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the movement speed and jump force
        moveSpeed = 1.8f;
        JumpForce = 30f;

        lastDamageTime = Time.time;

        Debug.Log("Player is being damaged");

        CanMove = true;

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;

            Debug.Log("Jumping");
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = true;

            Debug.Log("not jumping");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if enough time has passed since the last damage
            if (Time.time - lastDamageTime > damageInterval)
            {
                // Get the number of enemies colliding with the player
                int enemyCount = collision.contactCount;

                // Multiply the damage by the number of enemies colliding with the player
                int totalDamage = damage * enemyCount;

                playerHealth -= totalDamage;
                lastDamageTime = Time.time;

                

                animator.SetBool("GetHit", true);
            }
        }else
        {
            animator.SetBool("GetHit", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
        {
            spriteRenderer.color = Color.red;
        } else
        {
            spriteRenderer.color = Color.white;
        }
    }


    void Die()
    {
        if (!hasDied)
        {
            hasDied = true;
            
            animator.SetBool("Dead", true);
            CanMove = false;

            

            Debug.Log("player Died!");

            
        }


    }



    // Update is called once per frame
    void Update()
    {
        // Get the player's input for horizontal and vertical movement
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");



        if (playerHealth <= 0)
        {
            Die();
        }




        if (CanMove)
        {


            // If left mouse button is pressed, set RightClick animation parameter to true
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("RightClick", true);
            }
            else
            {
                animator.SetBool("RightClick", false);
            }


        }



    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {

        if (CanMove)
        {

            // Move the player horizontally and set the Speed animation parameter
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {
                rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
                animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
                isRunning = true;
            }
            else
            {
                animator.SetFloat("Speed", 0);
                isRunning = false;
            }

            // Set the Height animation parameter based on whether the player is jumping and running
            if (isJumping && isRunning)
            {
                animator.SetFloat("Height", 1);
                animator.SetFloat("Speed", 0);
            }
            else
            {
                animator.SetFloat("Height", 0);
            }

            // Set the Height animation parameter if the player is jumping
            if (isJumping)
            {
                animator.SetFloat("Height", 1);
            }
            else
            {
                animator.SetFloat("Height", 0);
            }

            // Move the range object based on the player's movement direction
            Vector3 rangePosition = range.transform.position;
            if (moveHorizontal > 0.1f)
            {
                spriteRenderer.flipX = false;
                rangePosition.x = transform.position.x + spaceFromPlayer;
            }
            else if (moveHorizontal < -0.1f)
            {
                spriteRenderer.flipX = true;
                rangePosition.x = transform.position.x - spaceFromPlayer;
            }


            range.transform.position = rangePosition;


            if (!isJumping && moveVertical > 0.1f)
            {
                rb2D.AddForce(new Vector2(0f, moveVertical * JumpForce), ForceMode2D.Impulse);
                isJumping = true;

            }



        }





    }




    

}
