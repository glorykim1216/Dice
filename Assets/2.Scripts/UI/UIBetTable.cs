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

    int prizeGold; // 상금

    public void Init(YesEvent _yes, int[] _bet, int[] _x)
    {
        // 이벤트 전달
        Yes = _yes;

        ButtonOK.onClick.AddListener(() => { BtnOK(); });

        for (int i = 0; i < _bet.Length; i++)
        {
            betText[i].text = _bet[i].ToString();
            xText[i].text = _x[i].ToString();

            if (_x[i] == 0)
            {
                winText[i].text = (_bet[i] * -1).ToString();
            }
            else if (_x[i] == 1)
            {
                int win = _bet[i] * 2;
                prizeGold += win;
                winText[i].text = win.ToString();
            }
            else if(_x[i] == 2)
            {
                int win = _bet[i] * 3;
                prizeGold += win;
                winText[i].text = win.ToString();
            }
        }
    }

    public void BtnOK()
    {
        if (Yes != null)
        {
            GlobalManager.Instance.gold += prizeGold;    
            Debug.Log(GlobalManager.Instance.gold);
            ButtonOK.onClick.RemoveAllListeners();
            Yes();
        }
    }
}
