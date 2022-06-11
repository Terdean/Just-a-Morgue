using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndText : MonoBehaviour
{
    public float TimerDown = 10;
    public float Timer = 10;

    private void Start()
    {
        GameObject.Find("EndText2").transform.position = new Vector3(0, 0, -10000);
    }

    void Update()
    {
        if (TimerDown > 0)
        {
            TimerDown -= Time.deltaTime;
        }
        if(TimerDown < 6)
        {
            GameObject.Find("EndText2").transform.position = new Vector3(GameObject.Find("Canvas").transform.position.x,
                GameObject.Find("Canvas").transform.position.y - 2, 0);
        }
        if (TimerDown < 0)
        {
            SceneManager.LoadScene(0);
            TimerDown = Timer;
        }
    }
}
