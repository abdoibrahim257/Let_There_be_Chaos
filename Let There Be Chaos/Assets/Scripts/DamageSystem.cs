using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(gameObject.CompareTag("Asteroids") && other.collider.CompareTag("Player"))
        {
            // this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            // //impulse effect on the player
            Vector3 hitVector = (other.gameObject.transform.position - transform.position).normalized; //this part will make impulse effect on player
            hitVector = (other.gameObject.transform.position - transform.position);                     // we can alter the force of impact according to game
            // hitVector.y = 0;
            hitVector = hitVector.normalized ;
            other.rigidbody.AddForce(hitVector * 10000 );

        }

        if(other.transform.GetComponent<HealthSystem>())
        {
            other.transform.GetComponent<HealthSystem>().health -= damage;
            // lw hn3ml effect lel 5abta hn7oto hena
            if (!(other.collider.CompareTag("Player") || other.collider.CompareTag("Enemy")))   // doesn't destroy object in case it hits player or enemy
            {
                Destroy(gameObject);
            }
                
            // effect = Instantiate(el effect);
            // Destroy(el effect, b3d shwyt wa2t)
        }
    }
}
