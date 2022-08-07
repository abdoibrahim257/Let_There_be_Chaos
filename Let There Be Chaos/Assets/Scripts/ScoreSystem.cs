using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float score = 10f;
    private GameObject player = null;
    private PlayerScore playerVars;     // To access score variable
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        // kda bshawer 3l player
        // get el component el 3ayzo
        playerVars = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        playerVars.score += score;      // byzwd score el object 3l player
    }
}
