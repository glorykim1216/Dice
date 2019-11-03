using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoSingleton<GlobalManager>
{
    public float gold = 77777;
    public float[] betGold = new float[6];

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
}
