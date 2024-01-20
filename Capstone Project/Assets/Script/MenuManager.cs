using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Slider volumeSetting;
    [SerializeField] private AudioMixer volumeMixer;
    [SerializeField] private AudioMixerGroup volumeMixerGroup;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private GameObject upgradePanel;
    private AudioSource audioSource;


    private GameManager gameManager;
    private int selectedStage;
   
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameManager.state = GameManager.GameState.SelectLevel;
        SceneManager.LoadSceneAsync(1);
        //StartCoroutine(EStartGame());
    }
    IEnumerator EStartGame()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(1);
    }
    public void RetryGame()
    {
        gameManager.Retry();
        StartCoroutine(ERetryGame());
    }
    IEnumerator ERetryGame()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMainMenu()
    {
        gameManager.state = GameManager.GameState.MainMenu;
        SceneManager.LoadSceneAsync(0);
    }
    public void Setting()
    {
        if (settingPanel.activeSelf)
        {
            SetMasterVolume();
            settingPanel.SetActive(false);
        }
        else { settingPanel.SetActive(true); }
    }
    public void UpgradePanel()
    {
        if (upgradePanel.activeSelf)
        {
            upgradePanel.SetActive(false);
        }
        else { upgradePanel.SetActive(true); }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartSelectedStage()
    {
        if(selectedStage != 0)
        {
            gameManager.state = GameManager.GameState.InGame;
            SceneManager.LoadSceneAsync(1 + selectedStage);
        }
    }

    public void SetMasterVolume()
    {
        gameManager.SetVolume(volumeSetting.value);
        volumeMixer.SetFloat("MasterVolume", Mathf.Log10(volumeSetting.value) * 20);
    }
    public void VolumeSliderChange()
    {
        if (true)
        {
            PlayClickingSound();
        }
    }
    public void PlayClickingSound()
    {
        if (clickSound != null)
        {
            GameObject newAudio = new GameObject();
            AudioSource audioSource = newAudio.AddComponent<AudioSource>();
            audioSource.clip = clickSound;
            audioSource.outputAudioMixerGroup = volumeMixerGroup;
            audioSource.Play();

            DontDestroyOnLoad(newAudio);

            Destroy(newAudio, clickSound.length);
        }
    }

    public void Stage1()
    {
        selectedStage = 1;
    }
    public void Stage2()
    {
        selectedStage = 1;
    }
    public void Stage3()
    {
        selectedStage = 1;
    }
    public void Stage4()
    {
        selectedStage = 1;
    }
    public void Stage5()
    {
        selectedStage = 1;
    }
}
