using System.Collections;
using UnityEngine;

public class Section : MonoBehaviour
{

    private const short SPAWN_OFFSET = 20;
    private const float SECTION_LENGTH = 10f;

    private Transform _transform;
    private GameObject _tempSection;

    private readonly WaitForSeconds _waitForOneSecond = new(1.0f);



    // Start is called before the first frame update
    void Start() {

        _transform = transform;

    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player"){
            StartCoroutine(ResetSection());            
        }

    }

    IEnumerator ResetSection() {
        
        yield return _waitForOneSecond;
        
        // Deactivate current section.
        gameObject.SetActive(false);
        
        // Get index of next section
        int randIdx = Random.Range(0, SectionManager.LevelIndexesList.Count) % SectionManager.InactiveLevelList.Count;
        _tempSection = SectionManager.InactiveLevelList[randIdx];
        // SectionManager.levelIndexesList[randIdx];
        
        // Remove current section from active queue & add it back to inactive list.
        SectionManager.InactiveLevelList.Add(SectionManager.ActivePieces.Dequeue());

        // Add next section to active queue, position & activate it.
        _tempSection.transform.position = new Vector3(0f, 0f, (SECTION_LENGTH * SPAWN_OFFSET) + _transform.position.z);
        _tempSection.SetActive(true);
        SectionManager.ActivePieces.Enqueue(_tempSection);

        // Remove newly activated section from inactive list.
        SectionManager.InactiveLevelList.RemoveAt(randIdx);

    }


}
