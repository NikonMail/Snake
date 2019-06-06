using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{

    private float speed = 0.07f;
    private float distance = 1f;
    private int index;

    Vector3 vector = Vector3.forward;
    Vector3 moveVector;
    Vector3 tailTarget;

    bool vertical = false;
    bool horizontal = true;

    private List<GameObject> tailObjects = new List<GameObject>();
    public GameObject TailPrefab;
    public GameObject tailTargetObj;

    void Start()
    {
        tailObjects.Add(gameObject);
        index = tailObjects.Count - 1;
        tailTargetObj = tailObjects[index];

        InvokeRepeating("Movement", 0.1f, speed);
    }

    void Update()
    {
        //tailTarget = tailTargetObj.transform.position;
        //transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
        Vector3 dis = tailObjects[index - 1].transform.position = tailObjects[index].transform.position;
        //dis.normalized();
        tailObjects[index].transform.position += dis * distance * Time.deltaTime * speed; 


    }

    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.D) & horizontal) || (Input.GetKey(KeyCode.RightArrow) & horizontal))
        {
            horizontal = false;
            vertical = true;
            vector = Vector3.right;
        }
        else if ((Input.GetKey(KeyCode.A) & horizontal) || (Input.GetKey(KeyCode.LeftArrow) & horizontal))
        {
            horizontal = false;
            vertical = true;
            vector = Vector3.left;
        }
        else if ((Input.GetKey(KeyCode.W) & vertical) || (Input.GetKey(KeyCode.UpArrow) & vertical))
        {
            horizontal = true;
            vertical = false;
            vector = Vector3.forward;
        }
        else if ((Input.GetKey(KeyCode.S) & vertical) || (Input.GetKey(KeyCode.DownArrow) & vertical))
        {
            horizontal = true;
            vertical = false;
            vector = Vector3.back;
        }
        moveVector = vector / 3f;
    }

    void Movement()
    {
        transform.Translate(moveVector);
    }
    public void AddTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= distance;
        tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
}
