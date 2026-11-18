using UnityEngine;

public class DeckEditorManager : MonoBehaviour
{
    [SerializeField] Deck deck;
    public void AddCardToDeck(GameObject newCard)
    {
        ICardBase card = newCard.GetComponent<ICardBase>();
        if (card != null)
        {
            deck.addCard(card);
        }
        
    }
    private static DeckEditorManager _instance;
    public static DeckEditorManager Instance
    {
        get
        {
            if (!_instance)
                _instance = FindAnyObjectByType<DeckEditorManager>();
            if (_instance == null)
                _instance = new GameObject("LevelManager").AddComponent<DeckEditorManager>();
            return _instance;
        }
    }
}
