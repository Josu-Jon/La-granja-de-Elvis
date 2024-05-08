using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlants : MonoBehaviour
{
    public GameObject plant;
    public GameObject vegetablePrefab;
    public Canvas wateringCanvas;
    public float delay = 5f;
    public float fruitSpawnHeightOffset = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("regadera"))
        {
            if (plant != null)
            {
                plant.SetActive(false);

                wateringCanvas.gameObject.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay(delay));
            }
        }
    }

    IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 fruitSpawnPosition = plant.transform.position;
        fruitSpawnPosition.y += fruitSpawnHeightOffset;
        Instantiate(vegetablePrefab, fruitSpawnPosition, Quaternion.identity);
        wateringCanvas.gameObject.SetActive(false);
    }
}
