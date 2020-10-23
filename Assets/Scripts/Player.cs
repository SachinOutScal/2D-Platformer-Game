using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public HealthUIController healthUIController; 
    public Vector3 originalPos;
    int lives; 

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        PlayerInit();
    }


    public void OnDeath()
    {      
        SoundManager.Instance.Play(SoundList.PlayerDeath); 
        gameOverController.OnGameOver();       
    }

    public void UpdateLives()
    {
        lives--;
       
        if (lives == 0)
        {
            
            Animator anim = GetComponent<Animator>();
            if (anim != null)
            {           
               anim.SetTrigger("OnDeath");
            }
        }
        if( lives>=0 )
        {
            healthUIController.LivesDisplayUpdate(lives);
        }
    }


    internal void PickUpKey()
    {        
        scoreController.IncrementScore(10); 
    }
    public void PlayerInit()
    {
        transform.position = originalPos;
        lives = 3; 
    }

}
