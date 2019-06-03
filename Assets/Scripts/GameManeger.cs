using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManeger : MonoBehaviour {

    private TextUI textUI;

    private SnakeMove snakeMove;

    private FoodSpawn foodSpawn;

    private SFoodSpawn1 sFoodSpawn1;

    void Snake_OnCollision (BaseObject baseObject)
    {
        //if (baseObject is Border)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        }
       // if (baseObject is Food)
        {
            // foodSpawn.Spawn();
            //score++;
        }
        // if (baseObject is SpecialFood1)
        {
            // foodSpawn.Spawn();
            //score++;
        }
    }


	void Start () {

      //  Snake_OnCollision += Snake_OnCollision;
    }
	

	void Update () {

	}
}
