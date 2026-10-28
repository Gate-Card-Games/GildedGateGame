using UnityEngine;
using UnityEngine.UI;

public interface ICardBase
{


    //Gets the cost of the card
    public int getCost();

    //Gets the name of the card
    public string getName();

    public Button getCardDisplay(); // gets the prefab of the card object

    //Returns the rairty of the card (You can rename this to get level and change the description)
    public string getRarity();

    //Gets the value of the card (This would be the base cost of the card)
    public int getValue();

    //The card uses its ability or spell
    public void activate();
}
