using UnityEngine;

public class SceneMenuTransition : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if(LevelManager.Instance.deck.debugCard != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
     
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
