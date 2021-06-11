using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFX : MonoBehaviour {
    [Header("Engine Effects")]
    [SerializeField] private ParticleSystem engineFlame;
    [SerializeField] private AudioClip engineSound;

    [Header("Explosion Effects")]
    [SerializeField] private ParticleSystem explosionFlame;
    [SerializeField] private AudioClip explosionSound;

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

    public void PlayExplosion() {
        if (explosionSound && _audioSource) _audioSource.PlayOneShot(explosionSound);
        if (explosionFlame) explosionFlame.Play();
    }
}
