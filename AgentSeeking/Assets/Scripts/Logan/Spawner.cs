using UnityEngine;
using System.Collections.Generic;

namespace Logan
{
    public class Spawner : MonoBehaviour
    {
        public GameObject boid;
        private Vector3 Spawn;
        public int amount = 90;
        // Use this for initialization
        void Start()
        {
            for (int i = 1; i <= amount; ++i)
            {
                if (i % 4 == 0)
                {
                    int x = Random.Range(100, 1);
                    int y = Random.Range(1, 100);
                    int z = Random.Range(-100, -1);
                    Spawn = new Vector3(x, y, z);
                    Instantiate(boid, Spawn, Quaternion.identity);
                    boid.GetComponent<Boid>().Position = Spawn;
                    boid.GetComponent<Boid>().Velocity = boid.transform.forward;
                }
                else if (i % 3 == 0)
                {
                    int x = Random.Range(-100, -1);
                    int y = Random.Range(1, 100);
                    int z = Random.Range(100, 1);
                    Spawn = new Vector3(x, y, z);
                    Instantiate(boid, Spawn, Quaternion.identity);
                    boid.GetComponent<Boid>().Position = Spawn;
                    boid.GetComponent<Boid>().Velocity = boid.transform.forward;
                }
                else if (i % 2 == 0)
                {
                    int x = Random.Range(-100, -1);
                    int y = Random.Range(1, 100);
                    int z = Random.Range(-100, -1);
                    Spawn = new Vector3(x, y, z);
                    Instantiate(boid, Spawn, Quaternion.identity);
                    boid.GetComponent<Boid>().Position = Spawn;
                    boid.GetComponent<Boid>().Velocity = boid.transform.forward;
                }
                else
                {
                    int x = Random.Range(1, 100);
                    int y = Random.Range(1, 100);
                    int z = Random.Range(1, 100);
                    Spawn = new Vector3(x, y, z);
                    Instantiate(boid, Spawn, Quaternion.identity);
                    boid.GetComponent<Boid>().Position = Spawn;
                    boid.GetComponent<Boid>().Velocity = boid.transform.forward;
                }
            }
            GetComponent<SystemRules>().Boids = PopulateBoidList();
        }

        // Update is called once per frame
        void Update()
        {

        }

        List<Boid> PopulateBoidList()
        {
            List<Boid> Return = new List<Boid>();
            foreach(Boid b in FindObjectsOfType<Boid>())
            {
                Return.Add(b);
            }
            return Return;
        }
    }
}