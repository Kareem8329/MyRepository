using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject target;  // The target game object
    public float speed;  // The speed at which the enemy moves towards the target
    public int Health = 100;  // The enemy's health

    public int enemyKillCount;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public Collider2D box;
    bool CanMove;
    bool isDead = false;
    bool hasDied = false;

    [CanBeNull]
    public GameObject newEnemy;


    public MoneyScript money;

    
    // The Start method is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        CanMove = true;
        


        newEnemy = GameObject.FindGameObjectWithTag("Enemy");

        money = FindObjectOfType<MoneyScript>();
        if (money == null)
        {
            Debug.LogError("MoneyScript component not found!");
        }
        else
        {
            enemyKillCount = money.GetComponent<MoneyScript>().enemyKillcount;
        }

    }

    // This method is called when the enemy takes damage
    public void TakeDamage(int attackDamage)
    {
        Health = Health - attackDamage;
        // TODO: Play the hurt animation
        Debug.Log("enemy is being damaged");

            
    }

    // This method is called when the enemy dies
    void Die()
    {
        if (!hasDied)
        {
            hasDied = true;
            isDead = true;
            animator.SetBool("Dead", true);
            CanMove = false;

            Physics2D.IgnoreCollision(box, target.GetComponent<Collider2D>());

            if (newEnemy != null)
            {
                Physics2D.IgnoreCollision(box, newEnemy.GetComponent<Collider2D>());
            }

            money.GetComponent<MoneyScript>().enemyKillcount++;

            Debug.Log("Enemy Died!");

            if (isDead)
            {
                Destroy(gameObject, 10f);
            }
        }


    }


    public bool playerDead;

    // The Update method is called once per frame
    void Update()
    {
        playerDead = target.GetComponent<PlayerMovementScript>().hasDied;

        if (playerDead)
        {
            animator.SetBool("Idle", true);
        }

        if (!playerDead)
        {


            if (target.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }


            if (CanMove)
            {
                Vector2 targetPosition = target.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            }


            if (Health <= 0)
            {
                Die();
            }


            

        }


    }
}
