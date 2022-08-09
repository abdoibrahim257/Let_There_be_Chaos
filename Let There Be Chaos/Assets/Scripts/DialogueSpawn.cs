using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSpawn : MonoBehaviour
{
    public Animator DialogueAnimator;
    public GameObject parent;
    public UnityEvent onEnter;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player"))
        {
            DialogueAnimator.SetTrigger("pop"); //show box, but we need to make asteroids spawn later than that so player can read the box
            onEnter?.Invoke();
            Destroy(gameObject);
        }    
    }
}
