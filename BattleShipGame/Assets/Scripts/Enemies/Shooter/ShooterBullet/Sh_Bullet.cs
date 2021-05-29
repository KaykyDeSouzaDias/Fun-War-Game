using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh_Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Sh_Behavior shooter;

    public float bulletForce = 10f;
    float fireRate, nextFire;

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }


    void Update()
    {
        if (shooter.target != null)
        {
            if (Vector2.Distance(shooter.transform.position, shooter.target.position) <= shooter.stopDistance)
            {
                if (Time.time > nextFire)
                {
                    sh_Shoot();
                    nextFire = Time.time + fireRate;
                }
            }
        }
    }

    void sh_Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
