using UnityEngine;

public class PriorityQueueTester : MonoBehaviour
{
    private PriorityQueue<int> test = new PriorityQueue<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 1; i <= 100; i++)
        {
            test.add(i);
        }

        while(test.peek() != 0)
        {
            Debug.Log("Peek: " + test.peek() + ", Poll: " + test.poll() + "\n");
        }
    }
}
