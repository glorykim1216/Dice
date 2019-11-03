using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBetTable : MonoBehaviour
{
    public delegate void YesEvent();

    YesEvent Yes;

    public Button ButtonOK;
    public Text[] betText;
    public Text[] xText;
    public Text[] winText;

    float prizeGold; // 상금

    public void Init(YesEvent _yes, float[] _bet, int[] _x)
    {
        // 이벤트 전달
        Yes = _yes;

        ButtonOK.onClick.AddListener(() => { BtnOK(); });
        prizeGold = 0;
        for (int i = 0; i < _bet.Length; i++)
        {
            betText[i].text = GlobalManager.Instance.GetGold2Unit(_bet[i]);
            xText[i].text = _x[i].ToString();

            if (_x[i] == 0)
            {
                winText[i].text = GlobalManager.Instance.GetGold2Unit(_bet[i] * -1);
            }
            else if (_x[i] == 1)
            {
                float win = _bet[i] * 2;
                prizeGold += win;
                winText[i].text = GlobalManager.Instance.GetGold2Unit(win);
            }
            else if(_x[i] == 2)
            {
                float win = _bet[i] * 3;
                prizeGold += win;
                winText[i].text = GlobalManager.Instance.GetGold2Unit(win);
            }
        }
    }

    public void BtnOK()
    {
        if (Yes != null)
        {
            GlobalManager.Instance.betGold = new float[6];

            GlobalManager.Instance.gold += prizeGold;
            UIManager.Instance.ShowGold(GlobalManager.Instance.gold);
            Debug.Log(GlobalManager.Instance.gold);
            ButtonOK.onClick.RemoveAllListeners();


            Yes();
        }
    }
}
