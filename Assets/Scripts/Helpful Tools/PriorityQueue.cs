/*I got bored so I wanted to make a new array based Priority Queue so I have control over it
 * 
 * The purpose of this function is to order any number of 
 * 
 * @author Ryan Weinstein
 * 
 * collaborators N\A
 * 
 * 
 */

using System;
using System.Linq.Expressions;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable<T>
{
    //Class variables
    private T[] elementNodes = new T[0];

    private int size = 0;

    /*Summary:
     *      adds an element to the array and then puts it in its place based on the priority
     * 
     * Parameter:
     *      newElement:
     *          The element that is going to be added to the array
     */

    public void add(T newElement)
    {
        size++;
        if (size >= elementNodes.Length)
        {
            resize();
        }
        int currentSpot = size - 1;
        elementNodes[currentSpot] = newElement;
        int parentSpot = (currentSpot - 1) / 2;
        //Runs if it should swap or if the parent is the default value
        while (parentSpot >= 0 && (elementNodes[currentSpot].CompareTo(elementNodes[parentSpot]) < 0 || elementNodes[parentSpot].CompareTo(default(T)) == 0)) // Holy shit im stupid (I tried to declare the parameters instead of putting the variable in) 
        {
            swap(currentSpot, parentSpot);
            currentSpot = parentSpot;
            parentSpot = (currentSpot - 1) / 2;
        }
    }

    /*Summary:
     *  Returns the element with the highest priority without destroying anything
     * 
     * Return:
     *      the element with the highest priority and if the size is 0 then it returns null
     */
    public T peek()
    {
        if (size <= 0)
            return default(T); //This should just return null

        return elementNodes[0];
    }

    /*Summary:
     *      This returns the first element in the array and then removes it and resorts the array
     *      (I Need to ask the teacher about any inefficencies)
     * 
     * 
     * Returns:
     *      The first element in the array which has the highest priority
     */
    public T poll()
    {
        if(size <= 0)
        {
            throw new IndexOutOfRangeException("The PriorityQueue Is Empty");
        }
        T returnElement = elementNodes[0];
        elementNodes[0] = elementNodes[size - 1];
        elementNodes[size - 1] = default(T);
        int currentElement = 0;
        // Loops until the element is in the proper place
        do
        {
            int rightChild = (currentElement * 2) + 2; // Gets and stores the right child
            int leftChild = (currentElement * 2) + 1; // Gets and stores the left child
            if(leftChild >= size || elementNodes[leftChild].CompareTo(default(T)) == 0)
            {
                break; // exits because both children are out of the array
            }
            if (!(elementNodes[leftChild].CompareTo(default(T)) == 0) && !(elementNodes[rightChild].CompareTo(default(T)) == 0))
            {
                int checkLeft = elementNodes[leftChild].CompareTo(elementNodes[currentElement]);
                int checkRight = elementNodes[rightChild].CompareTo(elementNodes[currentElement]);
                if(checkLeft < 0 && checkRight < 0) // if both elements can be used to shift
                {
                    int check = elementNodes[leftChild].CompareTo(elementNodes[rightChild]);
                    if(check > 0)
                    {
                        swap(currentElement, rightChild);
                        currentElement = rightChild;
                    }
                    else
                    {
                        swap(currentElement, leftChild);
                        currentElement = leftChild;
                    }
                }
                else if(checkLeft < 0) // changes the current elemet to the left child
                {
                    swap(currentElement, leftChild);
                    currentElement = leftChild;
                }
                else if (checkRight < 0) // changes the current element to the right child
                {
                    swap(currentElement, rightChild);
                    currentElement = rightChild;
                }
                else
                {
                    break; // Exits the loop if the element is properly placed
                }
            }
            else if (!(elementNodes[leftChild].CompareTo(default(T)) == 0))
            {
                int checkLeft = elementNodes[leftChild].CompareTo(elementNodes[currentElement]);
                if (checkLeft < 0) // changes the current elemet to the left child
                {
                    swap(currentElement, leftChild);
                    currentElement = leftChild;
                }
                else
                {
                    break; // Exits the loop if the element is properly placed
                }
            }
            else if (!(elementNodes[rightChild].CompareTo(default(T)) == 0))
            {
               int checkRight = elementNodes[rightChild].CompareTo(elementNodes[currentElement]);
               if (checkRight < 0) // changes the current elemet to the right child
               {
                    swap(currentElement, leftChild);
                    currentElement = leftChild;
               }
               else
               {
                    break; // Exits the loop if the element is properly placed
               }
            }

        } while (true); //Relized I forgot to change this to always run
        size--;
        return returnElement;
    }


    /*Summary:
     *      swaps the spots of the two elements
     * 
     * 
     * Paramaters:
     *      element1:
     *          The spot of the first element you want to swap
     *      
     *      element2:
     *          The spot of the seconf element you want to swap
     */

    private void swap(int element1, int element2)
    {
        T temp = elementNodes[element1];
        elementNodes[element1] = elementNodes[element2];
        elementNodes[element2] = temp;
    }

    /*Summary:
     *  Resizes the array to save space and keeps the size a power of two
     * 
     */
    private void resize()
    {
        if (size >= elementNodes.Length)
        {
            T[] tempArr = new T[size * 2];
            for (int i = 0; i < size - 1; i++)
            {
                tempArr[i] = elementNodes[i];
            }
            elementNodes = tempArr;
        }
        //The First part of the if i have no idea how it works but it gets if its a power of two, The second part has the divide by two so it only does it if its really small
        else if((size > 0 && (size & (size - 1)) == 0) && elementNodes.Length / 2 >= size)
        {
            T[] tempArr = new T[size];
            for (int i = 0; i < size; i++)
            {
                tempArr[i] = elementNodes[i];
            }
            elementNodes = tempArr;
        }
    }
}
