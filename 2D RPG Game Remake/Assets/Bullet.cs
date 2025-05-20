using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 0.0f;

    private void OncollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
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
