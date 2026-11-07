/*The Purpose of this program is to be only useful to me when testing my PQ
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */

using UnityEngine;
using System;

public class PriorityQueueTester : MonoBehaviour
{
    private PriorityQueue<int> test = new PriorityQueue<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //This is just a testing algorithm that i made to test my priority queue and see if it was working
    void Start()
    {
        System.Random rand = new System.Random();
        for(int i = 1; i <= 1024; i++)
        {
            int num = rand.Next(1, 100) + 1;
            Debug.Log(num);
            test.add(num);
        }

        while(test.peek() != 0)
        {
            Debug.Log("Peek: " + test.peek() + ", Poll: " + test.poll() + "\n");
        }
    }
}
