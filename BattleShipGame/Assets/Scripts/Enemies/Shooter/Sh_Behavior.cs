using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh_Behavior : MonoBehaviour
{
    public Sh_HealthUI health;
    public GameObject explosionEffect;
    public Transform target;

    //Shooter' ship deterioration
    private SpriteRenderer rend;
    public Sprite f_Life, m_Life, e_Life;

    public float speed;
    public float stopDistance;
    public float healthHit;
    public float maxHealthHit = 6;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthHit = maxHealthHit;
        health.setHealth(healthHit, maxHealthHit);

        rend = GetComponent<SpriteRenderer>();
        rend.sprite = f_Life;
    }

    
    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                                 target.position, speed * Time.deltaTime);
            }
            checkLife();
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(target.position.x - transform.position.x,
                                target.position.y - transform.position.y);
            transform.up = direction;
        }
    }

    public void takeHit(float damage)
    {
        healthHit -= damage;
        health.setHealth(healthHit, maxHealthHit);
        if(healthHit <= 0)
        {
            Score_Behavior.score += 1;
            GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 3f);
        }
    }

    //Change the shooter' sprite according to his life
    void checkLife()
    {
        if (healthHit <= 4 && healthHit > 2)
        {
            rend.sprite = m_Life;
        }else if (healthHit <= 2 && healthHit > 0)
        {
            rend.sprite = e_Life;
        }
    }
}
