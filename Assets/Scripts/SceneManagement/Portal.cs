using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] int sceneToLoad = -1;

        private void OnTriggerEnter(Collider other)
        {
            print("Portal triggered.");
            if(other.tag == "Player")
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
