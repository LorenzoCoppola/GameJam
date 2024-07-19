using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Amebee_logic : MonoBehaviour
{
    [SerializeField] private TextAsset[] InkJSON;
    private int[] numeri;
    private bool vaFattoEntrare;
    private static Amebee_logic instance;
    
    void Awake(){
        if(instance==null){
            instance=this;
        }
    }
    public static Amebee_logic GetInstance(){
        return instance; 
    }
    public int Getnumb(){
        return numeri[Random.Range(0,numeri.Length)];
    }
    public TextAsset GetTextAsset(){
        return InkJSON[Random.Range(0,InkJSON.Length)];
    }

}


