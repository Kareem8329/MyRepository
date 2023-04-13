using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    // stuff
    public Animator playerAnimator;
    public Transform playerAttackRange;
    public Rigidbody2D PlayerRb2D;
    public SpriteRenderer playerSpriteRenderer;
    public ParticleSystem playerParticleSystem;
    public ParticleSystemRenderer playerParticleSystemRenderer;

    //strings
    public string enemyTag = "Enemy";

    //int
    public int enemyDamageOnPlayer = 20;
    public int playerHealth = 500;

    //floats
    public float rangeSpaceFromPlayer;
    public float playerMovementSpeed;
    public float playerJumpForce;
    public float playerHorizontalMovementValue;
    public float playerVerticalMovementValue;
    public float playerXPosition;
    public float lastDamageRecievedTime;
    public float damageInterval = 1f;
    public float playerYPosition;

<<<<<<< HEAD
    //booleans
    public bool isRunning;
    public bool CanMove;
    public bool hasDied;
    public bool groundMove;
    public bool isJumping;


    void Start()
    {

        playerAnimator = gameObject.GetComponent<Animator>();


        PlayerRb2D = gameObject.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerParticleSystemRenderer = playerParticleSystem.GetComponent<ParticleSystemRenderer>();
=======
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component of the player object
        rb2D = gameObject.GetComponent<Rigidbody2D>();
>>>>>>> parent of 6d13bab (BG, Particle effect)

        playerMovementSpeed = 1.8f;
        playerJumpForce = 30f;

        lastDamageRecievedTime = Time.time;

        hasDied = false;
        CanMove = true;
        groundMove = false;

<<<<<<< HEAD
    }

=======
        isMovingOnGround = false;
    }



    // Update is called once per frame
>>>>>>> parent of 6d13bab (BG, Particle effect)
    void Update()
    {
        playerXPosition = transform.position.x;
        playerYPosition = transform.position.y;

        playerHorizontalMovementValue = Input.GetAxisRaw("Horizontal");
        playerVerticalMovementValue = Input.GetAxisRaw("Vertical");

        if (isRunning && !isJumping)
        {
            groundMove = true;

        }
        else { groundMove = false; }


        if (groundMove)
        {
            playerParticleSystemRenderer.enabled = true;
            playerParticleSystem.Play();

        }
        else { playerParticleSystem.Play(); playerParticleSystemRenderer.enabled = false; }


        if (CanMove)
        {
            // If left mouse button is pressed, set RightClick animation parameter to true
            if (Input.GetMouseButton(0))
            {
                playerAnimator.SetBool("RightClick", true);

            }
            else { playerAnimator.SetBool("RightClick", false); }
        }

        if (playerHealth <= 0)
        {
            Die();
        }
<<<<<<< HEAD
=======

        


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



>>>>>>> parent of 6d13bab (BG, Particle effect)
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {

        Vector3 rangePosition = playerAttackRange.transform.position;
        playerAttackRange.transform.position = rangePosition;

        if (CanMove)
        {
            // Move the player horizontally and set the Speed animation parameter
            if (playerHorizontalMovementValue > 0.1f || playerHorizontalMovementValue < -0.1f)
            {
                PlayerRb2D.AddForce(new Vector2(playerHorizontalMovementValue * playerMovementSpeed, 0f), ForceMode2D.Impulse);
                playerAnimator.SetFloat("Speed", Mathf.Abs(playerHorizontalMovementValue));
                isRunning = true;

            }
            else { playerAnimator.SetFloat("Speed", 0); isRunning = false; }


            if (isJumping && isRunning)
            {
                playerAnimator.SetFloat("Height", 1);
                playerAnimator.SetFloat("Speed", 0);

            }
            else { playerAnimator.SetFloat("Height", 0); }

            if (isJumping)
            {
                playerAnimator.SetFloat("Height", 1);

            }
            else { playerAnimator.SetFloat("Height", 0); }

            // Move the playerAttackRange object based on the player's movement direction
            if (playerHorizontalMovementValue > 0.1f)
            {
                playerSpriteRenderer.flipX = false;
                rangePosition.x = transform.position.x + rangeSpaceFromPlayer;

            }
            else if (playerHorizontalMovementValue < -0.1f) { playerSpriteRenderer.flipX = true; rangePosition.x = transform.position.x - rangeSpaceFromPlayer; }


            if (!isJumping && playerVerticalMovementValue > 0.1f)
            {
                PlayerRb2D.AddForce(new Vector2(0f, playerVerticalMovementValue * playerJumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;

<<<<<<< HEAD
            if (isRunning)
            {
                groundMove = true;

            }
            else { groundMove = false; }

=======
            Debug.Log("Jumping");
>>>>>>> parent of 6d13bab (BG, Particle effect)
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = true;
<<<<<<< HEAD
            groundMove = false;
=======

            Debug.Log("not jumping");
>>>>>>> parent of 6d13bab (BG, Particle effect)
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if enough time has passed since the last damage
            if (Time.time - lastDamageRecievedTime > damageInterval)
            {

                playerHealth -= enemyDamageOnPlayer;
                lastDamageRecievedTime = Time.time;
                playerAnimator.SetBool("GetHit", true);

                Debug.Log("Player Is Getting Damaged");
            }
        }
        else
        {
            playerAnimator.SetBool("GetHit", false);
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
        {
            playerSpriteRenderer.color = Color.red;

        }
        else { playerSpriteRenderer.color = Color.white; }
    }

<<<<<<< HEAD
=======

>>>>>>> parent of 6d13bab (BG, Particle effect)
    void Die()
    {
        if (!hasDied)
        {
            hasDied = true;
<<<<<<< HEAD
            playerAnimator.SetBool("Dead", true);
            CanMove = false;

=======

            animator.SetBool("Dead", true);
            CanMove = false;



>>>>>>> parent of 6d13bab (BG, Particle effect)
            Debug.Log("player Died!");


        }


    }
<<<<<<< HEAD
}
=======





}
>>>>>>> parent of 6d13bab (BG, Particle effect)
