using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/BulletTypes")]
public class BulletSO : ScriptableObject
{
    [field: SerializeField] public float damage { private set; get; }
    [field: SerializeField] public float projectileSpeed { private set; get; }
}
