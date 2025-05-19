using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    [SerializeField] private float attackCooldown = 0.4f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        animator.SetTrigger("isAttacking");

        // Optional: disable movement during attack
        GetComponent<playerMovement>().enabled = false;

        // Wait for the animation to finish or cooldown
        yield return new WaitForSeconds(attackCooldown);

        // Re-enable movement
        GetComponent<playerMovement>().enabled = true;

        isAttacking = false;
    }
    public void attackEnd()
    {
        // Called by animation event at the end of attack animation
        GetComponent<playerMovement>().enabled = true;  // Re-enable movement if you disabled it
        isAttacking = false;
    }

}
