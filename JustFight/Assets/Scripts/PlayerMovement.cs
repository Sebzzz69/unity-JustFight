using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 spawnPosition;
    Vector3 playerRortation;

    new Rigidbody rigidbody;

    float time = 0;
    public float jumpforce = 10f;
    float remaningJumps = 0f;
    int maxJumps = 2;

    public float moveSpeed = 1000f;
    float tempMovSpeed;

    bool down = false;

    [SerializeField] GameObject grenadeThrower;

    [Header("Input")]
    [SerializeField] KeyCode moveRight;
    [SerializeField] KeyCode moveLeft;
    [SerializeField] KeyCode jumpKey;
    [SerializeField] KeyCode downKey;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        // Sets the spawn position
        spawnPosition.x = this.gameObject.transform.position.x;
        spawnPosition.y = this.gameObject.transform.position.y;
        spawnPosition.z = this.gameObject.transform.position.z;

        //playerRortation.x = this.gameObject.transform.rotation.x;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(moveRight))
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            

        }

        if (Input.GetKeyDown(downKey) && down)
        {
            transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(jumpKey) && remaningJumps >= maxJumps)
        {
            rigidbody.AddForce(Vector3.up * jumpforce, (ForceMode)ForceMode2D.Impulse);
            remaningJumps--;
            down = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            remaningJumps = 2;
            down = false;
        }
        if (collision.gameObject.CompareTag("Walls"))
        {
            this.gameObject.transform.position = spawnPosition;
            Debug.Log(spawnPosition);
        }
        if (collision.gameObject.CompareTag("FakeGrenade"))
        {

            // Can throw if collided with a 'fake' grenade
            GrenadeThrower thrower = grenadeThrower.GetComponent<GrenadeThrower>();
            thrower.canThrow = true;

            Destroy(collision.gameObject);
        }
    }
}