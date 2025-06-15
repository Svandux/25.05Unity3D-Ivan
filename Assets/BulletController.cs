using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject ScreenCenter;
    private float bulletSpeed = 10f;
    private Rigidbody rigidbody;
    void Start()
    {
        ScreenCenter = GameObject.Find("ScreenCenter");
        rigidbody = GetComponent<Rigidbody>();
        transform.forward = ScreenCenter.transform.position - transform.position;
        rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
