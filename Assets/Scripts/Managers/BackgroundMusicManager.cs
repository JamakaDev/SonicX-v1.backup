using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _tracks;

    private int  _currTrack;
    private int  _prevTrack;
    private bool _isPaused;
    private readonly Dictionary<int, WaitForSeconds> _trackTimes = new();


    // Start is called before the first frame update
    void Start() {      
        _currTrack = Random.Range(0, _tracks.Length);
        _prevTrack = _currTrack;
        _audioSource.clip = _tracks[_currTrack];
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        _audioSource.Play();
        for (int i = 0; i < _tracks.Length; i++) {
            _trackTimes.Add(_tracks[i].GetHashCode(), new WaitForSeconds(_tracks[i].length));
        }

    }

    // Update is called once per frame
    void Update() {

        if(!_audioSource.isPlaying && !_isPaused) {
            StartCoroutine(LoopAudio());
        }

        return;

    }
    
    IEnumerator LoopAudio() {

        while(true) {
            _currTrack = Random.Range(0, _tracks.Length);
            
            if (_prevTrack == _currTrack) {
                _currTrack = Random.Range(0, _tracks.Length);
            }

            _prevTrack = _currTrack;
            _audioSource.clip = _tracks[_currTrack];
            _audioSource.Play();
            yield return _trackTimes[_audioSource.clip.GetHashCode()];

        }

    }

    void OnApplicationPause(bool isPaused) {
        _isPaused = isPaused;
        HandlePause();
    }

    void OnApplicationFocus(bool hasFocus) {
        _isPaused = !hasFocus;
        HandlePause();
    }

    void HandlePause() {
        if (_isPaused) _audioSource.Pause();
        else _audioSource.UnPause();
    }
}
