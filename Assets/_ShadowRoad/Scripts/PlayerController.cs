﻿using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D),(typeof(Animator)))]
public class MovementController : MonoBehaviour
{
    #region private variables
    private Rigidbody2D playerRB;
    private float horinzontalInput;
    private float verticalInput;
    private Animator playerAnimator;
    private bool lookingLeft = false;
    #endregion

    #region actions/events/delegates
    public Action OnMovementEvent;
    public Action OnAtackEvent;
    public Action OnStopAtackEvent;
    public Action OnIdleEvent;
    #endregion

    #region public properties
    public Animator GetAnimator
    {
        get
        {
            return playerAnimator;
        }
    }
    #endregion

    #region serizable variables
    [SerializeField]
    [Header("Variables for player controller")]
    private float speed;
    #endregion

    #region Unity events
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        CheckMovement();
        CheckAtack();
        CheckSideToFlip();
    }
    #endregion

    #region private methods
    private void CheckInput()
    {
        horinzontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void CheckMovement()
    {
        Vector2 movement = new Vector2(horinzontalInput, verticalInput);
        playerRB.velocity = movement * speed * Time.deltaTime;

        if (movement != Vector2.zero)
            DispatchMovementEvent();

        else
            DispatchIdleEvent();
    }

    private void CheckAtack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DispatchAtackEvent();
            Debug.Log("Atacando");
        }

        if (Input.GetMouseButtonUp(1))
        {
            DispatchStopAtackEvent();
            Debug.Log("Parou");
        }
    }

    private void CheckSideToFlip()
    {
        if (horinzontalInput > 0 && lookingLeft == true)
            FlipSprite();

        if (horinzontalInput < 0 && lookingLeft == false)
            FlipSprite();
    }


    private void FlipSprite()
    {
        lookingLeft = !lookingLeft;
        Vector2 spriteScale = transform.localScale;
        spriteScale.x *= -1.0f;
        transform.localScale = spriteScale;
    }
    #endregion

    #region Dispatchers
    private void DispatchMovementEvent()
    {
        if (OnMovementEvent != null)
            OnMovementEvent();
    }

    private void DispatchAtackEvent()
    {
        if (OnAtackEvent != null)
            OnAtackEvent();
    }

    private void DispatchIdleEvent()
    {
        if (OnIdleEvent != null)
            OnIdleEvent();
    }

    private void DispatchStopAtackEvent()
    {
        if (OnStopAtackEvent != null)
            OnStopAtackEvent();
    }
    #endregion
}


