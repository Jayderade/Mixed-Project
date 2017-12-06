using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    [Header("Zombie")]    
    public Transform target;
    public GameObject player;  
    public int dam = 10;
    public float decay = 1f;
    public float health = 100f;
    public float speed = 10f;
    public float attackRange = 5f;
    public float attackSpeed = 1f;
    public float attackDuration = 1f;

    protected Rigidbody rigid;
    protected NavMeshAgent nav;

    public float attackTimer = 0f;

    void Start()
    {
       
    }

    protected virtual void Awake()
    {
        
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        target = player.transform;
    }

    protected virtual void Update()
    {
        
        if (target == null)
        {
            return;
        }

        attackTimer += Time.deltaTime;
        if(attackTimer >= attackSpeed)
        {
            
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance < attackRange)
            {
                
                Attack();
                attackTimer = 0f;
                StartCoroutine(AttackDelay(attackDuration));
            }
        }
        if (target != null)
        {
            nav.SetDestination(target.position);
        }
    }

	IEnumerator AttackDelay(float delay)
    {
        nav.Stop();

        yield return new WaitForSeconds(delay * 1.5f);

        nav.Resume();
        OnEndAttack();
    }

    void Bite()
    {


        Health playerHealth = GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(dam);
        }
    }

    protected virtual void Attack()
    {
        Bite();
    }
    protected virtual void OnEndAttack()
    {        
        
    }
}
