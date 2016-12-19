using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


namespace Logan
{
    public class SystemRules : MonoBehaviour
    {
        public Transform Predator;
        public Vector3 wind;
        [Range(0, 10)]
        public float c, s, a, t, l, p;
        [Range(-100,100)]
        public int Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;
        public List<Boid> Boids;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            change_all_boids_position();
        }

        Vector3 Cohesion(Boid bj)  //Cohesion
        {
            Vector3 pc = new Vector3();
            foreach (Boid b in Boids)
            {
                if (b != bj)
                {
                    pc = pc + b.Position;
                }
            }
            pc = pc / (Boids.Count - 1);
            return ((pc - bj.Position) / 1000) * c;
        }

        Vector3 Dispersion(Boid bj)  //Separation
        {
            Vector3 c = new Vector3(0,0,0);
            foreach (Boid b in Boids)
            {
                if (b != bj)
                {
                    if (Mathf.Abs((b.Position - bj.Position).magnitude) < s)
                    {
                        c = (c - (b.Position - bj.Position));
                    }
                }
            }
            return c;
        }
        Vector3 Alignment(Boid bj)  //Alignment
        {
            Vector3 pv = bj.Velocity.normalized;
            foreach(Boid b in Boids)
            {
                if(b != bj)
                {
                    pv = pv + b.Velocity;
                }
            }
            pv = pv / (Boids.Count - 1);

            return ((pv - bj.Velocity) / 8) * a;
        }

        Vector3 Tendency(Boid bj)
        {
            Vector3 target = transform.position;
            return ((target - bj.Position) / 10);
        }

        void limit_Velocity(Boid b)
        {
            if (b.Velocity.magnitude > l)
            {
                b.Velocity = ((b.Velocity / b.Velocity.magnitude) * l);
            }
        }

        Vector3 bound_position(Boid b)
        {
            Vector3 v = new Vector3(0,0,0);

            if(b.Position.x < Xmin)
            {
                v.x = 10;
            }
            else if(b.Position.x > Xmax)
            {
                v.x = -10;
            }

            if(b.Position.y < Ymin)
            {
                v.y = 10;
            }
            else if(b.Position.y > Ymax)
            {
                v.y = -10;
            }

            if(b.Position.z < Zmin)
            {
                v.z = 10;
            }
            else if(b.Position.z > Zmax)
            {
                v.z = -10;
            }
            return v;
        }

        Vector3 AvoidPredator(Boid b)
        {
            if(Mathf.Abs((Predator.position - b.Position).magnitude) < 100)
            {
                return -((Predator.position - b.Position) / 20);
            }
            return Vector3.zero;
        }

        void change_all_boids_position()
        {
            Vector3 v1, v2, v3, v4, v5;
            foreach (Boid B in Boids)
            {
                v1 = Cohesion(B);
                v2 = Dispersion(B);
                v3 = Alignment(B);
                v4 = Tendency(B) * t;
                v5 = bound_position(B);
                
                B.Velocity = (B.Velocity + v1 + v2 + v3 + v4 + v5);
                limit_Velocity(B);
                B.Position = B.Velocity + B.Position;
            }
        }

        public void ChangeC(Slider CSlider)
        {
            c = CSlider.value;
            CSlider.GetComponentInChildren<Text>().text = "Cohesiveness: " + c;
        }

        public void ChangeS(Slider SSlider)
        {
            s = SSlider.value;
            SSlider.GetComponentInChildren<Text>().text = "Seperation: " + s;
        }
        public void ChangeA(Slider ASlider)
        {
            a = ASlider.value;
            ASlider.GetComponentInChildren<Text>().text = a + " :Alignment";
        }
        public void ChangeT(Slider TSlider)
        {
            t = TSlider.value;
            TSlider.GetComponentInChildren<Text>().text = t + " :Tendency";
        }
    }
}