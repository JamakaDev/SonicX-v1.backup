using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {

    private const int DRAW_DISTANCE = 20;
    private const float PIECE_LENGTH = 10f;
    private const float START_PIECE_OFFSET = 27f;
    
    [SerializeField] private TerrainSection[] _sections;
    [SerializeField] private Transform _parentTransform;

    public static List<int> LevelIndexesList = new List<int>();
    public static Queue<GameObject> ActivePieces = new Queue<GameObject>();
    public static List<GameObject> InactiveLevelList = new List<GameObject>();



    private void Start() {

        int idx, iLoop;
        
        // Create a list of levelPieces & indexes.
        BuildLevelList(LevelIndexesList, InactiveLevelList);
        
        // Draw & activate levelPieces in a random order.
        for (iLoop = 0; iLoop < DRAW_DISTANCE; iLoop++) {

            // Pick a random levelPiece.
            idx = Random.Range(0, LevelIndexesList.Count) % InactiveLevelList.Count;

            // Add the levelPiece to the active queue.
            InactiveLevelList[idx].transform.position = new Vector3(0f, 0f, (iLoop * PIECE_LENGTH) + START_PIECE_OFFSET);
            InactiveLevelList[idx].SetActive(true);
            ActivePieces.Enqueue(InactiveLevelList[idx]);
            
            // Remove the levelPiece from the inactive queue.
            InactiveLevelList.RemoveAt(idx);
        
        }

    }

    void BuildLevelList(List<int> levelIdxList, List<GameObject> levelList) {

        int index = 0;
        GameObject tmpPiece;

        // Create a list of levelPieces & indexes for object pooling. 
        foreach (TerrainSection section in _sections) {

            //The higher the quantity, the higher the probability that the levelPiece will be spawned.
            for (int iLoop = 0; iLoop < section.quantity; iLoop++) {

                levelIdxList.Add(index);
                tmpPiece = Instantiate(section.prefab, Vector3.zero, Quaternion.identity);
                tmpPiece.transform.parent = _parentTransform;
                tmpPiece.SetActive(false);
                levelList.Add(tmpPiece);

            }

            index++;

        }

    }

}

[System.Serializable]
public class TerrainSection {

    public string name;
    public GameObject prefab;
    public int quantity = 1;

}