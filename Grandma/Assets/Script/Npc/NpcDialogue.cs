using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer sppechRenderer;
    public Canvas dialogue_canvas;
    bool playerdetected=false;
    
    int index=0;
   
    // Start is called before the first frame update
    void Start()
    {
        sppechRenderer = GetComponent<SpriteRenderer>();
        sppechRenderer.enabled=false;

    }
    private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag=="Player")
            {
                index=0;
                playerdetected=true;
                sppechRenderer.enabled=true;
            
                player = other.gameObject.GetComponent<Transform>();
                if(player.position.x > transform.position.x && transform.parent.localScale.x<0)
                {
                    Flip();
                }
                else if(player.position.x<transform.position.x && transform.parent.localScale.x>0)
                {
                    Flip();
                }
            }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            index=0;
            playerdetected=false;
            sppechRenderer.enabled=false;
            dialogue_canvas.enabled=false;
            Debug.Log("없어져야지");
            
        }
    }
    private void Flip()
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *=-1;
        transform.parent.localScale = currentScale;
    }
    // Update is called once per frame
    void Update()
    {
            if(playerdetected && Input.GetKeyDown(KeyCode.F)&&!dialogue_canvas.gameObject.activeSelf&&index==0)
            {
                Debug.Log("space바 입력");
               
                sppechRenderer.enabled=true;
                dialogue_canvas.gameObject.SetActive(true);
                dialogue_canvas.enabled=true;
                dialogue_canvas.GetComponent<Canvas>().enabled=true;
                gameObject.GetComponent<Dialogue>().GetString(index);
                Debug.Log("첫번째 스페이스 입력");
                index++;
                
            }
            else if(playerdetected && Input.GetKeyDown(KeyCode.F) && index<gameObject.GetComponent<Dialogue>().dialogueLines.Length)
            {
                Debug.Log("마지막 대사 출력");
                gameObject.GetComponent<Dialogue>().GetString(index);
                index++;
                
            }
            else if(index==gameObject.GetComponent<Dialogue>().dialogueLines.Length&&playerdetected && Input.GetKeyDown(KeyCode.F))
            {
                
                Debug.Log("대화창 나가기");
                dialogue_canvas.gameObject.SetActive(false);
                dialogue_canvas.GetComponent<Canvas>().enabled=false;
                Debug.Log(index);
                index=0;
                
            }
            
            
            
    }
}