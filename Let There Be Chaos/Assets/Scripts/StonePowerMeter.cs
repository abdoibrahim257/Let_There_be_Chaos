using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePowerMeter : MonoBehaviour
{
    private int collectedStones = 0;
    // Start is called before the first frame update
    void Start()
    {
        collectedStones = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Stones = {collectedStones}");
        if (collectedStones >= 6)
        {
            // hngeblo dialogue box, w n5leeh yerga3 bl zaman le abl ma ykasar el level
            // hyroo7 ykasar el asteroid bl nuke bta3o xD w yenkez kawkab el 2ard abl ma 
            // Kaw el so8yr yetla3 mn el 2ard
        }
    }
    public void AddStone()
    {
        if (collectedStones < 6)
        {
            collectedStones++;
        }
    }
}
