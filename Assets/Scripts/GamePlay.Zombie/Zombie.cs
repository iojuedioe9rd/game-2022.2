using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Zombie
{
    public class Zombie : MonoBehaviour
    {
        public int health;

        public float speed;

        public Color tintColor;

        public string Name;

        public GameObject[] players;

        GameObject GetClosestPlayer(GameObject[] players)
        {
            GameObject tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject t in players)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        private void Awake()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

        private void Update()
        {
            Vector2 dir = Vector2.MoveTowards(transform.position, GetClosestPlayer(players).transform.position, speed * Time.deltaTime);

            transform.position = new Vector3(dir.x, transform.position.y, transform.position.z);
        }
    }
}
