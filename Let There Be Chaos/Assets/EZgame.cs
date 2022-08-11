using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;          // added to control scene management

public class EZgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Noice()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%3);   // hyen2elo lel scene el 2a5eer
        // Debug.Log($"2a5er level {(SceneManager.GetActiveScene().buildIndex + 1)%3}");
    }
}
