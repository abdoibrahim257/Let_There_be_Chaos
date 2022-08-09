using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public GameObject DestroyEffect;
    public Vector3 respawnPoint;       // where to spawn upon death

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
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
                transform.position = respawnPoint;      //  yt3mlo respawn fy 7eta
                // momkn n2alel el score brdo lw 3ayzeen
                gameObject.GetComponent<PlayerScore>().score -= 200f;
                if (gameObject.GetComponent<PlayerScore>().score < 0)
                {
                    gameObject.GetComponent<PlayerScore>().score = 0f;
                }
            }
            else
            {
                Destroy(gameObject);
                if (DestroyEffect)      // lw fy destroy effect, e3mlo instantiate
                {
                    GameObject effect = Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
