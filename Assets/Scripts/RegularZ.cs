using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularZ : Zombie {
    [Header("Regular")]
    public AudioSource scream;

    protected override void Awake()
    {
        health = 100;
        base.Awake();
        scream.enabled = false;
    }

    protected override void Update()
    {
        health = health - decay * Time.deltaTime;
        base.Update();
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
        base.OnEndAttack();
        scream.enabled = false;
    }

    

}
