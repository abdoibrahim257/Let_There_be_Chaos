using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Vector2 Offset = new Vector2(0,0);       // value of offset from camera position
    public float randomRangeStart = 0f;             // generate random value starting from this value
    public float randomRangeEnd = 0f;               // till this value
    [SerializeField] GameObject[] spawnedObject;                // Array of objects being spawned
    public GameObject referenceObject;              // the object that will spawn other objects

    private float xCoordinate;                      // x and y Coordinates of 
    private float yCoordinate;
    int counter = 0;                                // counter for the spawnedObject array, to traverse the array
    // public Camera Camera;

    // Update is called once per frame
    private void Update()
    {
        float randomX = UnityEngine.Random.Range(randomRangeStart, randomRangeEnd);
        float randomY = UnityEngine.Random.Range(randomRangeStart, randomRangeEnd);
        xCoordinate = referenceObject.transform.position.x;
        yCoordinate = referenceObject.transform.position.y;
        transform.position = new Vector3(xCoordinate + Offset.x + randomX, yCoordinate + Offset.y + randomY, transform.position.z);
        // spawns object with camera position, offset by a certain value
    }

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
   
}
