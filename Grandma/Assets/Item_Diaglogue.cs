using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
// 퀘스트 완료시 다른 대사가 나오도록 설정해주는 스크립트
public class Item_Diaglogue : MonoBehaviour
{
    public Item_Manager item_manager;
    public string[] dialogueLines_Quest;
    public Dialogue npc_dialogue; 

    public int npc_id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(item_manager.quests[npc_id].Get_Clear())
       {
            if(npc_dialogue!=null)
            {
                npc_dialogue.dialogueLines = dialogueLines_Quest;
            }
       }
    }
}
