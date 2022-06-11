using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStealth : MonoBehaviour
{
    public string collisionTag;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            player.useStealth = true;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();

            if (player.stealth == false)
            {
                animator.SetBool("Occupation", false);
            }
            else if(player.stealth == true)
            {
                animator.SetBool("Occupation", true);
            }
        }
    }private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.useStealth = false;
        }
    }

    
}
