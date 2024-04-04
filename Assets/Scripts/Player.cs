using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    
    Rigidbody rb;
    Vector3 input = new Vector3();
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //InvokeRepeating(function name, time to start, repeat rate)
        InvokeRepeating(nameof(Fire), fireRate, fireRate);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }
    
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        
        transform.forward = input;
    }
    
    void FixedUpdate()
    {
        //input.y = rb.velocity.y;
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
    }
}
