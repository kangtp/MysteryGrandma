using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool isInButton = false;
    private bool activate = false;
    public GameObject portal;

    private void Start()
    {
        
    }

    void Update()
    {
        // ��Ż�� �����ϴ��� ���θ� Ȯ��
        if (isInButton && Input.GetKeyDown(KeyCode.Space))
        {
            // �����̽��ٸ� ������ �̵�
            ActivatePortal();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ż�� �����ϸ� ���¸� ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            isInButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ��Ż�� ���������� ���¸� ����
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
        }
        else
        {
            activate = false;
            portal.GetComponent<PortalSystem>().SetClosePortal();
        }
    }
}
