using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoSingleton<GlobalManager>
{
    public float gold = 77777;
    public float[] betGold = new float[6];
    public int rewardMultiple = 1;

    private bool isDBLoad = false;

    public float time = 0;

    private void Start()
    {
        AdmobBanner.Instance.Init();
        AdmobScreenAd.Instance.Init();
        AdmobReward.Instance.Init();

        isDBLoad = DatabaseManager.Instance.Load();
        gold = DatabaseManager.Instance.ItemList.gold;
        //gold = 700;

    }
    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
    }
    public void startGame() { }
    public string GetGold2Unit(float _gold)
    {
        string resultStr = string.Empty;
        eGoldUnit goldUnit = eGoldUnit.NONE;
        float tempGold = _gold;
        bool isNegative = false;
        if (tempGold < 0)
        {
            isNegative = true;
            tempGold *= -1;
        }

        while (true)
        {
            if (tempGold >= 1000)
            {
                tempGold *= 0.001f;
                goldUnit++;
            }
            else
            {
                if (isNegative == true)
                    tempGold *= -1;

                if (goldUnit == eGoldUnit.NONE)
                    resultStr = tempGold.ToString("N0");
                else
                    resultStr = tempGold.ToString("N1") + goldUnit.ToString();

                return resultStr;
            }
        }
    }

    public void RewardAdCompleted()
    {
        rewardMultiple = UIManager.Instance.rewardMultiple;
        UIManager.Instance.rewardMultipleText.text = "Gold X " + rewardMultiple;
    }

    public void InitRewardMultiple()
    {
        rewardMultiple = 1;
        UIManager.Instance.rewardMultipleText.text = "";
    }

    // DB 저장
    public void DatabaseSave()
    {
        if (isDBLoad)
            DatabaseManager.Instance.UpdateItemTable((int)gold);
    }
}
