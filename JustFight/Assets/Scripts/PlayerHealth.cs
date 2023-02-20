using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float respawnTime = 2f;
    float health;

    Vector2 respawnPoint;

    private void Start()
    {
        this.health = this.maxHealth;
        respawnPoint = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
    }

    private void Update()
    {
        if (health <= 0)
        {

            KillPlayer();
            Invoke("RespawnPlayer", respawnTime);
        }
    }

    private void KillPlayer()
    {
           this.gameObject.SetActive(false);
        
           Debug.Log("Player died");
    }

    public void TakeDamage(float damageAmount)
    {

        Debug.Log("Player took damage");
        health -= damageAmount;
        
    }

    void RespawnPlayer()
    {
        this.gameObject.transform.position = respawnPoint;
        this.gameObject.SetActive(true);
        this.health = this.maxHealth;
    }



}
