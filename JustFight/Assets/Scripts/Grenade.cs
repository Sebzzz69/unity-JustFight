using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float delay = 3f;
    [SerializeField] float radius = 5f;
    [SerializeField] float explotionForce = 10f;


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
            Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explotionForce, transform.position, radius, upwardsForce);
            }
        }
        // Add force
        // Damage

        // Remove grenade
        Destroy(this.gameObject);
    }
}
