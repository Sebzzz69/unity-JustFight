using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   [SerializeField]  WeaponSO weaponType;

    public float bulletSpeed { get; set; }
    public float bulletDamage { get; private set; }
    string weaponName;


    public Transform firePoint;
    GameObject bulletPrefab;

    public KeyCode shootButton;

    private void Awake()
    {
        this.bulletPrefab = weaponType.bulletPrefab;

    }

    private void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
            Debug.Log("Player shot");
        }

    }

    private void Shoot()
    {
         if (bulletPrefab != null)
        {
            // Instaniates the bullet prefab
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
