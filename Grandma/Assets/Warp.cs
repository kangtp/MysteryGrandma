using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform destination; // 이동할 위치의 Transform
    private Transform playerPos;
    private bool isInPortal = false;

    void Update()
    {
        // 포탈에 진입하는지 여부를 확인
        if (isInPortal && Input.GetKeyDown(KeyCode.Space))
        {
            // 스페이스바를 누르면 이동
            //Debug.Log("Warp...");
            MoveToDestination();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 포탈에 진입하면 상태를 변경
        if (other.CompareTag("Player"))
        {
            //Debug.Log("enter");
            isInPortal = true;
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 포탈을 빠져나가면 상태를 변경
        if (other.CompareTag("Player"))
        {
            //Debug.Log("exit");
            isInPortal = false;
        }
    }

    private void MoveToDestination()
    {
        // 이동할 위치로 이동
        if (destination != null)
        {
            // 플레이어의 위치를 이동할 위치로 설정
            playerPos.transform.position = destination.position;
        }
    }
}
