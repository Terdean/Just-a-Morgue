using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.Death();
        }
    }
}
