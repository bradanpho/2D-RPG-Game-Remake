using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
