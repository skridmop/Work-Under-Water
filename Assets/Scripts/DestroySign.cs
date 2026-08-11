using UnityEngine;
using System.Collections;

public class DestroySign : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroyTime());
    }

    IEnumerator destroyTime()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
