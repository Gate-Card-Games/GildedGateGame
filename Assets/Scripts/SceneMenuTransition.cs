using UnityEngine;

public class SceneMenuTransition : MonoBehaviour
{
    [SerializeField] bool needsDeck;
    public void ChangeScene(string sceneName)
    {
        if (LevelManager.Instance.deck.debugCard != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        if (!needsDeck)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
     
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
