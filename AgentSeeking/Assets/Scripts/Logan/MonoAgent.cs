using UnityEngine;
using System.Collections;

namespace Logan
{
    public class MonoAgent : MonoBehaviour
    {
        public Agent agent = new Agent();

        // Use this for initialization
        void Start()
        {
            agent = new Agent();
            //transform.position = new Vector3(agent.Position.x, agent.Position.y, agent.Position.z);
            //this.GetComponent<LPseeking>().V = new Vector3(agent.Velocity.x, agent.Velocity.y, agent.Velocity.z);
            //this.GetComponent<LPseeking>().mass = agent.Mass;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
