using UnityEngine;
using System.Collections;

public class SignSpown : MonoBehaviour
{
    public GameObject signPrefab;
    public GameObject sharkPrefab;

    void Start()
    {
        StartCoroutine(spowner());
    }

    IEnumerator spowner()
    {
        while (true)
        {
            int side = Random.Range(0, 4);
            Vector3 sharkRotation = Vector3.zero;
            Vector3 signPosition = Vector3.zero;
            Vector3 sharkPosition = Vector3.zero;
            Vector3 endPosition = Vector3.zero;
            switch (side)
            {
                case 0:
                    signPosition = new Vector3(0f, 3.7f, 0f);
                    sharkPosition = new Vector3(0f, 7.5f, 0f);
                    endPosition = new Vector3(0f, -7.5f, 0f);

                    break;
                case 1:
                    signPosition = new Vector3(0f, -3.7f, 0f);
                    sharkPosition = new Vector3(0f, -7.5f, 0f);
                    sharkRotation = new Vector3(0f, 0f, 180f);
                    endPosition = new Vector3(0f, 7.5f, 0f);
                    break;
                case 2:
                    signPosition = new Vector3(-5.3f, 0f, 0f);
                    sharkPosition = new Vector3(-11.3f, 0f, 0f);
                    sharkRotation = new Vector3(0f, 0f, 90f);
                    endPosition = new Vector3(11.3f, 0f, 0f);
                    break;
                case 3:
                    signPosition = new Vector3(5.3f, 0f, 0f);
                    sharkPosition = new Vector3(11.3f, 0f, 0f);
                    sharkRotation = new Vector3(0f, 0f, -90f);
                    endPosition = new Vector3(-11.3f, 0f, 0f);
                    break;
            }
            yield return new WaitForSeconds(8f);
            Instantiate(signPrefab, signPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(signPrefab, signPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            Instantiate(signPrefab, signPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            GameObject shark = Instantiate(sharkPrefab, sharkPosition, Quaternion.Euler(sharkRotation));
            shark.GetComponent<SharkMovement>().position = endPosition;
        }
    }
}
