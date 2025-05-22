using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.Tilemaps;
using static BattleEntityData;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    //chance to encounter a fight if enabled
    [Range(0f,1f), SerializeField] private float chanceToEncounter;

    [SerializeField] GameObject fightCanvas;
    [SerializeField] Image fightBackgroundSprite;
    [SerializeField] AudioSource fightMusic;

    private bool isFightActive;
    private BaseCharacterController characterController;

    private List<BattleCharacter> spawnedCharacters;
    private List<BattleCharacter> spawnedEnemies;
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
        spawnedCharacters = new List<BattleCharacter>();
        spawnedEnemies = new List<BattleCharacter>();
    }

    public bool CheckForEncounter()
    {
        if(Random.Range(0f,1f) < chanceToEncounter)
        {             // Trigger enemy encounter
            StartCoroutine(FightCoroutine());
        }
        return isFightActive;

    }

    private IEnumerator FightCoroutine()
    {
        isFightActive = true;

        fightCanvas.SetActive(isFightActive);
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
            var battleOverType = CheckForEndFight();
            isFightActive = battleOverType == BattleEntityType.None;
        }
        //End Fight and gain XP and Gold
        //Switch Canvas
        UnloadFightUI();

        fightCanvas.SetActive(isFightActive);
        characterController.PausePlayer(isFightActive);
        //Level UP?
    }
    private void LoadCharacter()
    {
        //get CharacterStats
        foreach (var character in CharacterStatsManager.Instance.characterData)
        {
            spawnedCharacters.Add(SpawnManager.instance.SpawnBattleEntity(character));
        }
        //Load CharacterSprite
        //Load CharacterOptions

    }
    private void LoadEnemies()
    {
        //if EncounterPredetermined => LoadEncounter(Index)
        //else EncounterRandom
         
        List<int> enemyLevels = new List<int>();
        List<Health> enemyHealth = new List<Health>();
        var enemies = FindObjectOfType<SceneFightDataHolder>().GetBattleEnemies(out enemyLevels, out enemyHealth);

        for (int i = 0; i < enemies.Count; i++)
        {
            spawnedEnemies.Add(SpawnManager.instance.SpawnBattleEntity(enemies[i], enemyLevels[i], enemyHealth[i]));
        }
        
        //Check CharacterLevel
        //Determine Number of enemies
        //Choose Enemies at random
        //get Enemies from Enemies(Index)
        //Load Enemy Stats
        //Load Enemy Options
        //Load Enemy Sprites
    }

    private BattleEntityType CheckForEndFight()
    {
        // Check if all enemies are dead using a lambda expression.
        bool allEnemiesDead = spawnedEnemies.TrueForAll(enemy => enemy.isCharacterDeath);

        // Check if all players are dead using a lambda expression.
        bool allPlayersDead = spawnedCharacters.TrueForAll(character => character.isCharacterDeath);

        // The fight continues as long as not all players or all enemies are dead.
        if (allEnemiesDead)
            return BattleEntityType.Enemy;
        if (allPlayersDead)
            return BattleEntityType.Player;
        return BattleEntityType.None;
    }
    private void UnloadFightUI()
    {
        spawnedCharacters.Clear();
        spawnedEnemies.Clear();
        SpawnManager.instance.Unload();
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
