//MY DYSLEXIA SCREWED ME

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

    //The card that the player is currently on
    private int cardCurrentlyOn = -1;

    private List<GameObject> cardArr;

    public void setCardOn(int newCard)
    {
        cardCurrentlyOn = newCard;
    }

    public int getCardOn()
    {
        return cardCurrentlyOn; 
    }

    public void removeCardOn() //WTF AM I DOING WRONG
    {
        if(!(cardArr.Count() <= cardCurrentlyOn || cardCurrentlyOn < 0))
        {
            int size = cardArr.Count() - 1;
            GameObject obj = cardArr[cardCurrentlyOn];
            Destroy(obj);
            //DestroyImmediate(obj, true); // Destroys the played card
            for(int i = cardCurrentlyOn; i < size; i++) // shifts all of the other cards down one
            {
                cardArr[i] = cardArr[i + 1];
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
                var newCard = Instantiate(card, new Vector3(-6.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
                PositionInHand newPos = newCard.GetComponent<PositionInHand>();
                newPos.changePositionInHand(size);
                cardArr[size] = card;
            }
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
        cardArr = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject card = playerHand.getItem(i).getCardDisplay();
            var newCard = Instantiate(card, new Vector3(-6.0f,0.0f,0.0f), Quaternion.identity) as GameObject;
            PositionInHand posInHand = newCard.GetComponent<PositionInHand>();
            posInHand.changePositionInHand(i);
            cardArr.Add(card);
            
        }

    }



    public void displayAll()
    {
        display();
    }

}
