using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           // 3lshan ast3ml el events

public class KawShoot : MonoBehaviour
{
    [Header("Custom Event")]            // 3lshan ast3ml el events
    public UnityEvent customEvent;

    public float attackRate = 2f;       // y2dr y3ml kam attack fl sanya
    
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButton("Fire1"))
            {
                // void Shoot();
                customEvent.Invoke();       // To invoke the event(s)
                // Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
