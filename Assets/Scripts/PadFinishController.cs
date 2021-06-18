using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadFinishController : MonoBehaviour {
    [Header("Success Effects")]
    [SerializeField] private ParticleSystem successCelebration;
    [SerializeField] private AudioClip successSound;

    private AudioSource _audioSource = null;
    private bool alreadyHit = false;

    private void Start() {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" && !alreadyHit) {
            if (successSound && _audioSource) _audioSource.PlayOneShot(successSound);
            if (successCelebration) successCelebration.Play();
            alreadyHit = true;
        }
    }
}
