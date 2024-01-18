using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_detect : MonoBehaviour
{
    private bool item_show = false;
    public int item_code;

    public GameObject text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(item_show && Input.GetKeyDown(KeyCode.F))
        {
           this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            item_show = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            item_show = false;
        }
    }
}
