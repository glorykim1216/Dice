using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform trigger;
    public Transform[] dices;

    private Vector3[] resetPos = {
        new Vector3(-3.5f, 22.01f, 23.53f),
        new Vector3(0f, 22.01f, 23.53f),
        new Vector3(3.14f, 22.01f, 23.53f)
    };

    int[] num = new int[3];
    bool isGaming = false;
    bool isReady = true;
    void Start()
    {
        GameReset();
    }

    public void GameStart()
    {
        if (isReady == true)
        {
            isGaming = true;
            isReady = false;
            StartCoroutine("cor_GameStart");
        }
    }
    public void GameReset()
    {
        if (isGaming == false)
        {
            isReady = true;

            trigger.eulerAngles = new Vector3(0, 0, 0);
            for (int i = 0; i < dices.Length; i++)
            {
                int randomX = Random.Range(0, 4);
                int randomY = Random.Range(0, 4);
                int posX = Random.Range(-1, 3);
                dices[i].position = resetPos[i] + new Vector3((float)posX * 0.1f, 0, 0); ;
                dices[i].rotation = Quaternion.Euler(new Vector3(randomX * 90 + 30, 0, randomY * 90));
                dices[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            UIManager.Instance.StarInit();

        }
    }
    IEnumerator cor_GameStart()
    {
        int count = dices.Length;
        Rigidbody[] rigid = new Rigidbody[count];
        int[] velocityZero = new int[count];
        for (int i = 0; i < count; i++)
        {
            rigid[i] = dices[i].GetComponent<Rigidbody>();
            rigid[i].isKinematic = false;
        }

        float angle = 0;
        while (angle < 110)
        {
            angle += 8f;
            trigger.eulerAngles = new Vector3(angle, 0, 0);
            yield return null;
        }

        while (true)
        {
            int stopDice = 1;
            for (int i = 0; i < count; i++)
            {
                if (rigid[i].velocity == Vector3.zero)
                    velocityZero[i] = 1;

                stopDice *= velocityZero[i];
            }
            if (stopDice == 1)
            {
                for (int i = 0; i < dices.Length; i++)
                {
                    num[i] = dices[i].GetComponent<Dice>().CheckNum();
                }

                UIManager.Instance.StarOn(num);

                isGaming = false;
                break;
            }
            yield return null;

        }
    }
}
