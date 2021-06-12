using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Header("Frame Rate")]
    [SerializeField] private int targetRate = 60;

    [Header("Tracking")]
    [SerializeField] private Transform trackedObject = null;

    private Vector3 offsetPosition;

    private void Start() {
        QualitySettings.vSyncCount = 0;
        offsetPosition = transform.position; // set initial offset position
    }

    private void Update() {
        // check frame rate
        if (targetRate != Application.targetFrameRate) Application.targetFrameRate = targetRate;

        // update object tracking
        if (trackedObject) transform.position = trackedObject.position + offsetPosition;
    }

    public void ShakeCamera(float magnitude, float duration) {
        StartCoroutine(Shake(magnitude, duration));
    }

    private IEnumerator Shake(float magnitude, float duration) {
        float elapsed = 0f;

        while (elapsed < duration) {
            Vector3 shake = new Vector3(Random.Range(-1f, 1f) * magnitude, Random.Range(-1f, 1f) * magnitude, Random.Range(-1f, 1f) * magnitude) * ((duration - elapsed) / duration);
            transform.position = (trackedObject != null ? trackedObject.position + offsetPosition : offsetPosition) + shake;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = trackedObject != null ? trackedObject.position + offsetPosition : offsetPosition;
    }
}
