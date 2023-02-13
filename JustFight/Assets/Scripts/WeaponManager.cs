using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   [SerializeField]  WeaponSO weaponType;

  /*  public float bulletSpeed { get; set; }
    public float bulletDamage { get; private set; }
    string weaponName;*/


    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] KeyCode shootButton;

    private void Awake()
    {
        /*this.bulletDamage = weaponType.damage;
        this.bulletSpeed = weaponType.projectileSpeed;

        this.weaponName = weaponType.weaponName;
        this.gameObject.name = weaponName;*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
