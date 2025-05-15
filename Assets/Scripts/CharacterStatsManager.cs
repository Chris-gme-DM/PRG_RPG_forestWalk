using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }
    public List <BattleEntity> characterData { get; private set; }
    public Dictionary<string, bool> equipment;
    public Dictionary<string, int> items;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            Load();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Load()
    {
        // Initialize equipment and items
        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }
}