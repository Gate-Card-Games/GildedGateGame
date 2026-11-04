using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private Deck _deck;
    private void Awake()
    {
        _deck = FindAnyObjectByType<Deck>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Debug_DeckTest()
    {
        _deck.DEBUG_RESET_COMMAND();
    }
    private static DeckManager _instance;
    public static DeckManager Instance
    {
        get
        {
            if (!_instance)
                _instance = FindAnyObjectByType<DeckManager>();
            if (_instance == null)
                _instance = new GameObject("DeckManager").AddComponent<DeckManager>();
            return _instance;
        }
    }
}
