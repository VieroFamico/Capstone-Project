using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private AudioClip clickSound;
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
        StartCoroutine(EStartGame());
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
        if (setting.activeSelf)
        {   
            
            setting.SetActive(false);
        }
        else { setting.SetActive(true); }
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

    public void PlayClickingSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    public void Stage1()
    {
        selectedStage = 1;
    }
    public void Stage2()
    {
        selectedStage = 2;
    }
    public void Stage3()
    {
        selectedStage = 3;
    }
    public void Stage4()
    {
        selectedStage = 4;
    }
    public void Stage5()
    {
        selectedStage = 5;
    }
}
