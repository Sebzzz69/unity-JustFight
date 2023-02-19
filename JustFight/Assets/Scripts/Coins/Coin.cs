using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    float teleportTimer;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TeleportCoin();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("spwaned in ground");

            TeleportCoin();
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("spwaned in ground");

            TeleportCoin();
        }
    }


}