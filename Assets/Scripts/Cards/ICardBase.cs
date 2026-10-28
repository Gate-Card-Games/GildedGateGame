using UnityEngine;
using UnityEngine.UI;

public interface ICardBase
{
    //RETURNS IF ITS A DEFENSIVE CARD
    public bool isDefensiveCard();

    //Gets the cost of the card
    public int getCost();

    //Gets the name of the card
    public string getName();

    public GameObject getCardDisplay(); // gets the prefab of the card object


    //Returns the rairty of the card (You can rename this to get level and change the description)
    public string getRarity();

    //Gets the value of the card (This would be the base cost of the card)
    public int getValue();

    //The card uses its ability or spell
    public void activate();
}
