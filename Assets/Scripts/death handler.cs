using UnityEngine;
using UnityEngine.SceneManagement;

public class deathhandler : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TEACHINGTHING");
    }

    public void ActivateDeathScreen()
    {
        deathScreen.SetActive(true);

        Time.timeScale = 0;
    }
}
