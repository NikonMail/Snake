using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    [SerializeField]
    private Score score;

    public Score Score
    {
        get
        {
            return score;
        }
    }
    
    void Start ()
    {

    }


}
