using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyNPC : MonoBehaviour
{
   
    public string speech;
    public bool test;

    public UnityEvent m_NPC_Event;
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
        m_NPC_Event.Invoke();
        test = false;
    }
}
