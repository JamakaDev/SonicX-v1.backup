using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Door : MonoBehaviour
{

    [Header ("Door SFX")]
    [SerializeField] private AudioClip _openSound;
    [SerializeField] private AudioClip _closeSound;
    [SerializeField] private AudioSource _audioSource;
    
    [Header ("Door Animation")]
    [SerializeField] private Animator _animator;
    // [SerializeField] private Animator _playerAnimator;


    // [Header ("Cinemachine")]
    // [SerializeField] private CinemachineVirtualCamera _cinemachineGameCamera;
    // [SerializeField] private CinemachineVirtualCamera _cinemachineFollowCamera;


    private int _characterNearbyHash;


    // Start is called before the first frame update
    void Start()
    {
        _characterNearbyHash = Animator.StringToHash("character_nearby");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")){
            _animator.SetBool(_characterNearbyHash, true);
            _audioSource.PlayOneShot(_openSound);

            
            // Trigger "Play Game?" pop up animation
            if (gameObject.name == "DoorC") {
                Debug.Log("Door C");
            }

        }
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {
            _animator.SetBool(_characterNearbyHash, false);
            _audioSource.PlayOneShot(_closeSound);
        }
    }



}
