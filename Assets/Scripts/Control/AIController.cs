using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        // Update is called once per frame
        void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                print(gameObject.name + " is coming for you, bitch!");
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            return Vector3.Distance(transform.position, player.transform.position);
        }
    }
}
