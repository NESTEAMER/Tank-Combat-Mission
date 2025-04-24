using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPiercingRound : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f; 
    public float explosionForce = 20f; 
    public float explosionRadius = 15f; 
    public GameObject explosionParticlePrefab;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius);
                Debug.Log("We bring da boom! (I'm not sorry)");
            }
        }

        if (explosionParticlePrefab != null)
        {
            Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject, 3f);
    }
}
