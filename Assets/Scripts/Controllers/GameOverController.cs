using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public GameObject gameOverPanel;
    public Button restartLevel;
    public Button mainMenu; 



    void Start()
    {
        restartLevel.onClick.AddListener(ReLoadLevel);
        mainMenu.onClick.AddListener(LoadMainMenu);

    }

    public void OnGameOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);


    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene(0); 
    }

    public void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
