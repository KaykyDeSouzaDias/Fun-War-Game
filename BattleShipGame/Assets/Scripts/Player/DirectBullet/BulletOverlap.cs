using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOverlap : MonoBehaviour
{
    public GameObject hitEffect;

    bool itCollided;
    public float p_Damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        itCollided = true;

        var chaser = collision.collider.GetComponent<Ch_Behavior>();
        if (chaser)
        {
            chaser.TakeHit(p_Damage);
        }

        var shooter = collision.collider.GetComponent<Sh_Behavior>();
        if (shooter)
        {
            shooter.takeHit(p_Damage);
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }

    void Update()
    {
        if (itCollided == false)
        {
            Destroy(gameObject, 1f);
        }
    }
}
