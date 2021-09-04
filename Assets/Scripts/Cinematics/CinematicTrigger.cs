using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool triggerTest;

        private void OnTriggerEnter(Collider collider)
        {
            if (!triggerTest && collider.tag == "Player")
            {
                triggerTest = true;
                GetComponent<PlayableDirector>().Play();
            }
        }
    }
}

