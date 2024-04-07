using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    [Header("VFX")]
    public GameObject barrelexplotion;

    public UnityEvent<int, int> onDamage; //pass in current health, max health
    public UnityEvent onDie;

    int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Takedamage(int damage)
    {
        currentHealth -= damage;
        onDamage.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            onDie.Invoke();
            Instantiate(barrelexplotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
