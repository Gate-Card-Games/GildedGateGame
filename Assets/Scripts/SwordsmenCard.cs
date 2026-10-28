using UnityEngine;
using UnityEngine.UI;

public class SwordsmenCard : MonoBehaviour, ICardBase, IDefensiveCard
{

    private int cost = 0;

    private string name = "Swordsmen";

    [SerializeField] Button cardDisplay;

    private string rarity = "Common";

    //Gets the cost of the card
    public int getCost()
    {
        return cost;
    }

    //Gets the name of the card
    public string getName()
    {
        return name;
    }

    // gets the prefab of the card object
    public Button getCardDisplay()
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
    public void activate(int x, int y) { return; }//IMPLEMENT LATER
}
