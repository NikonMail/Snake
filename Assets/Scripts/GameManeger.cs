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

    [SerializeField]
    private SpecialFoodSpawn2 sFoodSpawn2;

    private void Snake_OnCollision (BaseObject baseObject)
    {
        if (baseObject is Border)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (0);
        }

        if (baseObject is Tail)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (baseObject is Border)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (baseObject is Food)
        {
            Destroy (baseObject.gameObject);

            foodSpawn.Spawn();

            sceneUI.Score.Value++;

            snake.AddTail ();
        }
        if (baseObject is SpecialFood1)
        {
            Destroy (baseObject.gameObject);
            sFoodSpawn1.Spawn();
            //score++;
        }
        if (baseObject is SpecialFood2)
        {
            Destroy(baseObject.gameObject);
            sFoodSpawn2.Spawn();
            //score++;
        }
    }

    void Start ()
    {
        snake.OnCollision += Snake_OnCollision;

        foodSpawn.Spawn ();
        sFoodSpawn1.Spawn();
    }
}
