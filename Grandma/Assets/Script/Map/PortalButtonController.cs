using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isInButton = false;
    private bool activate = false;
    public GameObject portal;

    public Sprite lever_top;
    public Sprite lever_bottom;
    

    private void Start()
    {
        
    }

    void Update()
    {
        // 포탈에 진입하는지 여부를 확인
        if (isInButton && Input.GetKeyDown(KeyCode.Space))
        {
            // 스페이스바를 누르면 이동
            ActivatePortal();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 포탈에 진입하면 상태를 변경
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            isInButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 포탈을 빠져나가면 상태를 변경
        if (other.CompareTag("Player"))
        {
            Debug.Log("exit");
            isInButton = false;
        }
    }

    void ActivatePortal()
    {
        if(activate == false)
        {
            activate = true;
            portal.GetComponent<PortalSystem>().SetOpenPortal();
            GetComponent<SpriteRenderer>().sprite = lever_bottom;
        }
        else
        {
            activate = false;
            portal.GetComponent<PortalSystem>().SetClosePortal();
            GetComponent<SpriteRenderer>().sprite = lever_top;
        }
    }
}
