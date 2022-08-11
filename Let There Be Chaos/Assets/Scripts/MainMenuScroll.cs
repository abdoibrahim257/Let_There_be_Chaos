using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScroll : MonoBehaviour
{
    public float			theScrollSpeed = 0.025f;

	Transform 				theCamera;
    // private Transform oldPosition;
    int i = 1;

	void Start () 
	{
        // oldPosition = Camera.main.transform;	
		theCamera = Camera.main.transform;	
	}
	
	void Update ()
	{
        i*=-1;
        theCamera.position = new Vector3 ( theCamera.position.x, theCamera.position.y + theScrollSpeed * i, theCamera.position.z );
        
//		theCamera.position = new Vector3 ( theCamera.position.x + theScrollSpeed, theCamera.position.y, theCamera.position.z );
	}
}
