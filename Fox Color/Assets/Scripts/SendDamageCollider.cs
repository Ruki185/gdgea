using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamageCollider : MonoBehaviour
{
    public int damageValue = 1;
    public string tag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == tag)
        other.gameObject.SendMessage("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
    }
}
