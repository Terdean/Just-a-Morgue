using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Vector3 _newPosition;

    public static bool attack = false;
    public static bool secondAttack = false;

    public static bool Try = false;

    void Start()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        GameObject.Find("EnemyAmbient2").transform.position = GameObject.Find("ScriptedEnemy").transform.position;
        if (attack == true)
        {
            Move();
        }

        if(transform.position.x == 30)
        {
            attack = false;
        }
    }

    public void Move()
    {
        _newPosition = new Vector3(
            transform.position.x + _speed * Time.deltaTime,
            transform.position.y,
            transform.position.z);
        transform.position = _newPosition;
    }
}
