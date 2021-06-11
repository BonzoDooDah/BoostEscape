using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFX : MonoBehaviour {
    [Header("Engine Effects")]
    [SerializeField] private ParticleSystem engineFlame;
    [SerializeField] private AudioClip engineSound;

    private AudioSource _audioSource = null;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayEngineThrust(bool play) {
        if (play) {
            if (engineSound && _audioSource) { if (!_audioSource.isPlaying) _audioSource.PlayOneShot(engineSound); }
            if (engineFlame) engineFlame.Play();
        } else {
            if (_audioSource) _audioSource.Stop();
            if (engineFlame) engineFlame.Stop();
        }
    }
}
