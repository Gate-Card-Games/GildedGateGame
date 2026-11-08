/*The purpose of this program is to display what card are in the hand
 * (This was meant to be called DisplayHand)
 * 
 * @author ryan weinstein
 * 
 * 
 * collaborators N/A
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;

public class DislpayHand : MonoBehaviour
{
    [SerializeField] Hand playerHand;

    //instant variables
    private int cardCurrentlyOn = -1;

    private List<GameObject> cardArr;

    /*Summary:
     *      changes the set cardCurrentlyOn into the index provided
     * 
     * Parameters:
     *      newCard:
     *          The cards index that you want to set it to
     */
    public void setCardOn(int newCard)
    {
        cardCurrentlyOn = newCard;
    }

    /*Summary:
     *      the index of the card that was last pressed
     * 
     * Return:
     *      the card that was pressed last
     */
    public int getCardOn()
    {
        return cardCurrentlyOn; 
    }

    /*Summary: 
     *  Removes the card that the player pressed last and replaces it with a new one
     * 
     */
    public void removeCardOn()
    {
        if(!(cardArr.Count() <= cardCurrentlyOn || cardCurrentlyOn < 0))
        {
            int size = cardArr.Count() - 1;
            GameObject obj = cardArr[cardCurrentlyOn];
            Destroy(obj);
            for(int i = cardCurrentlyOn; i < size; i++) // shifts all of the other cards down one
            {
                PositionInHand posInHand = cardArr[i].GetComponent<PositionInHand>();
                posInHand.changePositionInHand(i);
                //I Also Need To Add Positions For The Cards Based On The Screen Size Later
            }
            GameObject card = playerHand.getItem(size).getCardDisplay();
            if (playerHand.getItem(size) == null)
            {
                cardArr.RemoveAt(size);
            }
            else
            {
                var newCard = makeCard(card);
                PositionInHand newPos = newCard.GetComponent<PositionInHand>();
                newPos.changePositionInHand(size);
                cardArr[size] = newCard;
            }
        }
    }

    /*Summary:
     *  displays the entire hand by making them new objects
     * 
     */
    private void display()
    {
        //Removing all nulls from the size so it doesn't display them
        int size = playerHand.getHandSize();
        for(int i = size-1; i >= 0; i--)
        {
            if(playerHand.getItem(i) == null)
            {
                size--;
            }
        }
        cardArr = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject card = playerHand.getItem(i).getCardDisplay();
            var newCard = makeCard(card);
            PositionInHand posInHand = newCard.GetComponent<PositionInHand>();
            posInHand.changePositionInHand(i);
            cardArr.Add(newCard);
            
        }

    }

    /*Summary:
     *      makes a card object from the prefab provided
     *      
     *Parameter:
     *      card:
     *          the prefab of the card provided
     *
     *Return:
     *      an instanted object of the prefab provided
     * 
     */
    private GameObject makeCard(GameObject card)
    {
        return Instantiate(card, new Vector3(-6.0f, 0.0f, 0.0f), card.transform.rotation) as GameObject;
    }



    /*Summary:
     *      just calls the display function (I can delete this later)
     */
    public void displayAll()
    {
        display();
    }

}
