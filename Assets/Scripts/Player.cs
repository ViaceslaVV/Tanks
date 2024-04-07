using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public bool player1 = true;

    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    [Header("UI")]
    public Transform healthBar;

    [Header("VFX")]
    public GameObject dustVFX;

    
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
        if(player1)
        {
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrow");
            input.z = Input.GetAxis("VerticalArrow");

        }
        

        if (input != Vector3.zero)
        {
            transform.forward = input;
            if (!dustVFX.activeSelf)
                dustVFX.SetActive(true);
        }
        else
        {
            if(dustVFX.activeSelf)
            {
                dustVFX.SetActive(false);
            }
        }
         
    }
    
    void FixedUpdate()
    {
        //input.y = rb.velocity.y;
        rb.velocity = input * speed + Vector3.up * rb.velocity.y;
    }

    public void UpdateHealthbar(int curentHealth, int maxHealth)
    {
        healthBar.localScale = new Vector3((float)curentHealth / maxHealth, 1, 1);
    }
    
}
