using System.Collections;
using SlimUI.ModernMenu;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DemoManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;

    [Header("SFX")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _pauseSfxList;
    [SerializeField] private AudioClip[] _quitSfxList;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private PlayerInput _playerInput;


    private WaitForSeconds _sfxDelay = new(6f);
    private const float DEMO_DURATION = 120.0f;
    private readonly int _demoOverHash = Animator.StringToHash("DemoOver");
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDemo());
    }

    IEnumerator StartDemo() {
        yield return new WaitForSeconds(DEMO_DURATION);
        _animator.SetTrigger(_demoOverHash);
    }

    public void PauseGame() {
        int randIdx = Random.Range(0, _pauseSfxList.Length);
        _playerInput.DeactivateInput();
        _audioSource.Stop();
        _audioSource.volume = 1.0f;
        _audioSource.PlayOneShot(_pauseSfxList[randIdx]);
        _pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        _playerInput.ActivateInput();
        _pauseMenu.SetActive(false);
    }
    
    public void LoadMenu() {
        SceneManager.LoadSceneAsync((int)Constants.ScenceIndex.Menu);
    }

    public void QuitGame() {
        StartCoroutine(PlayQuitSound());
    }
    
    IEnumerator PlayQuitSound() {
        int randIdx = Random.Range(0, _quitSfxList.Length);
        _audioSource.Stop();
        _audioSource.volume = 1.0f;
        _audioSource.PlayOneShot(_quitSfxList[randIdx]);
        yield return _sfxDelay;

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}
