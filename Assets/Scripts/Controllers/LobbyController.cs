using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button newGameButton;
    public Button levelsButton; 
    public GameObject LevelSelectionParent; 
    private void Start()
    {
        newGameButton.onClick.AddListener(LoadNewGame);
        levelsButton.onClick.AddListener(LevelSelection);
    }

    private void LevelSelection()
    {
        
        SoundManager.Instance.Play(SoundList.ButtonClickPlay); 
        
        newGameButton.transform.parent.gameObject.SetActive(false);
        LevelSelectionParent.SetActive(true);



    }

    private void LoadNewGame()
    {
        SoundManager.Instance.Play(SoundList.ButtonClickPlay);

        SceneManager.LoadScene(1); 
    }





}
