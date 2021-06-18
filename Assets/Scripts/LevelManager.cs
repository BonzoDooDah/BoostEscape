using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionDelay = 3f;

    private void Start() {
        Cursor.visible = false;
    }

    private IEnumerator LoadLevel(int levelIndex) {
        if (levelIndex >= SceneManager.sceneCountInBuildSettings) { levelIndex = 0; }

        yield return new WaitForSeconds(transitionDelay - 1f);

        transitionAnimator.SetTrigger("StartFadeOut");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }

    public void ReloadLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
