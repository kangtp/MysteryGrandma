using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_Chase : MonoBehaviour
{

    Rigidbody2D rigid;
    public int nextMove;//다음 행동지표를 결정할 변수
    Animator animator;
    SpriteRenderer spriteRenderer;
    public float speed;
    public int hp;

    private int chase=0;

    // Start is called before the first frame update
    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 0f); // 초기화 함수 안에 넣어서 실행될 때 마다(최초 1회) nextMove변수가 초기화 되도록함 
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
       rigid.velocity = new Vector2(nextMove*speed,rigid.velocity.y); //nextMove 에 0:멈춤 -1:왼쪽 1:오른쪽 으로 이동 


       //Platform check(맵 앞이 낭떨어지면 뒤돌기 위해서 지형을 탐색)


       //자신의 한 칸 앞 지형을 탐색해야하므로 position.x + nextMove(-1,1,0이므로 적절함)
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.4f, rigid.position.y);

        //한칸 앞 부분아래 쪽으로 ray를 쏨
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));

        //레이를 쏴서 맞은 오브젝트를 탐지 
        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down,1,LayerMask.GetMask("Ground"));

        //탐지된 오브젝트가 null : 그 앞에 지형이 없음
        if(!raycast.collider){
            Turn();
        }

        if(Detect_player())
        {
            
            StartCoroutine("Attack");
            Debug.Log("플레이어 감지");
        }
        else if(!Detect_player())
        {
            Debug.Log("플레이어 안보임");
        }

    }


    void Think(){//몬스터가 스스로 생각해서 판단 (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

        //Set Next Active
        //Random.Range : 최소<= 난수 <최대 /범위의 랜덤 수를 생성(최대는 제외이므로 주의해야함)
        if(Detect_player())
        {
            nextMove=chase;
        }
        else{
            nextMove = Random.Range(-1,2);
        }

        //Sprite Animation
        //WalkSpeed변수를 nextMove로 초기화 
        animator.SetInteger("isRun",nextMove);


        //Flip Sprite
        if(nextMove != 0) //서있을 때 굳이 방향을 바꿀 필요가 없음 
            spriteRenderer.flipX = nextMove == 1; //nextmove 가 1이면 방향을 반대로 변경  


        //Recursive (재귀함수는 가장 아래에 쓰는게 기본적) 
        float time = Random.Range(2f, 5f); //생각하는 시간을 랜덤으로 부여 
        //Think(); : 재귀함수 : 딜레이를 쓰지 않으면 CPU과부화 되므로 재귀함수쓸 때는 항상 주의 ->Think()를 직접 호출하는 대신 Invoke()사용
        Invoke("Think", time); //매개변수로 받은 함수를 time초의 딜레이를 부여하여 재실행 
    }

    void Turn(){

        nextMove= nextMove*(-1); //우리가 직접 방향을 바꾸어 주었으니 Think는 잠시 멈추어야함
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke(); //think를 잠시 멈춘 후 재실행
        Invoke("Think",2);  

    }
    //공격모션 재현 // ray를 쐈을때 플레이어이면 공격모션 발동   
    public bool Detect_player()
    {
        Vector2 detect_player = new Vector2(rigid.position.x+nextMove,rigid.position.y);
        Debug.DrawRay(detect_player,new Vector3(nextMove,0,0),new Color(0,2,0));
        RaycastHit2D ray_player = Physics2D.Raycast(detect_player,new Vector3(nextMove,0,0),1,LayerMask.GetMask("Player"));
        if(ray_player)
        {
            
            return true;
        }
        else
        {
            return false;
        }
        
    }
    IEnumerator Attack()
    {
        CancelInvoke();
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.01f);  //애니끝날때까지 기다리기
        animator.SetBool("isAttack", false);
        Invoke("Think", 0.3f);  // 대신에 Invoke 대신에 0초 후에 호출
        StopCoroutine("Attack");
    }
    IEnumerator Die()
    {
        CancelInvoke();
        StopCoroutine("Attack");
        yield return new  WaitForSeconds(0.7f);
        Destroy(gameObject);
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            hp--;
            animator.SetInteger("Death",hp);
        }
        if(hp<0)
        {
            Debug.Log(" 너 다이");
            StartCoroutine("Die");
           
        }
    }

}