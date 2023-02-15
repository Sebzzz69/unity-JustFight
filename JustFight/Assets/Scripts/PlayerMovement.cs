using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float time = 0;

    Rigidbody rigidbody;

    public float jumpforce = 10f;
    float remaningJumps = 0f;

    public float moveSpeed = 1000f;
    float tempMovSpeed;

    [Header("Input")]
    [SerializeField] KeyCode moveRight;
    [SerializeField] KeyCode moveLeft;
    [SerializeField] KeyCode jumpKey;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        tempMovSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(moveRight))
        {
            tempMovSpeed = moveSpeed;
            transform.Translate(Vector3.right * tempMovSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            tempMovSpeed = moveSpeed;
            transform.Translate(-Vector3.right * tempMovSpeed * Time.deltaTime);
        }
        if (remaningJumps > 0)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                rigidbody.AddForce(Vector3.up * jumpforce, (ForceMode)ForceMode2D.Impulse);
                _ = remaningJumps-- * Time.deltaTime;
                time = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            remaningJumps = remaningJumps + 1;
            Debug.Log("yee");
        }
       /* if (collision.gameObject.CompareTag("Walls"))
        {
            tempMovSpeed = 0f;
        }*/

    }

   /* private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            tempMovSpeed = moveSpeed;
        }
    }*/
}