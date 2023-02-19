using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   [SerializeField]  WeaponSO weaponType;

    public float bulletSpeed { get; set; }
    public float bulletDamage { get; private set; }

    [SerializeField] float fireRate = 0.2f;

    string weaponName;

    bool allowFire = true;


    public Transform firePoint;
    GameObject bulletPrefab;

    public KeyCode shootButton;

    private void Awake()
    {
        this.bulletPrefab = weaponType.bulletPrefab;
        fireRate = 0.2f;

    }

    private void Update()
    {
        if (Input.GetKey(shootButton) && allowFire)
        {
            Shoot();
            allowFire = false;

           // Debug.Log("Player shot");

            StartCoroutine(WaitToFire());
            
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

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(fireRate);
        allowFire = true;
    }
}
