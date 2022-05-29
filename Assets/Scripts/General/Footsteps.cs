using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    AudioClip[] footstepSounds;

    public void PlayRandomFootstep()
    {
        int index = Random.Range(0, footstepSounds.Length);
        AudioSource.PlayClipAtPoint(footstepSounds[index], transform.position);
    }
}
