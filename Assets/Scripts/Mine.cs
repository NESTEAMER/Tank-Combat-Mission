using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
     public float explosionForce = 100000f; 
    public float explosionRadius = 5f;   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank")) 
        {
            Vector3 explosionPos = transform.position;
            Rigidbody tankRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (tankRigidbody != null)
            {
                tankRigidbody.AddExplosionForce(explosionForce, explosionPos, explosionRadius);
            }

            Destroy(gameObject);
        }
    }
}
