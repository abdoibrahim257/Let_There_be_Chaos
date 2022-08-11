using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShot : MonoBehaviour
{
    // el particle shot dyh bta3t el player bs
    // el enemy h3mlo particle shot mo5tlfa


    public GameObject hitEffect = null;
    [SerializeField] private float SecondsToDestroy = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, SecondsToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // bn-instantiate el hit effect, w bn3mlo store fy object, 3lshan n3mlo destroy b3deeha
            Destroy(effect, 2f);    // bn3ml destroy bs b3deeha b 0.41 seconds
        }
        Destroy(gameObject);    // bn3ml destroy lel bullet

    }
}
