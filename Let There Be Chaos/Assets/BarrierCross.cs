using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCross : MonoBehaviour
{
    public AudioClip Clip1;
    public AudioClip Clip2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<AudioSource>().clip = Clip1;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<AudioSource>().clip = Clip2;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
