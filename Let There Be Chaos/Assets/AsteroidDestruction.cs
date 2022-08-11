using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AsteroidDestruction : MonoBehaviour
{
    public UnityEvent HappyKaw; //refrencing the dialogue box so that we can trigger it 
    bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy() {
        if (firstTime)
        {
            HappyKaw?.Invoke(); //refrencing the dialogue box so that we can trigger it 
        }
    }
    
}
