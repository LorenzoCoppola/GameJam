using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool playerInRange;

    

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.tag == "NPC"){
            playerInRange=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.gameObject.tag == "NPC"){
            playerInRange=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
