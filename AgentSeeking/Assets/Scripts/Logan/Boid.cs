using UnityEngine;
using System.Collections.Generic;

namespace Logan
{
    public class Boid : MonoBehaviour
    {
        public Vector3 Position;
        public Vector3 Velocity;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.forward = Velocity;
            transform.position = Position;
        }
    }
}