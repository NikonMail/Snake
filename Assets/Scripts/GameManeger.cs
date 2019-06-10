using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManeger : MonoBehaviour
{
    [SerializeField]
    private SceneUI sceneUI;

    [SerializeField]
    private Snake snake;

    [SerializeField]
    private FoodSpawn foodSpawn;

    [SerializeField]
    private SpecialFoodSpawn1 sFoodSpawn1;

    private void Snake_OnCollision (BaseObject baseObject)
    {
        if (baseObject is Border)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (0);
        }
     
        if (baseObject is Food)
        {
            Destroy(gameObject);
            //foodSpawn.Spawn();
            //foodSpawn;
        }
        //if (baseObject is SpecialFood1)
        {
            // foodSpawn.Spawn();
            //score++;
        }
    }

    void Start ()
    {
        snake.OnCollision += Snake_OnCollision;
    }
}
