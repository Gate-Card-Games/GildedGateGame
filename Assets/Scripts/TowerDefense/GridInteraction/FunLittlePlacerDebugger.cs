using UnityEngine;

public class FunLittlePlacerDebugger : MonoBehaviour
{
    bool block = false;
    [SerializeField] GridPlacer grid;

    [SerializeField] GameObject obj;
    // Called With THE BUTTON CLICK
    public void swap()
    {
        block = !block;
        if (block)
        {
            grid.changePlacer(obj);
        }
        else
        {
            grid.changePlacer(null);
        }
    }
    
}
