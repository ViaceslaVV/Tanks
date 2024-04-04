using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 3;
    
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //TODO: Add explosion effect
        //TODO: Do damage
        //TODO: destroy destructables (like crates)
        Destroy(gameObject);
    }
}