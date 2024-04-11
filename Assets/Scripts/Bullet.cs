using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 3;
    public int damage = 15;

    [Header("VFX")]
    public GameObject explotion;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //TODO: Add explosion effect
        //TODO: Do damage
        Instantiate(explotion, transform.position, Quaternion.identity);

        var enemy = collision.gameObject.GetComponent<Health>();
        if(enemy != null)
        {
            enemy.Takedamage(damage);
        }
        //TODO: destroy destructables (like crates)
        Collide();
    }
    public virtual void Collide()
    {
        Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}