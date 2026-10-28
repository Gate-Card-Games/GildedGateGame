/*The purpose of this is to serve as an editable deck that we can use to store cards and draw them from
 * 
 * @author ryan weinstein
 * 
 * Collaborators n\a
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using Random = UnityEngine.Random;
using System.Linq;

public class Deck : MonoBehaviour
{

    private  ICardBase[] deck; // whats currently in the deck

    private int maxDeckSize; // the maximuim size that the deck can be

    private int deckSize; // the current size of the deck (If you want to get the last value subract one from this number)

    private HashSet<int> drawnCards; //the cards that have been currently drawn

    [SerializeField] SwordsmenCard debugCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deck = new ICardBase[80];
        maxDeckSize = 80;
        deckSize = 0;
        drawnCards = new HashSet<int>();
    }
    
    //returns the max deck size
    public int getMaxDeckSize()
    { 
        return maxDeckSize; 
    }

    //THIS FUNCTION IS TO RESET THE DECK COMPLELTY DELETE WHEN GAME IS WORKING
    public void DEBUG_RESET_COMMAND()
    {
        ICardBase[] newDeck = new ICardBase[80];
        for(int i = 0; i < 30; i++)
        {
            newDeck[i] = debugCard;
        }
        changeDeck(newDeck, 30);
    }


    //changes the max deck size to the new desired size
    public void changeMaxDeckSize(int newDeckSize)
    {
        maxDeckSize = newDeckSize;
    }

    //Gets the current Deck Size
    public int getCurrentDeckSize()
    {
        return deckSize;
    }

    //Changes the deck to the new desired deck
    public void changeDeck(ICardBase[] newDeck, int newDeckSize)
    {
        deck = newDeck; 
        maxDeckSize = deck.Length;
        deckSize = newDeckSize;
    }

    //gets and returns the deck
    public ICardBase[] getDeck()
    {
        return deck;
    }


    //Adds a card to the deck
    //Returns true if the card could be added and false if the card could not be added
    public bool addCard(ICardBase card)
    {
        if(deckSize == maxDeckSize)
        {
            return false;
        }
        deck[deckSize] = card;
        deckSize++;
        return true;
    }

    //replaces the card in the slot with a new desired card
    public ICardBase swapCard(ICardBase card, int slot)
    {
        if (slot >= deckSize) 
        {
            throw new ArgumentOutOfRangeException("The given slot to replace is not inside the deck"); // propogates an exception so we can track if there is an error
        }
        ICardBase removedCard = deck[slot]; //getting the card that is being removed
        deck[slot] = card;
        return removedCard;

    }
    //Removes a card from the deck and replaces it with the card in the last spot
    public ICardBase removeCard(int slot)
    {
        if (slot >= deckSize)
        {
            throw new ArgumentOutOfRangeException("The given slot to replace is not inside the deck"); // propogates an exception so we can track if there is an error
        }
        else if(deckSize <= 0)
        {
            throw new ArgumentOutOfRangeException("The deck is currently empty"); // propogates an exception so we can track if there is an error
        }
        ICardBase card = deck[slot]; // replaces the card with the card in the last slot and then removes it
        deck[slot] = deck[deckSize - 1];
        deck[deckSize - 1] = null;
        return card;
    }

    //draws a random card
    public ICardBase draw()
    {
        if(drawnCards.Count() >= deckSize)
        {
            return null;
        }
        int card = Random.Range(0,deckSize-1);
        while(drawnCards.Contains(card))
        {
            card++;
            if(card >= deckSize)
            {
                card = 0;
            }
        }
        drawnCards.Add(card); // adds the card number to the cards that have been drawn
        return deck[card];
    }

    //resets the set drawnCards
    public void shuffle()
    {
        drawnCards.Clear();
    }
}
