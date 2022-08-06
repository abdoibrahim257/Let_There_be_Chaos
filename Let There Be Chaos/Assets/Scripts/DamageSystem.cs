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
        if(other.transform.GetComponent<HealthSystem>())
        {
            other.transform.GetComponent<HealthSystem>().health -= damage;
            // lw hn3ml effect lel 5abta hn7oto hena
            Destroy(gameObject);
            // effect = Instantiate(el effect);
            // Destroy(el effect, b3d shwyt wa2t)
        }
    }
}
