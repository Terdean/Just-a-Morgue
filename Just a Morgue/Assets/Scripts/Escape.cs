using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            if (player.useEscape == true)
            {
                player.endEscape = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.endEscape = false;
        }
    } 
}
