using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{

    public Transform destination; // �̵��� ��ġ�� Transform
    private Transform playerPos;
    private bool isInPortal = false;
    public bool isOpen = false;
    private SpriteRenderer spriteRenderer;
    public Sprite openPortal;
    public Sprite closePortal;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // ��Ż�� �����ϴ��� ���θ� Ȯ��
        if (isInPortal && Input.GetKeyDown(KeyCode.Space))
        {
            // �����̽��ٸ� ������ �̵�
            //Debug.Log("Warp...");
            MoveToDestination();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ż�� �����ϸ� ���¸� ����
        if (other.CompareTag("Player"))
        {
            //Debug.Log("enter");
            isInPortal = true;
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ��Ż�� ���������� ���¸� ����
        if (other.CompareTag("Player"))
        {
            //Debug.Log("exit");
            isInPortal = false;
        }
    }

    private void MoveToDestination()
    {
        // �̵��� ��ġ�� �̵�
        if (destination != null && isOpen)
        {
            // �÷��̾��� ��ġ�� �̵��� ��ġ�� ����
            playerPos.transform.position = destination.position;
        }
    }

    
    public void SetOpenPortal()
    {
        isOpen = true;
        spriteRenderer.sprite = openPortal;
    }

    public void SetClosePortal()
    {
        isOpen = false;
        spriteRenderer.sprite = closePortal;
    }

}
