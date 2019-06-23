using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        print("foo" + obj.name);
        obj.SendMessage("DamageHandler", this.transform.gameObject.GetComponent<SpriteRenderer>().color);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.transform.gameObject);
    }
}
