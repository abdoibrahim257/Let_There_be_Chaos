using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueControllerScript : MonoBehaviour
{   
    public TextMeshProUGUI DialogueText;
    // public GameObject button;

    public string[] Sentences;
    private int index = 0;
    public float DialogueSpeed;

    public Animator DialogueAnimator;
    private bool first = true;
    // private bool StartDialogue = true;

    public UnityEvent Event;
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
        if(first && Input.GetKeyDown(KeyCode.Space))
        {
            first = false;
            NextSentence();
        }
    }

    public void NextSentence()
    {
        // button.SetActive(false);
        if(index <= Sentences.Length -1)
        {
            DialogueText.text = string.Empty;
            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("Exit");
            Event?.Invoke();
            Destroy(gameObject);
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char c in Sentences[index].ToCharArray())
        {
            DialogueText.text +=c;
            yield return new WaitForSeconds(DialogueSpeed);
            if(!first && Input.GetKeyDown(KeyCode.Space))
            {
                first = true;
                // Debug.Log("sh8ala");
                break;
            }
        }
        DialogueText.text = Sentences[index];
        first = true;
        index++;
        // button.SetActive(true);
    }
}
