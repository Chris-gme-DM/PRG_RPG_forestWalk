using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [Header("BattleSpawns - Character")]
    [SerializeField] private Transform battleCharacterSpawnPoint;

    [Header("BattleSpawns - Enemies")]
    [SerializeField] private Transform battleEnenmiesSpawnPoint;

    private List<GameObject> spawnedObjects;
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
        spawnedObjects = new List<GameObject>();
    }

    public BattleCharacter SpawnBattleEntity(BattleEntityData identifier)
    {
        return SpawnBattleEntity(identifier, CharacterStatsManager.Instance.GetPlayerExp(identifier.entityName),
            CharacterStatsManager.Instance.GetPlayerHP(identifier.entityName));
    }

    public BattleCharacter SpawnBattleEntity(BattleEntityData identifier, int experiencePoints, Health health)
    {
        var spawnPoint = battleEnenmiesSpawnPoint;

        if (identifier.type == BattleEntityType.Player)
            spawnPoint = battleCharacterSpawnPoint;

        var go = Instantiate(identifier.spawnablePrefab, spawnPoint);
        var bc = go.GetComponent<BattleCharacter>();
        bc.PlayerName = identifier.entityName;
        bc.SetExp(experiencePoints);
        bc.SetHP(health);

        Debug.Log($"Exp is: {experiencePoints} and Level: {bc.Level}");
        spawnedObjects.Add(go);

        bc.SetVisuals();
        return bc;
    }

    public void Unload()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
    }

}
