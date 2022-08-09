using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float SecondsToDestroy = 10f;
    public GameObject DestroyEffect;
    void Start()
    {
        Destroy(gameObject, SecondsToDestroy);
    }

    void OnDestroy()
    {
        if (DestroyEffect)      // lw fy destroy effect, e3mlo instantiate
        {
            GameObject effect = Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        }
    }

}
