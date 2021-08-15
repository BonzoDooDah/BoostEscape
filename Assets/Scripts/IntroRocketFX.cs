using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroRocketFX : MonoBehaviour {
    [Header("Engine Effects")]
    [SerializeField] private ParticleSystem engineFlame;
    [SerializeField] private AudioClip engineSound;

    [Header("Teleportation Effects")]
    [SerializeField] private ParticleSystem explosionFlame;
    [SerializeField] private AudioClip explosionSound;

    private AudioSource _audioSource = null;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();

        PlayEngineThrust();
    }

    public void PlayEngineThrust() {
        if (engineSound && _audioSource) {
            _audioSource.clip = engineSound;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        if (engineFlame) engineFlame.Play();
    }

    public void PlayExplosion() {
        if (explosionSound && _audioSource) _audioSource.PlayOneShot(explosionSound);
        if (explosionFlame) explosionFlame.Play();
    }
}
