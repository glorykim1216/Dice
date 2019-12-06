// 주사위

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Transform[] num = new Transform[6];
    void Start()
    {
        for (int i = 0; i < num.Length; i++)
        {
            num[i] = this.transform.Find((i + 1).ToString());
        }
    }

    public int CheckNum()
    {
        int result = 0;
        float posY = 0;
        for (int i = 0; i < num.Length; i++)
        {
            if (posY < num[i].position.y)
            {
                posY = num[i].position.y;
                result = i;
            }
        }
        return result;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.transform.tag.Equals("Dice1") && GameManager.Instance.isGaming == true)
            Vibration.Instance.Vibrate(10);
    }
}
