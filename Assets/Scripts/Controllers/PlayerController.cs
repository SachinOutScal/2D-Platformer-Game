﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    
    [SerializeField]  private float _speed =5.0f;
    [SerializeField] private float _jump = 10.0f;  // jump force added
    private Rigidbody2D rb2D;
  
    bool isCrouch;
    bool isGrounded; 
    // Start is called before the first frame update
    void Start()
    {
       
        isCrouch = false;
        isGrounded = true;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()    {


        float _speedInput = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = Input.GetAxisRaw("Jump");  // configured to space key

        isCrouch = Input.GetButtonDown("Crouch");  // 
        
            PlayerAnimationMovement(_speedInput, _verticalMovement);
            PlayerTransformMoves(_speedInput, _verticalMovement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Debug.Log("ground collsion ");
         
           isGrounded = true;
           
            animator.SetBool("isGrounded", true);
        }
    }

   
    void PlayerTransformMoves(float _speedInput, float _verticalMovement)
    {
        if (_speedInput != 0)
        {
            Vector3 position = transform.position;
            position.x += _speedInput * _speed * Time.deltaTime;
            transform.position = position;

            SoundManager.Instance.Play(SoundList.PlayerMove); 

        }
       
       
        // JUMP 

        if(_verticalMovement > 0 && isGrounded )  
        {
            SoundManager.Instance.Play(SoundList.PlayerJump);
            isGrounded = false; 
            rb2D.AddForce(new Vector2(0,_jump), ForceMode2D.Impulse);
            Debug.Log("JUMMP FORCE " + _jump); 
            animator.SetBool("isGrounded", false);
        } 
    }

  
   

    void PlayerAnimationMovement(float _speedInput , float _verticalMovement )
    {
        //MOVE
        animator.SetFloat("speed", Mathf.Abs(_speedInput));
        Vector3 scale = transform.localScale;
        if (_speedInput < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (_speedInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

            

        // CROUCH

        if (isCrouch)
        {
            animator.SetBool("isCrouch", true);
            isCrouch = false; 
        }
        else 
        {
            animator.SetBool("isCrouch", false);
        
        }
    }
}
