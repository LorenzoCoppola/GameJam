using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        Debug.Log("No penetrazione");
        if(collider2D.gameObject.tag == "NPC"){
            DialogueManager.GetInstance().EnterDialogueMode(Amebee_logic.GetInstance().GetTextAsset());
            Debug.Log("Sesso");
        }
    }
}
