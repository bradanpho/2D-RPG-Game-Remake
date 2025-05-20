using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;

    public System.Action OnDeath; // ✅ THIS LINE IS ESSENTIAL

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke(); // ✅ CALL THIS!

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Destroy(gameObject, 0.5f);
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
