using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [SerializeField] Transform battleCharacterSpawnPoint;
    [SerializeField] GameObject spawnableBattleCharacter;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SpawnBattleCharacter(BattleCharacter identifier, string name)
    {
        foreach (var character in spawnableBattleCharacter.GetComponentsInChildren<BattleCharacter>()) 
        {
            Instantiate(spawnableBattleCharacter, battleCharacterSpawnPoint);
        }
    }
}
