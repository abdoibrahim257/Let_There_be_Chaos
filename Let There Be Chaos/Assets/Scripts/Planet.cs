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
    public float MaxEnemies = 5;
    public float counter = 0;

    private int random;
    private float[] arr;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        arr = new float[] {20, SpawnRadius};
    }

    // Update is called once per frame
    void Update()
    {
        spawntimer += Time.deltaTime;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, DetectRadius, LayerMask.GetMask("Kaw"));
        if (hit && spawntimer >= SpawnCooldown && counter < MaxEnemies)
        {
            random = Random.Range(0,2);
            counter++;
            spawnspot = origin + (Random.insideUnitCircle * arr[random]);
            GameObject spawn = Instantiate(spawnobj, spawnspot, Quaternion.identity);
            spawn.transform.SetParent(transform, true);
            spawntimer = 0;
        }
    }

    void OnDestroy()
    {
        GameObject.FindWithTag("Player").GetComponent<AudioSource>().Play();
    }
}
