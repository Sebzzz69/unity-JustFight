using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/WeaponTypes")]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField] public string weaponName { private set; get; }

    [field: SerializeField] public Mesh weaponMesh { private set; get; }

    [field: SerializeField] public GameObject bulletPrefab { private set; get; }
    


}
