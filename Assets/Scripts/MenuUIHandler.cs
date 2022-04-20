using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public InputField playerNameField;

    //private string playerName;
    //private int score = 0;

    public void SaveName()
    {
        GameData.Instance.PlayerName = playerNameField.text; 
        Debug.Log(GameData.Instance.PlayerName);
        GameData.Instance.SaveGame();
    }
   

    

    public void StartNew()
    {
        
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

        GameData.Instance.SaveGame();
        

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

  
    
}
