using UnityEngine;

public class GrowScale : MonoBehaviour
{
    private Vector3 startScale;
    public float elapsedTime = 0f;
    public float growDuration = 2f;

    public GameObject trashPrefab;
    private bool hasSpawnedTrash = false;



    void Start()
    {
        transform.localScale = new Vector3(1.05845881f, 0.854070425f, 1.05845881f);
        startScale = transform.localScale;
        trashPrefab.transform.localScale = new Vector3(1.36860001f, 1.36860001f, 1.36860001f);
    }

    void Update()
    {
        float t = elapsedTime / growDuration;
        elapsedTime += Time.deltaTime;
        transform.localScale = Vector3.Lerp(startScale, new Vector3(2.20678067f, 1.78065133f, 2.20678067f), t);
        if (t >= 1f && !hasSpawnedTrash)
        {
            GameObject trash = Instantiate(trashPrefab, transform.position + new Vector3(0f, 0.34f, 0f), Quaternion.identity);
            trash.GetComponent<CollectTrash>().myShade = gameObject;
            hasSpawnedTrash = true;
        }
    }
}
