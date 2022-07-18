using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canBePressed;

    public KeyCode keyToPress;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            Debug.Log(transform.position.y);
            if (canBePressed)
            {
                gameObject.SetActive(false);


                if(transform.position.y > 0.42f)
                {
                    Debug.Log("normal");
                    Debug.Log(transform.position.y);
                    GameManager.instance.NormalHit();
                } else if(transform.position.y  > 0.35f)
                {
                    Debug.Log("good");
                    GameManager.instance.GoodHit();
                } else
                {
                    Debug.Log("perfect");
                    GameManager.instance.PerfectHit();
                }
                //GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            Debug.Log("start");
            Debug.Log(transform.position.y);
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            Debug.Log("end");
            Debug.Log(transform.position.y);
            canBePressed = false;

            gameObject.SetActive(false);

            // GameManager.instance.NoteMissed();
        }
    }
}
