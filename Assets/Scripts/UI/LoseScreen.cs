using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
