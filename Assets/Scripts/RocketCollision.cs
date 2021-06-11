using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {
    private RocketMovement _rocketMovement;
    private bool _isTransitioning = false;

    private void Start() {
        _rocketMovement = GetComponent<RocketMovement>();
        if (_rocketMovement) _rocketMovement.enabled = false;
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

        Debug.Log("Player SUCCESS!");
    }

    private void ProcessPlayerDeath() {
        _isTransitioning = true;
        if (_rocketMovement) _rocketMovement.enabled = false;

        Debug.Log("Player death");
    }
}
