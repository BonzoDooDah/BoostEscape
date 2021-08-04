using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [Header("Crossfade Transaition")]
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionDelay = 3f;

    [Header("UI Menus")]
    [SerializeField] private GameObject introMenu = null;

    private void Start() {
        if (SceneManager.GetActiveScene().buildIndex != 0) {
            Cursor.visible = false;
            if (introMenu) { introMenu.SetActive(false); }
        } else {
            Cursor.visible = true;
            if (introMenu) { introMenu.SetActive(true); }
        }
    }

    private IEnumerator LoadLevel(int levelIndex) {
        if (levelIndex >= SceneManager.sceneCountInBuildSettings) { levelIndex = 1; }

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

    public void LoadFirstLevel() {
        Cursor.visible = false;
        LoadNextLevel();
    }
}
