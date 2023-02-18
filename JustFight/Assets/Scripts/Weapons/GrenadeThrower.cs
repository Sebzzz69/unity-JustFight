using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] float forwardForce = 20;
    [SerializeField] float upwardForce = 80;

    public bool canThrow;

    [SerializeField] GameObject grenadePrefab;

    [SerializeField] GameObject player;

    [SerializeField] KeyCode throwKey;

    private void Update()
    {
        if (Input.GetKeyDown(throwKey))
        {
            if (canThrow)
            {
                ThrowGrenade();
                canThrow = false;
            }
            
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade =Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rigidbody = grenade.GetComponent<Rigidbody>();

        if (player.transform.rotation.eulerAngles.y == 180)
        {
            rigidbody.AddForce(-Vector3.right * forwardForce, ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(Vector3.right * forwardForce, ForceMode.Impulse);
        }
        rigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
    }


}
