using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ParallelBullet : MonoBehaviour
{
    //fPoint = fire point / L = Left <-> R = Right
    public Transform fPointL1, fPointL2, fPointL3, fPointR1, fPointR2, fPointR3;
    public GameObject bulletPrefab;

    public float bulletForce = 10f;
    float cooldownTime = 5, fireTime = 0;

    void Update()
    {
        if (Time.time > fireTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !MapManager.isPaused && !MapManager.byTime)
            {
                P_Shoot();
                fireTime = Time.time + cooldownTime;
            }
        }
    }

    void P_Shoot()
    {
        GameObject bulletL1 = Instantiate(bulletPrefab, fPointL1.position, fPointL1.rotation);
        GameObject bulletL2 = Instantiate(bulletPrefab, fPointL2.position, fPointL2.rotation);
        GameObject bulletL3 = Instantiate(bulletPrefab, fPointL3.position, fPointL3.rotation);

        GameObject bulletR1 = Instantiate(bulletPrefab, fPointR1.position, fPointR1.rotation);
        GameObject bulletR2 = Instantiate(bulletPrefab, fPointR2.position, fPointR2.rotation);
        GameObject bulletR3 = Instantiate(bulletPrefab, fPointR3.position, fPointR3.rotation);

        Rigidbody2D rbL1 = bulletL1.GetComponent<Rigidbody2D>();
        Rigidbody2D rbL2 = bulletL2.GetComponent<Rigidbody2D>();
        Rigidbody2D rbL3 = bulletL3.GetComponent<Rigidbody2D>();

        Rigidbody2D rbR1 = bulletR1.GetComponent<Rigidbody2D>();
        Rigidbody2D rbR2 = bulletR2.GetComponent<Rigidbody2D>();
        Rigidbody2D rbR3 = bulletR3.GetComponent<Rigidbody2D>();

        rbL1.AddForce(fPointL1.up * bulletForce, ForceMode2D.Impulse);
        rbL2.AddForce(fPointL2.up * bulletForce, ForceMode2D.Impulse);
        rbL3.AddForce(fPointL3.up * bulletForce, ForceMode2D.Impulse);

        rbR1.AddForce(fPointR1.up * bulletForce, ForceMode2D.Impulse);
        rbR2.AddForce(fPointR2.up * bulletForce, ForceMode2D.Impulse);
        rbR3.AddForce(fPointR3.up * bulletForce, ForceMode2D.Impulse);
    }
}
