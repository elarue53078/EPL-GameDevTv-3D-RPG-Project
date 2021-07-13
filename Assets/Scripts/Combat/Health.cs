using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = healthPoints > damage ? healthPoints - damage : 0;
            print("HP: " + healthPoints);
            if(!isDead && healthPoints == 0)
            {
                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
            }
        }
    }
}
