using System.Collections;
using UnityEngine;
using Movement;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField]
        bool isCorrectPlatform = false;
        [SerializeField]
        Material correctPlatformMaterial, incorrectPlatformMaterial;
        [SerializeField]
        [Tooltip("Sets time for the platform to get destroyed if the platform landed on was not the correct one")]
        float destroyObjectTimer = 1f;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag != "Player") return;
            ToggleObjectMovement(other.gameObject);
            if (!isCorrectPlatform)
            {
                StartCoroutine(StartWrongPlatformSequence());
            }
            else
            {
                GetComponent<Renderer>().material = correctPlatformMaterial;
            }

        }

        private IEnumerator StartWrongPlatformSequence()
        {
            GetComponent<Renderer>().material = incorrectPlatformMaterial;
            yield return new WaitForSeconds(destroyObjectTimer);
            Destroy(gameObject);
        }
        private void ToggleObjectMovement(GameObject affectedObject)
        {
            affectedObject.GetComponent<FirstPersonMovement>().ToggleMovement(isCorrectPlatform);
            affectedObject.GetComponent<Jump>().ToggleJump(isCorrectPlatform);
        }
    }

}