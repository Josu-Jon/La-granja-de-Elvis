using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlants : MonoBehaviour
{
    public GameObject plant;
    public GameObject vegetablePrefab;
    public Canvas wateringCanvas;
    public float delay = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("regadera"))
        {
            if (plant != null)
            {
                plant.SetActive(false);

                Instantiate(vegetablePrefab, plant.transform.position, Quaternion.identity);

                wateringCanvas.gameObject.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(delay));
            }
        }
    }

    IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wateringCanvas.gameObject.SetActive(false);
    }
}
