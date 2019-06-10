using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    public event System.Action<BaseObject> OnCollision;

    private void DoCollision (BaseObject baseObject)
    {
        if (OnCollision != null)
        {
            OnCollision (baseObject);
        }
    }

    [SerializeField]
    private GameObject tailPrefab;

    private float speed = 0.07f;
    private float distance = 1f;

    private bool vertical = false;
    private bool horizontal = true;

    private Vector3 moveVector = Vector3.forward;

    private List<Transform> tailObjects = new List<Transform> ();

    private void ProcessInput ()
    {
        if ((Input.GetKey (KeyCode.D) & horizontal) || (Input.GetKey (KeyCode.RightArrow) & horizontal))
        {
            horizontal = false;
            vertical = true;
            moveVector = Vector3.right;
        }
        else if ((Input.GetKey (KeyCode.A) & horizontal) || (Input.GetKey (KeyCode.LeftArrow) & horizontal))
        {
            horizontal = false;
            vertical = true;
            moveVector = Vector3.left;
        }
        else if ((Input.GetKey (KeyCode.W) & vertical) || (Input.GetKey (KeyCode.UpArrow) & vertical))
        {
            horizontal = true;
            vertical = false;
            moveVector = Vector3.forward;
        }
        else if ((Input.GetKey (KeyCode.S) & vertical) || (Input.GetKey (KeyCode.DownArrow) & vertical))
        {
            horizontal = true;
            vertical = false;
            moveVector = Vector3.back;
        }

        moveVector = moveVector.normalized / 3f;
    }

    void Movement ()
    {
        transform.Translate (moveVector);
    }

    public void AddTail ()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= distance;

        var tailElement = (Instantiate (tailPrefab, newTailPos, Quaternion.identity) as GameObject).transform;
        tailObjects.Add (tailElement);
    }

    private void OnTriggerEnter (Collider other)
    {
        var baseObject = other.gameObject.GetComponent<BaseObject> ();

        if (baseObject != null)
        {
            DoCollision (baseObject);
        }
    }
   
    void Start ()
    {
        tailObjects.Add (transform);

        InvokeRepeating ("Movement", 0.1f, speed);
    }

    void Update ()
    {
        for (int i = 1; i < tailObjects.Count; i++)
        {
            Vector3 dir = tailObjects[i - 1].transform.position - tailObjects[i].transform.position;
            dir = dir.normalized;
            tailObjects[i].transform.position += dir * distance * Time.deltaTime * speed;
        }

        ProcessInput ();
    }

}
