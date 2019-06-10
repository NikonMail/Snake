using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    private float width = 9f;
    private float height = 9f;

    public GameObject FoodPrefab;
    public GameObject CurrentFood;
    public Vector3 CurrentPosition;

    void Start ()
    {
        RandomPosition ();
        CurrentFood = GameObject.Instantiate (FoodPrefab, CurrentPosition, Quaternion.identity);
    }

    void RandomPosition ()
    {
        CurrentPosition = new Vector3 (Random.Range (width * -1, width), 0.3f, Random.Range (height * -1, height));
    }

    void Update ()
    {
        if (CurrentFood == null)
        {
            Start ();
        }
    }
}
