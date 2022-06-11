using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoxes : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            if(player.secondBreakCrowbarBox == true)
            {
                player.useCrowbar = true;
            }    
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.useCrowbar = false;
        }
    }
}
