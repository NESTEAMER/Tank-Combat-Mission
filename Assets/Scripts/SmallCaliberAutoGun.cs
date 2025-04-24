using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCaliberAutoGun : MonoBehaviour
{
    public float speed = 30f;
    public float lifetime = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 3f);
    }
}
