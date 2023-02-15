using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfWeapon : MonoBehaviour
{

    public bool weaponIsEquipped;


    public void WeaponIsNotEquipped()
    {
        weaponIsEquipped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            weaponIsEquipped = true;
        }
    }
}
