//MY DYSLEXIA SCREWED ME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;

public class DislpayHand : MonoBehaviour
{
    [SerializeField] Hand playerHand;

    //The card that the player is currently on
    private int cardCurrentlyOn = -1;

    private GameObject[] cardArr;

    public void setCardOn(int newCard)
    {
        cardCurrentlyOn = newCard;
    }

    public int getCardOn()
    {
        return cardCurrentlyOn; 
    }

    public void removeCardOn()
    {
        if(!(cardArr.Length <= cardCurrentlyOn || cardCurrentlyOn < 0))
        {
            int size = cardArr.Length - 1;
            Object.DestroyImmediate(cardArr[cardCurrentlyOn], true); // Destroys the played card
            for(int i = cardCurrentlyOn; i < size; i++) // shifts all of the other cards down one
            {
                cardArr[i] = cardArr[i + 1];
                PositionInHand posInHand = cardArr[i].GetComponent<PositionInHand>();
                posInHand.changePositionInHand(i);
                //I Also Need To Add Positions For The Cards Based On The Screen Size Later
            }
            GameObject card = playerHand.getItem(size).getCardDisplay();
            var newCard = Instantiate(card, new Vector3(-6.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
            PositionInHand newPos = newCard.GetComponent<PositionInHand>();
            newPos.changePositionInHand(size);
            cardArr[size] = card;
        }
    }
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
        cardArr = new GameObject[size];
        for(int i = 0; i < size; i++)
        {
            GameObject card = playerHand.getItem(i).getCardDisplay();
            var newCard = Instantiate(card, new Vector3(-6.0f,0.0f,0.0f), Quaternion.identity) as GameObject;
            PositionInHand posInHand = newCard.GetComponent<PositionInHand>();
            posInHand.changePositionInHand(i);
            cardArr[i] = card;
            
        }

    }



    public void displayAll()
    {
        display();
    }

}
