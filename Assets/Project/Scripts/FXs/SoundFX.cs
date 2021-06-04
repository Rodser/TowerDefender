using UnityEngine;

namespace Assets.Project.Scripts.FXs
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundFX : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _audioClip;
        [SerializeField, Range(-1f, 1f)]
        private float _minPitch;
        [SerializeField, Range(-3f, 3f)]
        private float _MaxPitch;

        private void Awake()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = _audioClip;
            audioSource.pitch = Random.Range(_minPitch, _MaxPitch);
            audioSource.Play();
        }
    }
}
