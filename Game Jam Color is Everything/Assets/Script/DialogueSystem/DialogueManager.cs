using Ink.Runtime;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story story;
    private bool dialogueIsPlaying;
    private static DialogueManager instance;
    void Awake(){
        if(instance!=null){
            Debug.LogWarning("Esiste già un dialogue manager in questa scena");
        }
        instance=this;
    }
    public static DialogueManager GetInstance(){
        return instance;
    }
    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }
    public void EnterDialogueMode(TextAsset InkJSON){
        story = new Story(InkJSON.text);
        dialogueIsPlaying=true;
        dialoguePanel.SetActive(true);
        ContinueStory();
        Debug.Log(InkJSON.text);
    }
    public void ExitDialogueMode(){
        dialogueIsPlaying=false;
        dialoguePanel.SetActive(false);
        dialogueText.text="";
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            ContinueStory();
        }
    }
    private void ContinueStory(){
        if(story.canContinue){
            dialogueText.text= story.Continue();
        }
    }
}
