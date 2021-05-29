using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DirectBullet : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    public float bulletForce = 10f;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !MapManager.isPaused && !MapManager.byTime)
        {
            D_Shoot();
        }
    }

    void D_Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
