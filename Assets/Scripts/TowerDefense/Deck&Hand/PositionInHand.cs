using UnityEngine;

public class PositionInHand : MonoBehaviour
{
    private int posInHand = -1;
    public int getPositionInHand()
    {
        return posInHand;
    }

    public void changePositionInHand(int newPos)
    {
        posInHand = newPos;
    }
}
