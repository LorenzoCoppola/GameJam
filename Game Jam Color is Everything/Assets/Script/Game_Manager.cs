using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public void Check_Rosso()
    {
        Debug.Log("Ruthlesness is mercy");
        DialogueManager.GetInstance().ExitDialogueMode();
    }

    public void Check_Verde()
    {
        Debug.Log("Greet the world with open arms");
        DialogueManager.GetInstance().ExitDialogueMode();
    }
}
