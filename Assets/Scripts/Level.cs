using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] float delay=2f;
    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadCoreScene()
    {
        SceneManager.LoadScene("CoreGame");
        FindObjectOfType<GameSession>().ResetScore();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadUpgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

}
