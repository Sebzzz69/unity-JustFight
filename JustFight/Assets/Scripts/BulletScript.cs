using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] BulletSO bulletType;

    [SerializeField] float speed;
    [SerializeField] float damageAmount;

    Vector3 playerForward = new Vector3 (1f, 0f, 0f);

    public new Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        this.speed = bulletType.projectileSpeed;
        this.damageAmount = bulletType.damage;
        
    }



    private void Update()
    {
        transform.Translate(playerForward * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        if (this != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void PlayerHit()
    {
       // Debug.Log("Player Hit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // The hit player takes damage
            PlayerHealth health = collision.gameObject.GetComponentInParent<PlayerHealth>();
            health.TakeDamage(damageAmount);

            PlayerHit();
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Walls"))
        {
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyBullet();
        }
    }
}
