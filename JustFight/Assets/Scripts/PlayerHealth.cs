using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field:SerializeField] public float health { get; private set; }
    [field: SerializeField] public float maxHealth { get; private set; }

    private void Start()
    {
        this.health = this.maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            // Report this to gameManager
            // Do something about it

            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        if (this != null)
        {
            Destroy(this.gameObject);
        }
       // Debug.Log("Player died");
    }

    public void TakeDamage(float damageAmount)
    {

        Debug.Log("Player took damage");
        health -= damageAmount;
        
    }




}
