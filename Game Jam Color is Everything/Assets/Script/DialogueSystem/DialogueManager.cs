using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using TMPro.Examples;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story story;
    private bool dialogueIsPlaying;
    private static DialogueManager instance;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject pressTitle;
    private TextMeshProUGUI[] choicesText;


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
        pressTitle.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index=0;
        foreach(GameObject choice in choices){
            choicesText[index]= choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        for(int i=0;i<choices.Length;i++){
            choices[i].SetActive(false);
        }
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
            if(story.currentChoices.Count!=0){
                DisplayChoices();
            }
        }
    }

    private void DisplayChoices(){
        List<Choice> currentChoices = story.currentChoices;
        if(currentChoices.Count> choices.Length){
            Debug.LogError("Hai superato il massimo di scelte ");
        }
        pressTitle.SetActive(true);
        int index = 0;
        foreach(Choice choice in currentChoices){
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for(int i = index; i < choices.Length; i++){
            choices[i].gameObject.SetActive(true);
        }

    }
}
