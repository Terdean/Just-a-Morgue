using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public string collisionTag;

    public Animator animator;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            if(player.key == true)
            {
                player.useDoor = true;
            }

            if(player.secondUseDoor == true)
            {
                animator.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.useDoor = false;
        }
    }
}
