using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Slider healthSlider;

    [Header("Offset Above Enemy")]
    [SerializeField] private Vector3 offset = new Vector3(0, 1.0f, 0);

    private Transform targetTransform;
    private Vector3 initialScale;

    void Start()
    {
        // Auto-assign if not manually set
        if (enemyHealth == null)
            enemyHealth = GetComponentInParent<EnemyHealth>();

        if (healthSlider == null)
            healthSlider = GetComponentInChildren<Slider>();

        if (enemyHealth == null || healthSlider == null)
        {
            Debug.LogError("FloatingHealthBar: Missing enemyHealth or healthSlider.");
            enabled = false;
            return;
        }

        targetTransform = enemyHealth.transform;
        healthSlider.maxValue = enemyHealth.GetMaxHealth();
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        if (enemyHealth == null || healthSlider == null) return;

        // Follow the enemy
        transform.position = targetTransform.position + offset;

        // Prevent flipping
        transform.rotation = Quaternion.identity;
        transform.localScale = initialScale;

        // Update health
        healthSlider.value = enemyHealth.GetCurrentHealth();
    }
}
