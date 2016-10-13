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
            Vector3 avoid = (transform.position - targetTrans.position) * avM;
            if (dV.magnitude <= radius)
                ArrStr = dV.magnitude / radius;
            else
                ArrStr = 0;
            Vector3 arrival = (transform.position.normalized - targetTrans.position.normalized) * ArrStr;
            Vector3 steering = seeking + avoid + arrival;
            if (cV.magnitude > 5)   //Manual clamp(?)
                cV = cV.normalized;
            cV += steering;
            transform.position += (cV / mass) * speed;

            //These two lines of code change the colors of the parent Gameobject based on the magnitude of the Desired Velocity
            baseColor = new Color(1 - dV.magnitude * .1F, 0 + dV.magnitude * .1F, 0);
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", baseColor);
        }
    }
}