using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _menuFadeScreen;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(StartIntroCoroutine());
    }

    IEnumerator StartIntroCoroutine()
    {

        _audioSource.Stop();
        _videoPlayer.Play();
        yield return new WaitForSeconds((float)_videoPlayer.clip.length);
        _menuFadeScreen.SetActive(true);
        _videoPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        _menu.SetActive(true);
        _audioSource.Play();        
        gameObject.SetActive(false);    

    }

}
