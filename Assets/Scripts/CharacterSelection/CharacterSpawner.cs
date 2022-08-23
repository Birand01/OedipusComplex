using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    [SerializeField] GameObject[] parentPrefabs; 
    public Transform spawnPoint,parentSpawnPoint;
    public int selectedCharacter;
    public GameObject clone;
    
    public static CharacterSpawner Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
       
    }
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
         clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
      
    }

  
   
}
