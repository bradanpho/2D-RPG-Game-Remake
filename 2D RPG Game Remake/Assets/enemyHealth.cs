using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        Debug.Log($"Enemy HP: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Destroy(gameObject, 0.5f);
    }

    // Expose health values for the UI script
    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
