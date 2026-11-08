/*This program is made to keep track of the hand and make the game
 * 
 * @author ryan weinstein
 * 
 * collaborators Matthew Zoll
 */
using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] Deck deck; // the deck that will be used for calculations
    private int handSize; // the maximuim size of the hand

    private int currentHandSize; // the current hand size
    private ICardBase[] hand; // the hand that holds all the cards

    private void Awake() //Matt needs to add his docs to this
    {
        deck = FindAnyObjectByType<Deck>();

    }
    //Runs at the start of the program
    private void Start()
    {
        //sets all the variables
        handSize = 5;
        currentHandSize = handSize;
        hand = new ICardBase[handSize];
    }

    /*Summary:
     *      This changes the hand size to a new empty array
     *      
     *Parameters:
     *      newSize:
     *          The size that you desire the hand to be at
     */
    public void changeHandSize(int newSize)
    {
        handSize = newSize;
        hand = new ICardBase[handSize];
        deck.shuffle();
        setHand();
    }

    /*Summary:
     *      sets the hand by drawing cards from the deck until its full
     * 
     */
    public void setHand()
    {
        for(int i = 0; i < handSize; i++)
        {
            hand[i] = deck.draw();
        }
        
    }

    /*Summary:
     *      returns what the maximuim hand size is
     * 
     * Return:
     *      what the maximuim hand size is
     */
    public int getHandSize()
    {
        return handSize;
    }

    /*Summary:
     *      returns the card at the desired slot
     * 
     * Parameters:
     *      slot:
     *          the index of the item you want to get
     *          
     *Return:
     *      The card at the desired slot
     */
    public ICardBase getItem(int slot)
    {
        return hand[slot];
    }

    /*Summary:
     *      activates the card at the desired slot or returns what object it is if its a tower
     *
     *Parameters:
     *      slot:
     *          The index of the item that you want to play
     *
     *Return:
     *      if its a defensive card a tower if not then null
     * 
     */
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

    /*Summary:
     *      removes a card than replaces it with a new one from the deck
     *      
     *Parameters:
     *      slot:
     *          the index of the item that you want to remove
     * 
     */
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
