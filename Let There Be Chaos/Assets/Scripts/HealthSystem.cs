using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;          // added to control scene management

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public GameObject DestroyEffect;
    public Vector3 respawnPoint;       // where to spawn upon death
    public float cameraShakeIntensity = 0;
    public float cinemachineShakeDuration = 0;

    public UnityEvent<float, float> onPlanetDesttuction;

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
            if (gameObject.CompareTag("GoodEarth"))     // the earth that needs to be protected from asteroids
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // hy3eed el scene
                Destroy(gameObject);
            }
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
            else    // ay 7aga 8eir el player
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    gameObject.transform.parent.GetComponent<Planet>().counter--;
                }
                // if (gameObject.CompareTag("Planet")) // lw 3ayzeen kol ma planet mo3yn ytksr, y3ml instantiate lel stone
                onPlanetDesttuction?.Invoke(cameraShakeIntensity, cinemachineShakeDuration);
                Destroy(gameObject);
                if (DestroyEffect)      // lw fy destroy effect, e3mlo instantiate
                {
                    GameObject effect = Instantiate(DestroyEffect, transform.position, Quaternion.identity);
                    effect.GetComponent<AudioSource>()?.Play();
                }
            }
        }
    }
}
