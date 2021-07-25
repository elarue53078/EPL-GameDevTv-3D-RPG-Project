using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                print(gameObject.name + " is coming for you, bitch!");
                fighter.Attack(player);
            } else
            {
                fighter.Cancel();
            }
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position);
        }
    }
}
