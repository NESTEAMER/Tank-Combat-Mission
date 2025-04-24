using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBomb : MonoBehaviour
{
    public float lifetime = 5f;
    public float explosionForce = 50f; 
    public float explosionRadius = 20f;
    public GameObject explosionParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }

        if (explosionParticlePrefab != null)
        {
            Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); 
    }
}
