using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{

    private float speed = 3f;
    private float rotationSpeed = 200f;
    private float z_offset = 0.25f;

    public List<GameObject> tailObjects = new List<GameObject>();
    public GameObject TailPrefab;


    void Start()
    {
        tailObjects.Add(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -1 * rotationSpeed * Time.deltaTime);
        }
    }

    public void AddTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
}
public class TailMove : MonoBehaviour
{

    private float speed = 3f;
    private int index;

    public Vector3 tailTarget;
    public GameObject tailTargetObj;
    public SnakeMove SnakeHead;

    void Start()
    {

        SnakeHead = FindObjectOfType<SnakeMove>();
        tailTargetObj = SnakeHead.tailObjects[SnakeHead.tailObjects.Count - 2];
        index = SnakeHead.tailObjects.IndexOf(gameObject);
    }
    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
    }
}
