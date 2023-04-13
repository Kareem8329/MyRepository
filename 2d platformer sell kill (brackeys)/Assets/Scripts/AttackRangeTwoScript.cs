using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeTwoScript : MonoBehaviour
{
    // References to player and enemy GameObjects
    public GameObject enemy;
    public GameObject player;

    // Animator components for player and enemy GameObjects
    public Animator pAnimator;
    public Animator eAnimator;

    // PlayerMovementScript component for player GameObject
    public PlayerMovementScript pScript;

    // enemyScript component for enemy GameObject
    public enemyScript eScript;

    // Attack damage and range
    public int attackDamage = 40;
    public float attackRange = 1.5f;

    // Fetch references to components on start
    private void Start()
    {
        // Get the Animator component from the player GameObject
        pAnimator = player.GetComponent<Animator>();
        if (pAnimator == null)
        {
            Debug.LogError("AttackRangeTwoScript: Animator component not found on player GameObject!");
        }

        // Get the PlayerMovementScript component from the player GameObject
        pScript = player.GetComponent<PlayerMovementScript>();
        if (pScript == null)
        {
            Debug.LogError("AttackRangeTwoScript: PlayerMovementScript component not found on player GameObject!");
        }

        // Get the enemyScript component from the enemy GameObject
        eScript = enemy.GetComponent<enemyScript>();
        if (eScript == null)
        {
            Debug.LogError("AttackRangeTwoScript: enemyScript component not found on enemy GameObject!");
        }
    }

    // Check for attack input and apply damage to enemies within range
    void Update()
    {
        // Check for attack input and animation state
        if (Input.GetMouseButtonDown(0) && pAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            // Get all the enemies within the attack range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemies"));

            // Loop through all the enemies and apply damage to each one
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemyScript>().TakeDamage(attackDamage);
            }
        }
    }

    // Draw the attack range gizmo in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
