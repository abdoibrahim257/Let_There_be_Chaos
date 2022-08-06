using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float SecondsToDestroy = 10f;
    void Start()
    {
        Destroy(gameObject, SecondsToDestroy);
    }

}
