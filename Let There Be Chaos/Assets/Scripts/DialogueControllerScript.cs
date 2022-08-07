using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueControllerScript : MonoBehaviour
{   
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int index = 0;
    public float DialogueSpeed;

    public Animator DialogueAnimator;
    private bool StartDialogue = true;

    void Start()
    {
        NextSentence();
    }
    void Update()
    {
        //we can make a simple chat box once i click on the button it show the dialogue box
        //and make button on  dialogue box once it is pressed it exits the dialogue box
        //for now i will make when spacebar is pressed
        //i need to make this pop at the start of the game 
        // i need to generalize more this dialogue box in order to make it usable every were
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if(index <= Sentences.Length -1)
        {
            DialogueText.text = string.Empty;
            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("Exit");
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char c in Sentences[index].ToCharArray())
        {
            DialogueText.text +=c;
            yield return new WaitForSeconds(DialogueSpeed);
            if(Input.GetKeyDown(KeyCode.Space))
                break;
        }
        index++;
    }
}
