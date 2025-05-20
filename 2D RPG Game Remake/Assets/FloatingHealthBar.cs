using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    public Slider healthBar;
    private EnemyHealth enemyHealth;
    public Transform enemy; // Assign enemy manually in Inspector
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Adjust position above enemy

    void Start()
    {
        if (enemy == null)
        {
            enemy = GetComponentInParent<EnemyHealth>()?.transform;

            if (enemy == null)
            {
                Debug.LogError("HealthBarUI: Enemy reference is still missing! Ensure the health bar is placed inside the enemy's hierarchy.");
            }
        }

        enemyHealth = enemy?.GetComponent<EnemyHealth>();

        if (enemyHealth != null && healthBar != null)
        {
            healthBar.maxValue = enemyHealth.GetMaxHealth();
            healthBar.value = enemyHealth.GetCurrentHealth();
            healthBar.gameObject.SetActive(true); // Ensure UI is enabled
        }
    }



    void Update()
    {
        if (enemyHealth != null && healthBar != null)
        {
            healthBar.value = enemyHealth.GetCurrentHealth();
            Debug.Log($"Health Bar UI Updated: {healthBar.value}"); // Debugging feedback
        }

        // Ensure health bar follows enemy but does not rotate
        if (enemy != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(enemy.position + offset);
            transform.rotation = Quaternion.identity; // Lock rotation
        }
    }
}
