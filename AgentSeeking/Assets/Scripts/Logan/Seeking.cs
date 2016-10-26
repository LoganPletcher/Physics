using UnityEngine;
using System.Collections;

namespace Logan
{
    public class Seeking : MonoBehaviour
    {
        public Transform targetTrans;   //Target transform
        public Vector3 V;               //Velocity
        public Vector3 cV;              //Current Velocity
        public float   sM = 0,          //seeking magnitude
                       avM = 0,         //avoid Magnitude
                       mass = 0, speed = 0, radius = 0,
                       ArrStr = 0,      //Arrival Strength
                       aM = 0;          //Arrival Magnitude
        public Color baseColor;
        // Use this for initialization
        void Start()
        {
            V = transform.position.normalized;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 dV = (targetTrans.position - transform.position);   //Desired Velocity
            Vector3 seeking = (dV.normalized - V.normalized) * sM;
            Vector3 avoid = (transform.position - targetTrans.position).normalized * avM;
            if (dV.magnitude <= radius)
            {
                ArrStr = dV.magnitude / radius;
            }
            else
            {
                ArrStr = 0;
            }
            Vector3 arrival = (transform.position - targetTrans.position).normalized * ArrStr * aM;
            Vector3 steering = seeking + avoid + arrival;
            if (V.magnitude > 5)
            {
                V = V.normalized;
            }
            V = V.normalized + steering;
            transform.position += (V / mass) * speed;

            baseColor = new Color(1 - dV.magnitude * .1F, 0 + dV.magnitude * .1F, 0);
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", baseColor);
        }
    }
}