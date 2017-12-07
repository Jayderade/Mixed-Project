using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Zombie {
    [Header("Tank")]
    public AudioSource scream;
    public float splosionRadius = 5f;
    public float splosionRate = 3f;
    public float impactForce = 10f;
    //public GameObject splosionParticles;

    private float splosionTimer = 0f;

    protected override void Awake()
    {
        base.Awake();
        scream.enabled = false;
        health = 200;
    }

    protected override void Update()
    {
        health = health - decay * Time.deltaTime;
        base.Update();
        splosionTimer += Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Attack()
    {
        
        scream.enabled = true;
    }

    protected override void OnEndAttack()
    {
        scream.enabled = false;
        if (splosionTimer > splosionRate)
        {
            // Call Explode()
            Splode();
            Destroy(gameObject);
        }
        
        
    }
    void Splode()
    {
        // Perform Physics OverlapSphere
        Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
        // Loop though all hits
        foreach (var hit in hits)
        {
            // if player
            if (hit.gameObject.name == "Player")
            {
                Health h = hit.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                }
                Rigidbody r = hit.GetComponent<Rigidbody>();
                if (r != null)
                {

                    r.AddExplosionForce(impactForce, transform.position, splosionRadius);
                }
            }
        }
    }


}
