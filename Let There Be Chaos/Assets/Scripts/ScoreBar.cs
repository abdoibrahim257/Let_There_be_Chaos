using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public PlayerScore playerScore;
    public Image fillImage;
    private Slider slider;
    private float fillValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)    // byetfy el fill image lama el health yewsal 0
        {
            fillImage.enabled = false;
        }
        else
        {
            fillImage.enabled = true;
        }
        
        if(playerScore.scoreIndex.Length - playerScore.index - 2 < 0)   // y3ny wslt 2a5er level
        {
            fillValue = 1f;
        }
        else
        {
            fillValue = (playerScore.score - playerScore.scoreIndex[playerScore.scoreIndex.Length - playerScore.index - 1])
            / (playerScore.scoreIndex[playerScore.scoreIndex.Length - playerScore.index - 2] - playerScore.scoreIndex[playerScore.scoreIndex.Length - playerScore.index - 1]);
            // basically, fillValue = (el score bta3y - levely) / (el level el gy - levely)
            // levely el howa el score bta3 el sela7 el ana gebto

        }
        slider.value = fillValue;
    }
}
