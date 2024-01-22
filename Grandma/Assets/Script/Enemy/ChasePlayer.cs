using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public EnemyMove_Chase move;
    public GameObject parent;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            if(parent.transform.position.x - other.transform.position.x >0)
            {
                move.nextMove = -1;
               
            }
            else if(parent.transform.position.x - other.transform.position.x <0)
            {
                move.nextMove = 1;
                
            }
            if(move.nextMove!=0)
            {
                parent.GetComponent<SpriteRenderer>().flipX =1==move.nextMove;
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
