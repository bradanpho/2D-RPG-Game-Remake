using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;
    private Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private playerMovement movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<playerMovement>();

        // Ensure attackPoint is assigned in the Inspector
        if (attackPoint == null)
        {
            Debug.LogError("Error: AttackPoint is not assigned! Please assign it in the Inspector.");
        }
    }

    void Update()
    {
        // Left Mouse Button = 0
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            animator.SetBool("isAttacking", true);
            Attack();
        }
    }

    void Attack()
    {
        Vector2 attackDirection = movement.LastMoveDir.normalized; // Ensure direction updates
        Debug.Log("Attack Direction: " + attackDirection); // Debugging output

        Vector2 newAttackPos = (Vector2)transform.position + attackDirection * attackRange;
        attackPoint.position = newAttackPos;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            // enemy.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void attackEnd()
    {
        animator.SetBool("isAttacking", false);
    }
}
