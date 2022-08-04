using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player"))        // player respawn upon death
            {
                health = maxHealth;
                //  yt3mlo respawn fy 7eta
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
