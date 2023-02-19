using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    #region Variables

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    [Header("Inputs")]
    [SerializeField]
    KeyCode moveLeft;
    [SerializeField]
    KeyCode moveRight;
    [SerializeField]
    KeyCode jumpKey;

    [Header("Checking")]
    [SerializeField]
    LayerMask groundLayer;

    float playerHeight;
    float playerWidth;
    float gravity = -9.81f;

    bool isGrounded;
    bool canJump;
    bool isFacingWall;


    Vector3 direction;
    float moveDirection;

    new Rigidbody rigidbody;

    #endregion

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerHeight = transform.localScale.y;
        playerWidth = transform.localScale.x;
    }

    private void Update()
    {
        GroundCheck();

        PlayerInput();
        JumpInput();

        //Debug.Log(isGrounded);
    }

    private void FixedUpdate()
    {
        if (!isFacingWall)
        {
            MovePlayer();
        }

        if (canJump && isGrounded)
        {
            Jump();
            canJump = false;
        }
    }

    private void LateUpdate()
    {
        
    }


    #region Methods

    private void PlayerInput()
    {
        if (Input.GetKey(moveLeft))
        {
            // Rotates player
            this.gameObject.transform.rotation = Quaternion.Euler(0f, -180f, 0f);

            direction = -Vector3.right;
        }
        else if (Input.GetKey(moveRight))
        {
            // Rotates player
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            direction = Vector3.right;
        }
         else
        {
            direction = Vector3.zero;
        }


        // Converts direction to a float
        moveDirection = direction.x;

    }

    private void MovePlayer()
    {

        // Moves player
        // rigidbody.AddForce(direction * moveSpeed * 10 * Time.fixedDeltaTime, ForceMode.Force);
        rigidbody.velocity = new Vector3(moveDirection * moveSpeed * 15 * Time.fixedDeltaTime, rigidbody.velocity.y, 0f);

    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            canJump = true;
        }
        if (Input.GetKeyUp(jumpKey))
        {
            canJump = false;
        }
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce * 10 * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void GroundCheck() 
    {
        isGrounded = Physics.Raycast(transform.position, Vector2.down, playerHeight / 10, groundLayer);
    }


    #endregion



}

