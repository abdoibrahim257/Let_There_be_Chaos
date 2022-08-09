using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool firstTime = true;
    // public Vector3 respawnPoint;
    private Vector3 respawnPoint;

    // public DeathRespawn playerVars;         // To access some variables
    // Start is called before the first frame update
    void Start()
    {
        // respawnPoint = gameObject.transform.position;       // el respawn point btb2a makan el check point
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
       if (firstTime && obj.gameObject.CompareTag("Player"))
       {
            respawnPoint = obj.transform.position;                              // el makan elly el player kan wa2ef fyh lama da5al el radius
            firstTime = false;                                                  // 3lshan my3adeesh 3la nafs el checkpoint mrtein
            obj.GetComponent<HealthSystem>().respawnPoint = respawnPoint;       // changes respawning point of player
       }
    }
}
