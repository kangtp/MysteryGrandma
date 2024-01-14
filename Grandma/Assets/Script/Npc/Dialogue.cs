using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public TMP_Text dialogueText;
    public List<string> dialogues;
    public float write_Speed;
    private int index;
    private int charindex;
    private bool started;
    private bool waitForNext;
    
    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    
    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
    public void Strat_Dialogue()
    {
        if(started)
            return;
        
        started=true;
        ToggleWindow(true);
        ToggleIndicator(true);
        GetDialogue(0);
    }
    private void GetDialogue(int i)
    {
        index=i;
        charindex = 0;
        dialogueText.text=string.Empty;
        StartCoroutine(Writing());
   
    }
    public void EndDialogue()
    {
        started=false;
        waitForNext =false;
        StopAllCoroutines();
        ToggleWindow(false);
        ToggleIndicator(false);
    }
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(write_Speed);
        
        string currnetDialogue =dialogues[index];
        dialogueText.text+=currnetDialogue[charindex];
        charindex++;
        if(charindex<currnetDialogue.Length)
        {
            yield return new WaitForSeconds(write_Speed);
            StartCoroutine(Writing());
        }
       
        else
        {
            waitForNext=true;
        }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(!started)
            return;
        
        if(waitForNext && Input.GetKeyDown(KeyCode.Space))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }
            
        }
    }
}
