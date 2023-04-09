
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartScene()
    {       
        SceneManager.LoadScene(0);
    }

    public void NextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
