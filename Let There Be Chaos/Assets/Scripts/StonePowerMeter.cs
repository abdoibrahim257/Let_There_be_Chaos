using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;          // added to control scene management
using UnityEngine.Events;

public class StonePowerMeter : MonoBehaviour
{
    public UnityEvent SadKaw; //refrencing the dialogue box so that we can trigger it 
    public int collectedStones = 0;
    bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        collectedStones = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Stones = {collectedStones}");
        if (firstTime && collectedStones >= 6)
        {
            // hngeblo dialogue box, w n5leeh yerga3 bl zaman le abl ma ykasar el level
            // hyroo7 ykasar el asteroid bl nuke bta3o xD w yenkez kawkab el 2ard abl ma 
            // Kaw el so8yr yetla3 mn el 2ard
            SadKaw?.Invoke();
            firstTime = false;
            
        }
    }
    public void AddStone()
    {
        if (collectedStones < 6)
        {
            collectedStones++;
        }
    }
    public void StoneTimeTravel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // hyen2elo lel scene el 2a5eer
    }
}
