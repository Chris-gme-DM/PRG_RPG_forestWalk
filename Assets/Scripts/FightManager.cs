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
    private BaseCharacterController characterController;
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
        fightCanvas.SetActive(isFightActive);
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
        StartCoroutine(FightCoroutine());
    }

    private IEnumerator FightCoroutine()
    {
        isFightActive=true;

        //Load Characters
        LoadCharacter();
        //Load Enemies
        LoadEnemies();
        //Load BackgroundImages
        LoadBackgroundImages();
        //Load Music
        LoadMusic();
        //Load Items
        LoadItems();
        //Load UI
        LoadUI();

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
        //Switch Canvas
        fightCanvas.SetActive(isFightActive);
        characterController.PausePlayer(isFightActive);
        //Level UP?
    }
    private void LoadCharacter()
    {
        //get CharacterStats
        foreach (var character in CharacterStatsManager.Instance.characterData)
        {
            character.LoadPlayerPrefab(name);
            SpawnManager.instance.SpawnBattleEntity(character);
        }
        //Load CharacterSprite
        //Load CharacterOptions

    }
    private void LoadEnemies()
    {
        //if EncounterPredetermined => LoadEncounter(Index)
        //else EncounterRandom
        //Check CharacterLevel
        //Determine Number of enemies
        //Choose Enemies at random
        //get Enemies from Enemies(Index)
        //Load Enemy Stats
        //Load Enemy Options
        //Load Enemy Sprites
    }
    private void LoadBackgroundImages()
    {
        //Check Environment
        //Get BackgroundImage from BackgroundImages(Index)
        //Load BackgroundImage(Index)
        //Set Active Display to FightCanvas
    }
    private void LoadMusic()
    {
        //Check Envionment
        //Get Music from Music(Index)
        //Load Music(Index)
    }
    private void LoadItems()
    {
        //get Character
        //Check Items
        //Load Item Options
        //Load Item Sprite if any
    }
    private void LoadUI()
    {
        //get CharacterLoaded
        //get Character.Options
        //Load UI according to character and items
    }
}
