using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject vfx;

    public virtual void Detroy()
    {
        Instantiate(vfx, transform.position + Vector3.up, Quaternion.identity);
        Destroy(gameObject);
    }
}