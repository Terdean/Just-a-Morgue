using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            player.useLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.useLadder = false;
        }
    }
}
