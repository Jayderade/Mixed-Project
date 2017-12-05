using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : AIAgent {

    [Header("Zombie")]    
    public int damage = 10;
    public float decay = 1;
    public float attackRange = 2f;
    public float attackSpeed = .5f;
    public float attackDuration = 1;

    protected Rigidbody rigid;
    protected NavMeshAgent nav;

    private float attackTimer = 0f;

   

    protected virtual void Awake()
    {             
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if(target == null)
        {
            return;
        }

        attackTimer += Time.deltaTime;
        if(attackTimer >= attackSpeed)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance < attackRange)
            {
                Attack();
                attackTimer = 0f;
                StartCoroutine(AttackDelay(attackDuration));
            }
        }
        nav.SetDestination(target.position);
    }

	IEnumerator AttackDelay(float delay)
    {
        nav.Stop();

        yield return new WaitForSeconds(delay);

        nav.Resume();
        OnEndAttack();
    }

    protected virtual void Attack()
    {
        Debug.Log("Works");
    }
    protected virtual void OnEndAttack()
    {

    }
}
