using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

// defintion of terms

public class LevelSwitch : MonoBehaviour
{
    // GameScene Name is for developer to assign the GameScene the player character should switch to, according to sceneBuildIndex
    [SerializeField] private string gameSceneName;
    public int sceneBuildIndex;
    //Collision Check with approptiate Tilemap Parts to initiate SceneChange
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            System.Console.WriteLine("Scene Change Triggered");
        }
    }
}
