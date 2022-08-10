using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D player) {
        if(player.gameObject.CompareTag("Player"))  // el player 5abatny
        {
            player.gameObject.GetComponent<StonePowerMeter>().AddStone();   // adds a stone to the player's gauntlet
            Destroy(gameObject);        // destroys stone 
        }
    }
}
