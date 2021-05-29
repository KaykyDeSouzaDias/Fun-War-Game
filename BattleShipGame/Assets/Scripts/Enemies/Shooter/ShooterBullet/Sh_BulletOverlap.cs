using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh_BulletOverlap : MonoBehaviour
{
    public GameObject hitEffect;

    bool itCollided;
    public float sh_Damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        itCollided = true;

        var player = collision.collider.GetComponent<P_Behavior>();
        if (player)
        {
            player.takeHit(sh_Damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (itCollided == false)
        {
            Destroy(gameObject, 1f);
        }
    }
}
