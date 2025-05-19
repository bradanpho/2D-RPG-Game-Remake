using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    private playerMovement playerMovement; // Reference to movement script

    [SerializeField] private float attackCooldown = 0.4f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovement>(); // Get movement component
    }

    void Update()
    {
        // Check if left mouse button is pressed this frame
        if (Mouse.current.leftButton.wasPressedThisFrame && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;

        // Get last movement direction for attack
        Vector2 attackDirection = playerMovement.LastMoveDir;

        // Assign values to Blend Tree parameters
        animator.SetFloat("attackX", attackDirection.x);
        animator.SetFloat("attackY", attackDirection.y);

        // Trigger attack animation
        animator.SetTrigger("isAttacking");

        // Optional: disable movement during attack
        GetComponent<playerMovement>().enabled = false;

        yield return new WaitForSeconds(attackCooldown);

        // Re-enable movement
        GetComponent<playerMovement>().enabled = true;
        isAttacking = false;
    }
    public void attackEnd()
    {
        GetComponent<playerMovement>().enabled = true;
        isAttacking = false;
    }

}
