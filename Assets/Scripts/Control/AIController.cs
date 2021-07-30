﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        Fighter fighter;
        Health health;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;

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
