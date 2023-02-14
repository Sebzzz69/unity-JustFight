using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] WeaponManager gunScript;

    [SerializeField] Rigidbody rigidbody;
    [SerializeField] BoxCollider collider;
    [SerializeField] Transform player, gunContainer;
    [SerializeField] GameObject playerObject;

    WeaponManager weaponManager;

    [SerializeField] float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public /*static*/ bool slotFull;
    [SerializeField] bool pickable;

    [SerializeField] KeyCode dropKey;


    private void Start()
    {
        // Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rigidbody.isKinematic = false;
            collider.isTrigger = false;

            weaponManager = GetComponent<WeaponManager>();
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rigidbody.isKinematic = true;
            collider.isTrigger = true;
            slotFull = true;

            weaponManager = GetComponent<WeaponManager>();
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
        pickable = false;

        // Gets the trasform of the parent 
        player = GetComponentInParent<Transform>();

        weaponManager = GetComponent<WeaponManager>();
        

        // Make weapon a child of the gun container and move it to defaul position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        // Change the input depending on
        // which player picks it up
        if (weaponManager != null)
        {
            if (gunContainer.GetComponentInParent<PlayerOneComponent>())
            {
                weaponManager.shootButton = KeyCode.F;
            }
            else if (gunContainer.GetComponentInParent<PlayerTwoComponent>())
            {
                weaponManager.shootButton = KeyCode.J;
            }
        }

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
        pickable = true;

        // Set parent to null
        transform.SetParent(null);

        // Make Rigibody not kinematic and BoxCollider normal
        rigidbody.isKinematic = false;
        collider.isTrigger = false;

        // Sets the shoot button to null
        if (weaponManager != null)
        {
            weaponManager.shootButton = KeyCode.None;
        }
       

        // Gun carriers momentum of player
        rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

        // Addforce
        // FIX::
        // Forwardforce is not working

        if (player.transform.rotation.eulerAngles.y >= 180)
        {
            rigidbody.AddForce(-Vector3.right * dropForwardForce, ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(Vector3.right * dropForwardForce, ForceMode.Impulse);
        }
        rigidbody.AddForce(Vector3.up * dropUpwardForce, ForceMode.Impulse);

        // Sets transform to null
        player = null;

        // Set gun container to null
        gunContainer = null;

        // Disable GunScript
        gunScript.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // player 2 tag fix
        // Check if player collides with a weapon
        if ((collision.gameObject.CompareTag("Player") && !equipped && !slotFull))
        {
            // Gets the transform of the gun conatiner in player
            gunContainer = collision.gameObject.GetComponentInChildren<ItemHolder>().transform;

            // Picks up weapon
            PickUp();
        }
        else if ((collision.gameObject.CompareTag("Player2") && !equipped && !slotFull))
        {

            // Gets the transform of the gun conatiner in player
            gunContainer = collision.gameObject.GetComponentInChildren<ItemHolder>().transform;

            // Picks up weapon
            PickUp();
        }
        else
        {

        }

    }
}
