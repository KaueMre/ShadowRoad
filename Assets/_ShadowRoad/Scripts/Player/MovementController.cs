using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour 
{

    private Rigidbody2D playerRB;
    private float horinzontalInput;
    private float verticalInput;
    private Animator playerAnimator;

    public Action OnMovementEvent;
    public Action OnAtackEvent;
    public Action OnStopAtackEvent;
    public Action OnIdleEvent;

    public Animator GetAnimator
    {
        get
        {
            return playerAnimator;
        }
    }

    [SerializeField] private float speed;
   

    
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


    }

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

    //Dispatchers

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


}
