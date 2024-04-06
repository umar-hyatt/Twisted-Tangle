using UnityEngine;

namespace _Twisted._Scripts.ControllerRelated
{
    public class SoundsController : MonoBehaviour
    {
        public static SoundsController instance;

        public AudioSource mainAudioSource;
        public AudioClip pop, cupUp, confetti;

        private void Awake()
        {
            instance = this;
        }

        public void PlaySound(AudioClip clip)
        {
            mainAudioSource.PlayOneShot(clip);
        }
    }   
}
