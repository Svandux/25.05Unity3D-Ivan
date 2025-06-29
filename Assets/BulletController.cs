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
        transform.forward = GameObject.Find("Player 2.0").transform.position - transform.position;
        rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
