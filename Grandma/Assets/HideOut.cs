using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOut : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer playerRenderer;
    private Transform playerPos;
    private bool isInHideOut = false;
    private bool hiding = false;

    private void Start()
    {
        playerRenderer = player.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // ��Ż�� �����ϴ��� ���θ� Ȯ��
        if (!hiding && isInHideOut && Input.GetKeyDown(KeyCode.Space))
        {
            // �����̽��ٸ� ������ �̵�
            Hiding();
        }
        else if(hiding && Input.GetKeyDown(KeyCode.Space))
        {
            ComeOut();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ż�� �����ϸ� ���¸� ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            isInHideOut = true;
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ��Ż�� ���������� ���¸� ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("exit");
            isInHideOut = false;
        }
    }

    private void Hiding()
    {
        // ����
        Debug.Log("hiding.....");

        // ��� ���ֱ�
        Color currentColor = playerRenderer.color;
        currentColor.a = 0;
        playerRenderer.color = currentColor;

        hiding = true;
    }

    private void ComeOut()
    {
        // ����
        Debug.Log("come out.....");

        // �ٽ� ����
        Color currentColor = playerRenderer.color;
        currentColor.a = 1;
        playerRenderer.color = currentColor;

        hiding = false;
    }
}
