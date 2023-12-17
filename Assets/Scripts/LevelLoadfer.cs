using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadfer : MonoBehaviour
{
    public Animator trans;

    public void BackToMenu() => StartCoroutine(LoadLevelNext(0));
    public void GoToGame() => StartCoroutine(LoadLevelNext(1));
    public void ExitToGame() => Application.Quit();

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadLevelNext(index));
    }

    IEnumerator LoadLevelNext(int levelIndex)
    {
        trans.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
