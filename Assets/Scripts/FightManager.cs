using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0,100f), SerializeField] private float enemyEncounterChance;
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
    }

    public void CheckForEncounter()
    {

    }

}
