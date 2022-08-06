using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Vector2 Offset = new Vector2(0,0);       // value of offset from camera position
    public float randomOffsetRangeStart = 0f;             // generate random value starting from this value
    public float randomOffsetRangeEnd = 0f;               // till this value
    public float randomAngleRangeStart = 0f;             // generate random value starting from this value
    public float randomAngleRangeEnd = 0f;               // till this value
    [SerializeField] GameObject[] spawnedObject;                // Array of objects being spawned
    public GameObject referenceObject;              // the object that will spawn other objects
    public float spawnRate = 1f;                         // spawn n objects each second
    float nextSpawn = 0f;
    public float fireForce = 40f;                          // force by which object is thrown

    private float xCoordinate;                      // x and y Coordinates of 
    private float yCoordinate;
    int counter = 0;                                // counter for the spawnedObject array, to traverse the array
    // public Camera Camera;

    // Update is called once per frame
    private void Update()
    {
        float randomX = UnityEngine.Random.Range(randomOffsetRangeStart, randomOffsetRangeEnd);
        float randomY = UnityEngine.Random.Range(randomOffsetRangeStart, randomOffsetRangeEnd);
        float randomAngle = UnityEngine.Random.Range(randomAngleRangeStart, randomAngleRangeEnd);
        xCoordinate = referenceObject.transform.position.x;
        yCoordinate = referenceObject.transform.position.y;
        transform.position = new Vector3(xCoordinate + Offset.x + randomX, yCoordinate + Offset.y + randomY, transform.position.z);
        transform.rotation = Quaternion.Euler(Vector3.forward * randomAngle);
        // Vector3 spawnedRotation = new Vector3 (0f, 0f, randomAngle);
        // Vector3 spawnedRotation = new Vector3 (45f, 0f, 0f);
        // spawns object with camera position, offset by a certain value
        // Quaternion.Euler(spawnedRotation)
        if (Time.time > nextSpawn)
        {
            GameObject spawned = Instantiate(spawnedObject[counter], transform.position, Quaternion.identity);
            spawned.GetComponent<Rigidbody2D>().AddForce(this.transform.up * fireForce, ForceMode2D.Impulse);
            counter++;
            counter %= spawnedObject.Length;
            nextSpawn = Time.time + 1.0f / spawnRate;
        }
    }

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
   
}
