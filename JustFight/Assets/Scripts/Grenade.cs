using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] float radius = 20;
    [SerializeField] float explotionForce = 700f;

    [SerializeField] float damage;


    float upwardsForce = 5f;
    float countdown;

    bool hasExploded;

    private void Start()
    {
        countdown = delay;
        hasExploded = false;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
        }
    }


    private void Explode()
    {
        hasExploded = true;

        // Show effect --> particles/sound effect

        // Get nerby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rigidbody = nearbyObject.GetComponentInParent<Rigidbody>();
            
            if(rigidbody != null)
            {

                // Grenade does not work anymore
                if (nearbyObject.TryGetComponent<AnimationScript>(out AnimationScript animation))
                {
                    PlayerHealth playerHealth = nearbyObject.GetComponentInParent<PlayerHealth>();
                    playerHealth.TakeDamage(damage);
                    Debug.Log("grenade damage");
                }
                

                // Adds force
                rigidbody.AddExplosionForce(explotionForce * 200, transform.position, radius, 100f);
                Debug.Log(nearbyObject.gameObject.name);

                

            }
            
        }

        // Remove grenade
        Destroy(this.gameObject);
    }
}
