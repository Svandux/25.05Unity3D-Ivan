using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float bulletSpeed = 5f;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
