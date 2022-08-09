using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class PlanetsManager : MonoBehaviour
{
    public GameObject barrier;
    private bool firstTime = true;
    private bool alsoFirstTime = true;
    public UnityEvent Missing; //refrencing the dialogue box so that we can trigger it 
    public UnityEvent Missing2; //refrencing the dialogue box so that we can trigger it 

    void Update()
    {
        if (!transform.Find("Mercury") && !transform.Find("Venus") && !transform.Find("Mars") && firstTime)
        {
            barrier.GetComponent<TilemapCollider2D>().enabled = false;
            transform.Find("Earth").GetComponent<Planet>().enabled = true;
            firstTime = false;
            Missing?.Invoke();
        }
        if (alsoFirstTime && !transform.Find("Mercury") && !transform.Find("Venus") && !transform.Find("Mars") && !transform.Find("Jupiter") && !transform.Find("Saturn") && !transform.Find("Uranus") && !transform.Find("Neptune") && !transform.Find("Pluto"))
        {
            alsoFirstTime = false;
            transform.Find("Earth").GetComponent<HealthSystem>().enabled = true;
            Missing2?.Invoke();
        }
    }
}
