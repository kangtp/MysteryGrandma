using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_detect : MonoBehaviour
{
    
    private bool item_show = false;
    public int item_id; // item마다 고유번호 생성
    private int item_count=0;//quest 조건 
    public int item_code;

    public Item_Manager item_manager;

    public GameObject text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(item_show && Input.GetKeyDown(KeyCode.F))
        {
           item_count++;
           item_manager.Quest_inspect(item_id,item_count);
           Debug.Log("퀘스트 0번 완료!");
           Debug.Log(item_manager.quests[item_id].Get_Clear());
           this.gameObject.SetActive(false);
           
           

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            item_show = true;
            

            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            item_show = false;
        }
    }
}
