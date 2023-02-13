using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float time = 0;

    Rigidbody rigidbody;

    public float jumpforce = 10f;
    float remaningJumps = 0f;

    public float moveSpeed = 1000f;

    [Header("Input")]
    [SerializeField] KeyCode moveRight;
    [SerializeField] KeyCode moveLeft;
    [SerializeField] KeyCode jumpKey;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(moveRight))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (remaningJumps > 0)
        {
            if (Input.GetKey(jumpKey))
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
            remaningJumps = remaningJumps + 10;
            Debug.Log("yee");
        }

    }
}