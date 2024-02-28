using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KidAnimator : MonoBehaviour
{
    public Animator anim;
    bool goHome = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            anim.SetTrigger("goRight");
            goHome = true;
        }

        if (goHome)
        {
            StartCoroutine(MoveToHome());

            if (transform.localPosition.x > -10)
            {
                StopCoroutine(MoveToHome());
                goHome = false;
                anim.SetTrigger("Enter");
            }
        }

        
    }

    IEnumerator MoveToHome()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
        yield return null;
    }

}
