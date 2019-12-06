using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform trigger;
    public Transform[] dices;
    private Rigidbody[] rigid;

    private Vector3[] resetPos = {
        new Vector3(-3.5f, 22.06f, 23.53f),
        new Vector3(0f, 22.06f, 23.53f),
        new Vector3(3.14f, 22.06f, 23.53f)
    };

    int[] num = new int[3];
    public bool isGaming = false;
    bool isReady = true;

    public override void Init() { }

    void Start()
    {
        GameReset();
        UIManager.Instance.ShowTotalGold(GlobalManager.Instance.gold);

        rigid = new Rigidbody[dices.Length];

        for (int i = 0; i < dices.Length; i++)
        {
            rigid[i] = dices[i].GetComponent<Rigidbody>();
            //rigid[i].isKinematic = false;
        }
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
    public bool GameReset()
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
                //dices[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            float[] tempBetGold = GlobalManager.Instance.betGold;
            for (int i = 0; i < tempBetGold.Length; i++)
            {
                if (tempBetGold[i] > 0)
                    GlobalManager.Instance.gold += tempBetGold[i];
            }
            GlobalManager.Instance.betGold = new float[6];

            UIManager.Instance.StarInit();
            UIManager.Instance.ShowTotalGold(GlobalManager.Instance.gold);

            return isGaming;
        }
        return isGaming;
    }
    IEnumerator cor_GameStart()
    {
        int count = dices.Length;
        int[] velocityZero = new int[count];

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

                break;
            }
            yield return null;

        }

        int[] _x = new int[6];  // 당첨 숫자
        for(int i=0;i<num.Length;i++)
        {
            _x[num[i]]++;
        }
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowResultBetTablePopup(GlobalManager.Instance.betGold, _x, GlobalManager.Instance.rewardMultiple);
        isGaming = false;

    }
}
