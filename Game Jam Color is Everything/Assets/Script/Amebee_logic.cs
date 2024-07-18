using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Amebee_logic : MonoBehaviour
{
    [SerializeField] private TextAsset[] InkJSON;
    private bool vaFattoEntrare;
    private static Amebee_logic instance;
     
    void Awake(){
        instance=this;
    
    }
    public static Amebee_logic GetInstance(){
        return instance; 
    }
    public TextAsset GetTextAsset(){
        return InkJSON[0];
    }
}


