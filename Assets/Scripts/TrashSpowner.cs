using UnityEngine;
using System.Collections;

public class TrashSpowner : MonoBehaviour
{
    public float minX = -5.5f;
    public float maxX = 5.5f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    public GameObject shadePrefab;

    void Start()
    {
        StartCoroutine(Spowner());
    }

    IEnumerator Spowner()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            yield return new WaitForSeconds(4f);
            Instantiate(shadePrefab, spawnPosition, Quaternion.identity);
        }
    }



}