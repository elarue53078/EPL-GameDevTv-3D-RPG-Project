using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        Transform target;
        float timeSinceAttack = 0;

        private void Update()
        {
            timeSinceAttack += Time.deltaTime;

            if (target == null) return;

            if (target != null && !GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }
        }

        private void AttackBehavior()
        {
            if(timeSinceAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceAttack = 0;
            }
        }

        // Animation Event (triggered within animator)
        void Hit()
        {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("Where's my money, bitch!?");
            GetComponent<ActionScheduler>().StartAction(this);
        }

        public void Cancel()
        {
            target = null;
        }
    }
}


