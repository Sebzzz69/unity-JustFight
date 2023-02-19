using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpControllerScript : MonoBehaviour
{
    [SerializeField]
    Transform weaponHolder, player;
    Transform weaponTransform;

    GameObject weaponObject;

    [SerializeField]
    float dropForwardForce;
    [SerializeField]
    float dropUpwardForce;

    bool dropped;

    [SerializeField]
    KeyCode dropKey;

    bool equipped;

    private void Start()
    {
        equipped = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(dropKey))
        {
            dropped = true;
        }
            
    }

    private void FixedUpdate()
    {
        if (dropped)
        {
            Drop();
            dropped = false;
        }
    }

    private void Drop()
    {
        
       
        Rigidbody rigidbody = weaponObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        Collider collider = weaponObject.GetComponent<Collider>();
        collider.isTrigger = false;

        weaponTransform.transform.SetParent(null);
        equipped = false;

        // Add forces to the object
        if (player.transform.rotation.eulerAngles.y == 180)
        {
            rigidbody.AddForce(-Vector3.right * dropForwardForce, ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(Vector3.right * dropForwardForce, ForceMode.Impulse);
        }
        rigidbody.AddForce(Vector3.up * dropUpwardForce, ForceMode.Impulse);
    }

    private void PickUp()
    {
        equipped = true;

        // Sets default values
        weaponTransform.localPosition = weaponHolder.localPosition;
        weaponTransform.localRotation = weaponHolder.localRotation;
        weaponTransform.localScale = Vector3.one;

        Rigidbody rigidbody = weaponObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        Collider collider = weaponObject.GetComponent<Collider>();
        collider.isTrigger = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Weapon") && !equipped)
        {
            collision.gameObject.transform.SetParent(weaponHolder);

            weaponObject = collision.gameObject;
            weaponTransform = collision.gameObject.GetComponent<Transform>();

            PickUp();

            
        }
       
    }
}
