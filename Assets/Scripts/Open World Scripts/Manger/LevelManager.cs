using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    public GameObject sceeneUI;
    public GameObject shopUI;
    public Deck deck;
    [SerializeField] ThirdPersonCamera camera;
    [SerializeField] Movement _movement;
    [SerializeField] bool _pauseMovement;
   
    public void SetMessage(string text)
    {
        textBox.SetText(text);
        
    }
    public void FreezePlayer()
    {
        _movement.stopMovement = true;
        camera.UnFreezeMouse();
    }
    public void UnFreezePlayer()
    {
        _movement.stopMovement = false;
        camera.FreezeMouse();
        textBox.ClearMesh();
        sceeneUI.SetActive(false);
        shopUI.SetActive(false);
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
