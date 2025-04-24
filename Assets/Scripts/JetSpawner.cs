using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetSpawner : MonoBehaviour
{
    public GameObject jetPrefab;
    public Transform spawnPointsParent; 
    public float spawnDelay = 20f;

    void Start()
    {
        StartCoroutine(SpawnJets());
    }

    void Update()
    {
        
    }
    IEnumerator SpawnJets()
    {
        while (true)
        {
            Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();

            int randomIndex = Random.Range(1, spawnPoints.Length); 
            Transform spawnPoint = spawnPoints[randomIndex];

            Instantiate(jetPrefab, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
