using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public WeaponManager gunScript;

    public Rigidbody rigidbody;
    public BoxCollider collider;
    public Transform player, gunContainer;

    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    [SerializeField] KeyCode dropKey;


    private void Start()
    {
        // Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rigidbody.isKinematic = false;
            collider.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rigidbody.isKinematic = true;
            collider.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        if (equipped && Input.GetKeyDown(dropKey))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        // Make weapon a child of the gun container and move it to defaul position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        // Make Rigibody kinematic and BoxCollider a trigger
        rigidbody.isKinematic = true;
        collider.isTrigger = true;

        // Enable GunScript
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        // Set parent to null
        transform.SetParent(null);

        // Make Rigibody not kinematic and BoxCollider normal
        rigidbody.isKinematic = false;
        collider.isTrigger = false;

        // Gun carriers momentum of player
        rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

        // Addforce
        // FIX::
        // Forwardforce is not working
        rigidbody.AddForce(Vector3.forward * dropForwardForce, ForceMode.Impulse);
        rigidbody.AddForce(Vector3.up * dropUpwardForce, ForceMode.Impulse);

        // Disable GunScript
        gunScript.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Check if player collides with a weapon
        if (collision.gameObject.CompareTag("Player") && !equipped && !slotFull)
        {
            // Picks up weapon
            PickUp();
        }
        else
        {

        }
    }
}
