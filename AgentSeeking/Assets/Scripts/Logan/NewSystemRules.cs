using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Logan
{
    public class NewSystemRules : MonoBehaviour
    {
        public List<Boid> Boids;
        [Range(0, 10)]
        public float S, A, Arr, Mass, Speed;
        public int Radius;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            change_all_boids_position();
        }

        private void change_all_boids_position()
        {
            foreach (Boid b in Boids)
            {
                b.Velocity = b.Position.normalized;
                var desiredVelocity = transform.position - b.Position;
                var seeking = (desiredVelocity.normalized - b.Velocity.normalized)*S;
                var avoid = (b.Position - transform.position)*A;
                float arrivalStrength;
                if (desiredVelocity.magnitude <= Radius)
                    arrivalStrength = desiredVelocity.magnitude/Radius;
                else
                    arrivalStrength = 0;
                var arrival = (b.Position - transform.position)*arrivalStrength * Arr;
                var steering = seeking + avoid + arrival;
                if (b.Velocity.magnitude > 5)
                    b.Velocity = b.Velocity.normalized;
                b.Velocity += steering;
                b.Position += (b.Velocity/Mass)*Speed;
            }
        }
    }
}
