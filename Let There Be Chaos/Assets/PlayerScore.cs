using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score = 0f;
    public GunShoot gunVars;         // To access some variables
    public KawShoot playerVars;               // To access some variables
    public GameObject rocket;                // Storing the missile prefab
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 1000f)
        {
            // akwa weapon
        }
        else if (score >= 500f)
        {
            // tany akwa weapon
            gunVars.shotType = rocket;        // 8ayar el prefab
            

        }
        
    }
}
