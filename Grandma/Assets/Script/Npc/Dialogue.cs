using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
나에겐 패널이 존재 이름 ,대화 , 옵션 패널들이 존재
지금 내가 해야하는 것은 npc에 맞게 이름 , 대화 , 옵션 패널들을 수정하는 것 
내가 모르는 것은 대화가 여러개 있고 스페이스바를 누르면 다음 대화로 넘어가게 하기 
*/

public class Dialogue : MonoBehaviour
{
    public TMP_Text npcName; 
    public TMP_Text npc_dialogues;
    public string[] dialogueLines; 
    public Canvas npc_canvas;
    public int index=0;
    bool started;
    


    

    private string currnet_String;
    private void Start() {
        if(started)
            return;
        npc_dialogues.text=dialogueLines[0];
    }

    
    public void GetString(int index)
    {
        npc_dialogues.text= dialogueLines[index];
    }

}