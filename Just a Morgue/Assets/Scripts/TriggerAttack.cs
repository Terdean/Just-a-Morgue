using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Player player = coll.gameObject.GetComponent<Player>();
            ScriptedEnemy.Try = false;
            if (ScriptedEnemy.secondAttack == false && player.secondUseSwitch == true)
            {
                ScriptedEnemy.attack = true;
                ScriptedEnemy.secondAttack = true;
            }
        }
    }
}
