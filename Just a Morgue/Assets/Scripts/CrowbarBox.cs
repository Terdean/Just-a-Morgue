using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarBox : MonoBehaviour
{
    public string collisionTag;

    public Animator animator;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            player.breakCrowbarBox = true;
            if(player.secondBreakCrowbarBox == true && player.hammer == true)
            {
                animator.SetBool("Destroyed", true);
                player.crowbar = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.breakCrowbarBox = false;
        }
    }
}
