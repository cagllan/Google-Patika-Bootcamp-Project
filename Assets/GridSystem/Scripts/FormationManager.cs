using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FormationManager : MonoBehaviour
{
    [SerializeField] GameObject[] slots;
    [SerializeField] List<String> occupiedSlotNames;
    [SerializeField] List<String> instantiatedPrefabTags;
    //[SerializeField] GameObject[] newSlots;
    [SerializeField] List<Transform> newOccupiedSlots;
    [SerializeField] GameObject pawnPrefab;
    [SerializeField] GameObject bishopPrefab;
    [SerializeField] GameObject knightPrefab;
    [SerializeField] GameObject rookPrefab;
    [SerializeField] GameObject queenPrefab;
    [SerializeField] GameObject kingPrefab;




    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveFormation()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                occupiedSlotNames.Add(slots[i].gameObject.name);
                instantiatedPrefabTags.Add(slots[i].transform.GetChild(0).tag);
            }
        }


        /*for (int i = 0; i < occupiedSlotNames.Count; i++)
        {
            PlayerPrefs.SetString(occupiedSlotNames[i],occupiedSlotNames[i]);
            PlayerPrefs.SetString(instantiatedPrefabTags[i], instantiatedPrefabTags[i]);

        }*/
     

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void LoadFormation(Scene scene, LoadSceneMode mode)
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");

        foreach (var slot in slots)
        {
            for (int i = 0; i < occupiedSlotNames.Count; i++)
            {
                if (slot.name== occupiedSlotNames[i])
                {
                    newOccupiedSlots.Add(slot.transform);
                }
            }
        }

        for (int j = 0; j < newOccupiedSlots.Count; j++)
        {
            if (instantiatedPrefabTags[j] == "Pawn")
            {
                SpawnPrefab(j,pawnPrefab);
            }
            else if (instantiatedPrefabTags[j] == "Bishop")
            {
                SpawnPrefab(j, bishopPrefab);
            }
            else if (instantiatedPrefabTags[j] == "Knight")
            {
                SpawnPrefab(j, knightPrefab);
            }
            else if (instantiatedPrefabTags[j] == "Rook")
            {
                SpawnPrefab(j, rookPrefab);
            }
            else if (instantiatedPrefabTags[j] == "Queen")
            {
                SpawnPrefab(j, queenPrefab);
            }
            else if (instantiatedPrefabTags[j] == "King")
            {
                SpawnPrefab(j, kingPrefab);
            }
        }

        occupiedSlotNames.Clear();
        instantiatedPrefabTags.Clear();
        newOccupiedSlots.Clear();
    }

    private void SpawnPrefab(int j,GameObject prefab)
    {
        var instPrefab = Instantiate(prefab, newOccupiedSlots[j].position, Quaternion.identity);
        instPrefab.transform.parent = newOccupiedSlots[j];
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadFormation;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadFormation;
    }
}
