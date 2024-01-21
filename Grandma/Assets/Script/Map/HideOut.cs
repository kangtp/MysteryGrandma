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
        // 포탈에 진입하는지 여부를 확인
        if (!hiding && isInHideOut && Input.GetKeyDown(KeyCode.Space))
        {
            // 스페이스바를 누르면 이동
            Hiding();
        }
        else if(hiding && Input.GetKeyDown(KeyCode.Space))
        {
            ComeOut();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 포탈에 진입하면 상태를 변경
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            isInHideOut = true;
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 포탈을 빠져나가면 상태를 변경
        if (other.CompareTag("Player"))
        {
            Debug.Log("exit");
            isInHideOut = false;
        }
    }

    private void Hiding()
    {
        // 숨음
        Debug.Log("hiding.....");

        // 모습 없애기
        Color currentColor = playerRenderer.color;
        currentColor.a = 0;
        playerRenderer.color = currentColor;

        hiding = true;
    }

    private void ComeOut()
    {
        // 나옴
        Debug.Log("come out.....");

        // 다시 등장
        Color currentColor = playerRenderer.color;
        currentColor.a = 1;
        playerRenderer.color = currentColor;

        hiding = false;
    }
}
