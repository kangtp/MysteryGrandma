using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GDAnimator : MonoBehaviour
{
    public Animator gm_anim;
    public Animator dad_anim;
    public Animator mom_anim;
    bool goParents = false;

    void Start()
    {
        gm_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //actually after dialogue, call SetTrigger
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            gm_anim.SetTrigger("goParents");
            goParents = true;
        }

        if (goParents)
        {
            StartCoroutine(MoveToParents());

            if (transform.localPosition.x <= -21.5f)
            {
                StopCoroutine(MoveToParents());
                goParents = false;

                //after dialogue "bye"
                gm_anim.SetTrigger("kill");
                dad_anim.SetTrigger("dad_die");
            }
        }

        
    }

    IEnumerator MoveToParents()
    {
        transform.Translate(Vector3.left * 2 * Time.deltaTime);
        yield return null;
    }

}
