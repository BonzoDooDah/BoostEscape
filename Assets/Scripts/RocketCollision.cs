using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {
    [Header("Explosion")]
    [SerializeField] private float explosionForce = 800f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float shakeMagnitude = 2f;
    [SerializeField] private float shakeDuration = 0.45f;

    private Rigidbody _rigidbody = null;
    private RocketMovement _rocketMovement = null;
    private RocketFX _rocketFX = null;
    private LevelManager _levelManager = null;
    private bool _isTransitioning = false;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _rocketMovement = GetComponent<RocketMovement>();
        if (_rocketMovement) _rocketMovement.enabled = false;
        _rocketFX = GetComponentInChildren<RocketFX>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (_isTransitioning) return;

        switch (collision.gameObject.tag) {
            case "Safe": // hit something safe, do nothing
                break;
            case "Respawn": // hit start action pad
                ProcessPlayerStart();
                break;
            case "Finish": // hit end action pad
                ProcessPlayerSuccess();
                break;
            default: // hit something harmful
                ProcessPlayerDeath();
                break;
        }
    }

    private void ProcessPlayerStart() {
        if (_rocketMovement) _rocketMovement.enabled = true;
    }

    private void ProcessPlayerSuccess() {
        _isTransitioning = true;
        if (_rocketMovement) _rocketMovement.enabled = false;

        if (_levelManager) _levelManager.LoadNextLevel();
    }

    private void ProcessPlayerDeath() {
        _isTransitioning = true;
        if (_rocketMovement) _rocketMovement.enabled = false;

        FindObjectOfType<CameraController>().ShakeCamera(shakeMagnitude, shakeDuration);

        Vector3 velocity = _rigidbody.velocity;

        Destroy(_rigidbody); // remove rigidbody so camera stays still

        GameObject objMeshes = GameObject.Find("Meshes");
        Destroy(objMeshes); // remove no-destructible meshes

        GameObject goDestructibles = GameObject.Find("Destructibles");
        foreach (Transform item in goDestructibles.transform) {
            GameObject obj = item.gameObject;
            obj.SetActive(true);
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            rb.velocity = velocity;
            rb.AddExplosionForce(Random.Range(0.5f, 1.0f) * explosionForce, transform.position, explosionRadius);
        }

        if (_rocketFX) _rocketFX.PlayExplosion();

        if (_levelManager) _levelManager.ReloadLevel();
    }
}
