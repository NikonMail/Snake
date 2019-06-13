using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;

    private float width = 9f;
    private float height = 9f;

    public void Spawn ()
    {
        var pos = new Vector3 (Random.Range (width * -1, width), 0.3f, Random.Range (height * -1, height));
        Instantiate (foodPrefab, pos, Quaternion.identity);
    }
}
