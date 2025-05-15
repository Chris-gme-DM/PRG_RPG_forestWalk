using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    [SerializeField] Transform battleEntitySpawnPoint;
    [SerializeField] GameObject spawnableBattleEntity;
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
    public void SpawnBattleEntity(BattleEntity identifier)
    {
        var go = Instantiate(identifier.spawnableBattleEntity) as GameObject;
    }
}
