using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string collisionTag;

    public Animator animator;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            if(player.secondUseSwitch == false)
            {
                player.useSwitch = true;
            }
            else
            {
                animator.SetBool("Used", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.useSwitch = false;
        }
    }
}
