using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0f,1f), SerializeField] private float chanceToEncounter;
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

    public bool CheckForEncounter()
    {
        if(Random.Range(0f,1f) < chanceToEncounter)
        {             // Trigger enemy encounter
            Debug.Log("Start Encounter!");
            return true;
        }
        else
        {
            Debug.Log("No Encounter");
            return false;
        }
    }

}
