using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFighter : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint; 
    public float moveSpeed = 10f;
    public float bombDropInterval = 3f;
    public float lifetime = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DropBombs());
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate() 
    {
        rb.AddForce(transform.forward * moveSpeed);
    }

    IEnumerator DropBombs()
    {
        while (true)
        {
            Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);
            yield return new WaitForSeconds(bombDropInterval);
        }
    }

    void Update()
    {

    }
}
