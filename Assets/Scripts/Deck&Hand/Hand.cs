/*This program is made to keep track of the hand and make the game
 * 
 * @author ryan weinstein
 * 
 * collaborators n\a
 */
using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Deck deck; // the deck that will be used for calculations
    private int handSize; // the maximuim size of the hand

    private int currentHandSize;
    private ICardBase[] hand;

    //Runs at the start of the program
    private void Start()
    {
        handSize = 5;
        currentHandSize = handSize;
        hand = new ICardBase[handSize];
    }

    public void setHand()
    {
        for(int i = 0; i < handSize; i++)
        {
            hand[i] = deck.draw();
        }
        
    }

    //returns the size of the hand
    public int getHandSize()
    {
        return handSize;
    }

    public ICardBase getItem(int slot)
    {
        return hand[slot];
    }

    //When you play a card from you hand removes and replaces it
    public GameObject playCard(int slot)
    {
        if (slot >= currentHandSize)
        {
            throw new ArgumentOutOfRangeException("That slot is greater than the number of cards in the hand"); // propogates an exception so we can track if there is an error
        }
        else if (slot < 0)
        {
            throw new ArgumentOutOfRangeException("That slot is lower than the minimuim slot that could be given"); // propogates an exception so we can track if there is an error
        }

        ICardBase card = hand[slot];
        
        
        for (int i = slot; i < handSize - 2; i++)
        {
            hand[i] = hand[i + 1];
        }
        hand[handSize-1] = deck.draw();
        if (card.isDefensiveCard())
        {
            return ((IDefensiveCard)card).place();
        }
        else
        {
            card.activate();
        }
        return null;

    }

    //Remove and replace a card with a new one from the deck
    public void discardCard(int slot)
    {

        if (slot >= currentHandSize)
        {
            throw new ArgumentOutOfRangeException("That slot is greater than the number of cards in the hand"); // propogates an exception so we can track if there is an error
        }

        ICardBase card = deck.draw();
        for (int i = slot; i < handSize - 2; i++)
        {
            hand[i] = hand[i + 1];
        }
        hand[handSize] = card;

    }

}
