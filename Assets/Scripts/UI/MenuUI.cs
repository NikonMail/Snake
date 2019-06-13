using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button start;

    [SerializeField]
    private Button setting;

    [SerializeField]
    private Button exit;

    private void NewGame ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (1);
    }

    private void SettingGame()
    {
        
    }

    private void ExitGame () 
    {
        Application.Quit();
    }

    private void Start ()
    {
        start.onClick.AddListener (NewGame);
        //setting.onClick.AddListener(SettingGame);
        exit.onClick.AddListener (ExitGame);
    }
}
