using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0f,1f), SerializeField] private float chanceToEncounter;
    [SerializeField] GameObject fightCanvas;
    private bool isFightActive;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        isFightActive = false;
    }

    public bool CheckForEncounter()
    {
        if(Random.Range(0f,1f) < chanceToEncounter)
        {             // Trigger enemy encounter
            StartFight();
        }
        return isFightActive;

    }
    private void StartFight()
    { 
        fightCanvas.SetActive(true);
        isFightActive=true;
        StartCoroutine(FightCoroutine());
    }

    private IEnumerator FightCoroutine()
    {
        //Load Characters
        //Load Enemies
        //Load BackgroundImages
        //Load Music
        //Load UI
        //Load Items
        while (isFightActive) 
        {  
            //Check whose turn
            //Make Player/ Enemies Turn
            //Show and wait for end of fight
            //Set isFightActive to false
            yield return new WaitForSeconds(3f);
            isFightActive = false;
        }
        //End Fight and gain XP and Gold
        //Level UP?
    }
}
