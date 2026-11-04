using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] GameObject button;
    [SerializeField] ThirdPersonCamera camera;
    [SerializeField] Movement _movement;
    [SerializeField] bool _pauseMovement;
   
    public void SetMessage(string text)
    {
        textBox.SetText(text);
        button.SetActive(true);
    }
    public void FreezePlayer()
    {
        _movement.stopMovement = true;
        camera.UnFreezeMouse();
    }
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (!_instance)
                _instance = FindAnyObjectByType<LevelManager>();
            if (_instance == null)
                _instance = new GameObject("LevelManager").AddComponent<LevelManager>();
            return _instance;
        }
    }
}
