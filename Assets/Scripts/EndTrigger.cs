using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public UIManager gameManager;
   void OnTriggerEnter ()
    {
        gameManager.EndGame();
    }
}
