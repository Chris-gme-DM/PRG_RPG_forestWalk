using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public void StartGamePressed()
    {
        SceneManager.LoadScene(gameSceneName);
        //Application.NewGame();
    }
    #region Options
    public void OptionsPressed()
    {
        Debug.Log($"{Pressed("Options")}");
        //Application.Options();
    }
    #endregion

    public void SavePressed()
    {
        Debug.Log($"{Pressed("Save")}");
        //Application.SaveGame();
    }

    public void LoadPressed()
    {
        Debug.Log($"{Pressed("Load")}");
        //Application.LoadGame();
    }

    public void QuitPressed()
    {
        Debug.Log($"{Pressed("Quit")}");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else   
        Application.Quit();
#endif  
    }

    private string Pressed(string buttonName)
    {
        return $"{buttonName} Button Pressed";
    }

}