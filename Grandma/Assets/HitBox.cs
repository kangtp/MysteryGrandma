using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    bool hit=false; // 효과가 발생했는지 여부를 나타내는 변수

    public bool In_DetcetBox()
    {
        return hit;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag=="Player")
        {
            hit=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        hit=false;
    }
    
    

    

   
}
