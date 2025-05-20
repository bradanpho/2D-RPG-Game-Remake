using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 0.5f;
    public int bulletDamage = 10; // Set bullet damage

    private void OnCollisionEnter2D(Collision2D collision) // Fix capitalization
    {
        // Check if bullet hit an enemy
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage); // Apply damage
        }

        Destroy(gameObject); // Destroy bullet on impact
    }

    private void Awake()
    {
        StartCoroutine(RemoveProjectile(destroyDelay));
    }

    IEnumerator RemoveProjectile(float delayVar)
    {
        yield return new WaitForSeconds(delayVar);
        Destroy(gameObject);
    }
}
