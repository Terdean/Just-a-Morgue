using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = true;
            player.takeHammer = true;
            if(player.secondTakeHammer == true)
            {
                player.hammer = true;
                GameObject.Find("Hammer").SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.showE = false;
            player.takeHammer = false;
        }
    }
}
