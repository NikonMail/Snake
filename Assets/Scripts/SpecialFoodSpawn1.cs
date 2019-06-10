using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialFoodSpawn1 : MonoBehaviour
{
    private float width = 9f;
    private float height = 9f;
    private float startTime;

    public GameObject foodPrefab;
    public GameObject currentFood;

    private IEnumerator Spawn ()
    {
        while (true)
        {
            yield return new WaitForSeconds (15f);

            if (currentFood != null)
                Destroy (currentFood.gameObject);

            Vector3 foodPosition = new Vector3 (Random.Range (width * -1, width), 0.3f, Random.Range (height * -1, height));

            currentFood = GameObject.Instantiate (foodPrefab, foodPosition, Quaternion.identity);
        }
    }

    void Start ()
    {
        startTime = Time.time;
    }

    void Update ()
    {
        if (Time.time - startTime >= 15f)
        {
            startTime = Time.time;

            if (currentFood != null)
                Destroy (currentFood.gameObject);

            Vector3 foodPosition = new Vector3 (Random.Range (width * -1, width), 0.3f, Random.Range (height * -1, height));

            currentFood = GameObject.Instantiate (foodPrefab, foodPosition, Quaternion.identity);
        }
    }
}
