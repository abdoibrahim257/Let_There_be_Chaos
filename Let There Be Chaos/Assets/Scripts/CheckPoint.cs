using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    private bool firstTime = true;
    private bool firstTime2 = true;
    // public Vector3 respawnPoint;
    private Vector3 respawnPoint;
    public GameObject parent;
    public TextMeshProUGUI RegionBox;
    public Animator regionBoxAnimator;

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
       if(firstTime2 && obj.gameObject.CompareTag("Player"))
       {
            RegionBox.text =  parent.name + " Atmosphere";
            regionBoxAnimator.SetTrigger("pop");
            firstTime2 = false;
       }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        
        if(!firstTime2 && other.gameObject.CompareTag("Player"))
        {
            RegionBox.text = "Outer Space";
            regionBoxAnimator.SetTrigger("pop");
            firstTime2 = true;
        }
    }
}
