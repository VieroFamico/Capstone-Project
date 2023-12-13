using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI start;
    [SerializeField] private GameObject setting;
    [SerializeField] private TextMeshProUGUI quit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
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
}
