using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch_Behavior : MonoBehaviour
{
    public Ch_HealthUI health;
    public GameObject explosionEffect;
    public Transform target;

    public float speed;
    public float ch_damage = 1;
    public float healthHit;
    public float maxHealthHit = 5;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthHit = maxHealthHit;
        health.SetHealth(healthHit, maxHealthHit);
    }


    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                 target.position, speed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            transform.up = direction;
        }
    }

    public void TakeHit(float damage)
    {
        healthHit -= damage;
        health.SetHealth(healthHit, maxHealthHit);
        if (healthHit <= 0)
        {
            Score_Behavior.score += 1;
            GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<P_Behavior>();
        if (player)
        {
            player.takeHit(ch_damage);
            GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            Destroy(gameObject);
        }
    }
}
