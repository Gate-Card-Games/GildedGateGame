/*The Purpose of this program is to be a basic template for all cards used in this project
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */
using UnityEngine;
using UnityEngine.UI;

public interface ICardBase
{
    /*Summary:
     *      Returns if the card has a tower side
     * Return:
     *      if the tower is a defensive card with a tower
     * 
     */
    public bool isDefensiveCard();

    /*Summary:
     *      Returns whatever the cost of the card is
     * 
     * Return:
     *      the cost of the card
     * 
     */
    public int getCost();

    /*Summary:
     *      returns the name of the card
     *      
     *  Return:
     *      the name of the card
     * 
     * 
     */
    public string getName();

    /*Summary:
     *      get the prefab of the card object
     * 
     *Return:
     *      the prefab of the card
     * 
     */
    public GameObject getCardDisplay();


    /*Summary:
     *      this function returns the rarity of the card
     * 
     * Returns:
     *      the rairty of the card (You can rename this to get level and change the description)
     * 
     * 
     * 
     */
    public string getRarity();

    /*Summary:
     *      gets the value of the card for the shop to use
     *      
     *  Return:
     *      the value of the card in terms of 3-D world money
     * 
     * 
     */
    public int getValue();

    /*Summary:
     *      tells the card to do what the text of the card says it should do
     *          and activates it
     */
    public void activate();



}
