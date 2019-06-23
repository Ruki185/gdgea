using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float currentHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage (float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            if (currentHealth < 0)
                currentHealth = 0;

            if (currentHealth == 0)
            {
                //What to do?
                RestartScene();
            }
        }
    }

    void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
