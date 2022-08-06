using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public float score = 50f;
    // public GameObject player = null;
    public PlayerScore playerVars;     // To access score variable
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
        // get el component el 3ayzo
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        playerVars.score += score;
    }
}
