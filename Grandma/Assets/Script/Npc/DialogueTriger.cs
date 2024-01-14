using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerDetected;
    public Dialogue dialogueScript;

   
    private void  OnTriggerEnter2D(Collider2D other)
    {
          if(other.tag =="Player")
          {
            Debug.Log("player!!");
            playerDetected=true;
            dialogueScript.ToggleIndicator(playerDetected);
          }
    }
    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        
            dialogueScript.EndDialogue();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueScript.Strat_Dialogue();
        }
    }
}
