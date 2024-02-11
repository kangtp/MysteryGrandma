using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Quest_info 
{
    //퀘스트 이름, 숫자 여부 , 현재 퀘스트 클리어 여부
    
    public string quest_name;
    public int clear_count;
    public bool clear_flag;

    public string Get_QuestName()
    {
        return quest_name;
    }
    public int Get_ClearCount()
    {
        return clear_count;
    }
    public bool Get_Clear()
    {
        return clear_flag;
    }
    public bool Set_QuestClear(int a)
    {
        if(clear_count == a)
        {
            clear_flag=true;
        }
        return clear_flag;
    }

}
public class Item_Manager : MonoBehaviour
{
    // 퀘스트 별로 int형(아이템 여러개 모으기) 혹은 몬스터 일정수치 처치할 시 퀘완인지에 따라 나뉨
    // 배열에 문자열,정수,불타입 해놓고 그 퀘스트 이름에 따라 처리할 예정 일단은 아이템 하나만 테스트 해볼 예정
   
    public List<Quest_info> quests;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public bool Quest_inspect(int id,int a)
    {
        if(quests[id].Set_QuestClear(a))
        {
            quests[id].Set_QuestClear(a);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    
}
