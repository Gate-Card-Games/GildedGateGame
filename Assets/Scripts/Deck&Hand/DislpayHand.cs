//MY DYSLEXIA SCREWED ME

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if(cardArr.Length <= cardCurrentlyOn || cardCurrentlyOn < 0)
        {
            Destroy(cardArr[cardCurrentlyOn]);
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
        Debug.Log(size);
    }



    public void displayAll()
    {
        display();
    }

}
