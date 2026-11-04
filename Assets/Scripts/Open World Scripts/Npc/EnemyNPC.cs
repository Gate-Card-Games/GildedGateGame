using TMPro;
using UnityEngine;

public class EnemyNPC : MonoBehaviour
{
   
    public string speech;
    public bool test;


    private void Update()
    {
        if (test)
        {
            OnInteracted();
            
        }
    }
    public void OnInteracted()
    {
        LevelManager.Instance.SetMessage(speech);
        LevelManager.Instance.FreezePlayer();
        test = false;
    }
}
