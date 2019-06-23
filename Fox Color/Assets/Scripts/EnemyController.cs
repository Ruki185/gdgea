using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private int health;
    public int enemyid;
    public float speed = 1;
    bool goup = true;
    public float goupheight = 5;
    private float standardyposition;

    // Start is called before the first frame update
    void Start()
    {
        standardyposition = transform.position.y;
        print(this.transform.gameObject.layer);
        WhatEnemy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.checkHealth();
        EnemyMovement();
    }

    void WhatEnemy()
    {
        if (enemyid == 0)
        {
            health = 1;
        }

        else if(enemyid == 1)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.blue;
            health = 3;
        }

        else if (enemyid == 2)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.green;
            health = 3;
        }

        else if (enemyid == 3)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red;
            health = 3;
        }
        else if (enemyid == 4)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.blue;
            health = 10;
        }
        else
        {
            health = 1;
        }
    }

    void EnemyMovement()
    {

        if (enemyid == 1)
        {
            transform.Translate(0, 0, speed*Time.deltaTime);
        }

        else if (enemyid == 2)
        {
            if (goup)
            {
                transform.Translate(0, speed*Time.deltaTime, 0, Space.World);
                if (transform.position.y > goupheight)
                {
                    goup = false;
                }
            }
            else
            {
                transform.Translate(0, -speed*Time.deltaTime, 0, Space.World);
                if (transform.position.y <= standardyposition)
                {
                    goup = true;
                }
            }
        }

        else if (enemyid == 3)
        {
            
        }
        else if (enemyid == 4)
        {
            
        }
    }

    void checkHealth()
    {
        if (this.health < 1)
        {
            Destroy(this.transform.gameObject);
        }
    }

    void DamageHandler(Color orbColor)
    {
        if (this.transform.gameObject.GetComponent<SpriteRenderer>().color != orbColor)
        {
            this.health--;
        }
    }
}
