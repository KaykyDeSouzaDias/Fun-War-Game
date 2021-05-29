using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Behavior : MonoBehaviour
{
    public P_HealthUI health;
    public GameObject explosionEffect;
    public Rigidbody2D rb;
    public Camera cam;

    private SpriteRenderer rend;
    public Sprite f_Life, m_Life, e_Life;

    Vector3 mP;

    public float PlayerSpeed = 5f;
    public float healthHit;
    public float maxHealthHit = 6;


    void Start()
    {
        healthHit = maxHealthHit;
        health.setHealth(healthHit, maxHealthHit);

        rend = GetComponent<SpriteRenderer>();
        rend.sprite = f_Life;
    }

    void Update()
    {
        //mP = mouse position
        mP = cam.ScreenToWorldPoint(Input.mousePosition);
        Move();
    }

    void FixedUpdate()
    {
        //D = player's direction
        Vector2 D = new Vector2(mP.x - rb.position.x, mP.y - rb.position.y);
        transform.up = D;
        checkLife();
    }

    public void takeHit(float damage)
    {
        healthHit -= damage;
        health.setHealth(healthHit, maxHealthHit);
        if(healthHit <= 0)
        {
            GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 3f);
            MapManager.byDeath = true;
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(0, PlayerSpeed * Time.deltaTime, 0);
        }
    }

    //Change the player' sprite according to his life
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
