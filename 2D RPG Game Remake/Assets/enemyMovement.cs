using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 _lastMoveDir;
    private Transform playerTarget; // Reference to the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag("Player")?.transform; // Find the player safely
    }

    void Update()
    {
        if (playerTarget != null)
        {
            MoveTowardsPlayer();
            UpdateAnimation();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate direction toward the player
        Vector2 direction = (playerTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Update last move direction only if moving
        if (rb.velocity.magnitude > 0.1f) // Prevent unwanted resetting
        {
            _lastMoveDir = rb.velocity.normalized;
        }

        // Flip sprite correctly based on movement direction
        if (_lastMoveDir.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing right
        }
        else if (_lastMoveDir.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing left
        }
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("mobInputX", rb.velocity.x);
        animator.SetFloat("mobInputY", rb.velocity.y);
        animator.SetFloat("mobLastInputX", _lastMoveDir.x);
        animator.SetFloat("mobLastInputY", _lastMoveDir.y);
        animator.SetBool("isMoving", rb.velocity.magnitude > 0);
    }
}
