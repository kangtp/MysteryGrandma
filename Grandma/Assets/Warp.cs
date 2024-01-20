using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform destination; // �̵��� ��ġ�� Transform
    private Transform playerPos;
    private bool isInPortal = false;

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
        if (destination != null)
        {
            // �÷��̾��� ��ġ�� �̵��� ��ġ�� ����
            playerPos.transform.position = destination.position;
        }
    }
}
