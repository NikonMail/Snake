using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class Score : MonoBehaviour
{
    private Text text;

    private int _value;

    /// <summary>
    /// Количество очков
    /// </summary>
    public int Value
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;

            text.text = _value.ToString ();
        }
    }

    void Start ()
    {
        text = GetComponent<Text> ();
    }
}
