using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

    private Rigidbody2D playerRB;
    private float horinzontalInput;
    private float verticalInput;

    [SerializeField] private float speed;

    
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
        CheckMovement();
    }

    private void CheckInput()
    {
        horinzontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void CheckMovement()
    {
        Vector2 movement = new Vector2(horinzontalInput, verticalInput);
        playerRB.velocity = movement * speed * Time.deltaTime;
    }

	
}
