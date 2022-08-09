using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlanetsManager : MonoBehaviour
{
    public GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.Find("Mercury") && !transform.Find("Venus") && !transform.Find("Mars"))
        {
            barrier.GetComponent<TilemapCollider2D>().enabled = false;
            transform.Find("Earth").GetComponent<Planet>().enabled = true;
        }

        if (!transform.Find("Mercury") && !transform.Find("Venus") && !transform.Find("Mars") && !transform.Find("Jupiter") && !transform.Find("Saturn") && !transform.Find("Uranus") && !transform.Find("Neptune") && !transform.Find("Pluto"))
        {
            transform.Find("Earth").GetComponent<HealthSystem>().enabled = true;
        }
    }
}
