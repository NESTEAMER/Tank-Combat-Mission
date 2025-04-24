using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerators : MonoBehaviour
{
    public GameObject cubePrefab;
    public int width = 10;
    public int height = 5;
    public float buildDelay = 0.1f;
    public bool animated = true; 

    void Start()
    {
        if (animated)
        {
            StartCoroutine(GenerateWallAnimated());
        }
        else
        {
            GenerateWallInstant();
        }
    }

    void GenerateWallInstant()
    {
        float cubeWidth = cubePrefab.transform.localScale.x;
        float cubeHeight = cubePrefab.transform.localScale.y;

        float startX = -(width * cubeWidth / 2f) + (cubeWidth / 2f);
        float startY = -(height * cubeHeight / 2f) + (cubeHeight / 2f);

        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Vector3 localPosition = new Vector3(startX + i * cubeWidth, startY + j * cubeHeight, 0f);
                Vector3 position = transform.TransformPoint(localPosition);
                Instantiate(cubePrefab, position, transform.rotation);
            }
        }
    }

    IEnumerator GenerateWallAnimated()
    {
        float cubeWidth = cubePrefab.transform.localScale.x;
        float cubeHeight = cubePrefab.transform.localScale.y;

        float startX = -(width * cubeWidth / 2f) + (cubeWidth / 2f);
        float startY = -(height * cubeHeight / 2f) + (cubeHeight / 2f);

        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                Vector3 localPosition = new Vector3(startX + i * cubeWidth, startY + j * cubeHeight, 0f);
                Vector3 position = transform.TransformPoint(localPosition);
                Instantiate(cubePrefab, position, transform.rotation);

                yield return new WaitForSeconds(buildDelay);
            }
        }
    }
}