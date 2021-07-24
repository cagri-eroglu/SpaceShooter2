using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float speed;
    Rigidbody physic;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.angularVelocity = Random.insideUnitSphere*speed;

    }

}
