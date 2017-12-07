﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{

    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;
        public Vector3 velocity;
        public float maxVelocity;
        public float maxDistance = 10f;
        public bool freezeRotation = false;

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;

        // Use this for initialization
        void Start()
        {
            Zombie zombie = gameObject.GetComponent<Zombie>();

            maxVelocity = zombie.speed * 0.01f;

            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            // SET force = Vector3.zero
            force = Vector3.zero;

            // FOR i := 0 to behaviours.Count
            for (int i = 0; i < behaviours.Count; i++)
            {
                // LET behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i]; // Elements in the List are of SteeringBehaviour type

                // IF behaviour.isActive == false
                if (behaviour.isActiveAndEnabled == false)
                {
                    // continue skips over to next element
                    continue;
                }

                // SET force = force + behaviour.GetForce() x weighting
                force = force + behaviour.GetForce() * behaviour.weight;

                // IF force.magnitude > maxVelocity
                if(force.magnitude > maxVelocity)
                {
                    // SET force = force.normalized x maxVelocity
                    force = force.normalized * maxVelocity;

                    // break
                    break;
                }
            }
        }

        void ApplyVelocity()
        {
            // SET velocity = velocity + force x deltaTime
            velocity += force * Time.deltaTime;

            // IF velocity.magnitude > maxVelocity
            if (velocity.magnitude > maxVelocity)
            {
                // SET velocity = velocity.normalized x maxVelocity
                velocity = velocity.normalized * maxVelocity;
            }                

            // IF velocity.magnitude > 0
            if (velocity.magnitude > 0)
            {
                // SET transform.position = transform.position + velocity x deltaTime
                transform.position += velocity * Time.deltaTime;
                // SET transform.rotation = Quaternion LookRotation (velocity)
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }

        // Update is called once per frame
        void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}
