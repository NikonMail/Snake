using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(0);
    }
}
