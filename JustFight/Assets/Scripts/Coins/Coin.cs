using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    float collisionCheckDistance = 10f;
    bool willCollide;

    float teleportTimer;
    Rigidbody rigibody;

    private void Start()
    {
        rigibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       // TeleportTimer();
    }

    void TeleportTimer()
    {
        if (teleportTimer >= 10)
        {
            TeleportCoin();
            teleportTimer = 0f;
        }
        teleportTimer += 1 * Time.deltaTime;
    }

    void TeleportCoin()
    {

        this.gameObject.transform.position = new Vector3(Random.Range(-53, 52), Random.Range(2, 35), this.gameObject.transform.position.z);

    }

    private void NewCoinPosition()
    {
        TeleportCoin();

        RaycastHit hit;
        if(rigibody.SweepTest(transform.right, out hit, collisionCheckDistance) || rigibody.SweepTest(transform.up, out hit, collisionCheckDistance))
        {
            TeleportCoin();
            Debug.Log("Coin insde moved");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NewCoinPosition();
        }


    }


}