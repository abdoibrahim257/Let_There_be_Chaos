using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int PlanetIndex;
    public GameObject spawnobj;
    private Vector2 spawnspot;
    private Vector2 origin;
    private float spawntimer = 0;
    public float SpawnCooldown = 5;
    public float DetectRadius = 400;
    public float SpawnRadius = 300;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spawntimer += Time.deltaTime;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, DetectRadius, LayerMask.GetMask("Kaw"));
        if (hit && spawntimer >= SpawnCooldown)
        {
            spawnspot = origin + (Random.insideUnitCircle * SpawnRadius);
            GameObject spawn = Instantiate(spawnobj, spawnspot, Quaternion.identity, transform);

            spawntimer = 0;
        }
    }
}
