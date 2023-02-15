using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            TeleportCoin();
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit");

            TeleportCoin();
        }
    }

    void TeleportCoin()
    {

        gameObject.transform.position = new Vector3(Random.Range(-53, 52), Random.Range(2, 35));

    }

}