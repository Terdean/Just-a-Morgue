using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool chase;

    private float HorizontalMove = 0f;
    private bool facingRight = true;

    void Update()
    {
        GameObject.Find("EnemyAmbient").transform.position = GameObject.Find("Enemy").transform.position;

        if (HorizontalMove > 0 && facingRight)
        {
            Flip();
        }
        else if (HorizontalMove < 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
