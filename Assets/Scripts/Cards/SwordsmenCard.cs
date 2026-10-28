using UnityEngine;
using UnityEngine.UI;

public class SwordsmenCard : MonoBehaviour, ICardBase, IDefensiveCard
{




    private int cost = 0;

    private string cardName = "Swordsmen";

    [SerializeField] GameObject cardDisplay;

    [SerializeField] GameObject cardTower;
    private string rarity = "Common";

    public bool isDefensiveCard()
    {
        return true;
    }

    //Gets the cost of the card
    public int getCost()
    {
        return cost;
    }

    //Gets the name of the card
    public string getName()
    {
        return cardName;
    }

    // gets the prefab of the card object
    public GameObject getCardDisplay()
    {
        return cardDisplay;
    }

    //Returns the rairty of the card (You can rename this to get level and change the description)
    public string getRarity()
    {
        return rarity;
    }

    //Gets the value of the card (This would be the base cost of the card)
    public int getValue() { return cost; } //IMPLEMENT LATER

    //The card uses its ability or spell
    public void activate() { return; }//IMPLEMENT LATER

    //Places the tower
    public GameObject place() { return cardTower; }
}
