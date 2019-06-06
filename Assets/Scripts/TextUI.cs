using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour {

    private int score = 0;
    public Text ScoreText;

    void Start () {
        
    }
	

	void Update () {

    }

    void Text ()
    {
        ScoreText.text = score.ToString();
    }
}
