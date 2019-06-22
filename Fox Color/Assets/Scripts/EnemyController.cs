using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        print(this.transform.gameObject.layer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.checkHealth();
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
