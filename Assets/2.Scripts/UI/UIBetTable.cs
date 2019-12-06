using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBetTable : MonoBehaviour
{
    NativeShareScript share;
    public delegate void YesEvent();

    YesEvent Yes;

    public Button ButtonOK;
    public Button ButtonShare;
    public Text[] betText;
    public Text[] xText;
    public Text[] winText;
    public Text TotalPrizeGold;
    public Text rewardMultipleText;

    float prizeGold; // 상금
    int rewardMultiple; // 보상형 광고 배율

    // 배팅테이블 확인
    public void Init(YesEvent _yes, float[] _bet)
    {
        // 이벤트 전달
        Yes = _yes;
        rewardMultipleText.text = "";

        ButtonOK.onClick.RemoveAllListeners();
        ButtonOK.onClick.AddListener(() => { BtnTableOK(); });
        ButtonShare.gameObject.SetActive(false);
        for (int i = 0; i < _bet.Length; i++)
        {
            betText[i].text = GlobalManager.Instance.GetGold2Unit(_bet[i]);
            xText[i].text = "0";
            winText[i].text = "0";
        }
        TotalPrizeGold.text = "0";
    }
    public void BtnTableOK()
    {
        if (Yes != null)
        {
            Yes();
        }
    }

    // 결과
    public void Init(YesEvent _yes, float[] _bet, int[] _x, int _rewardMultiple)
    {
        // 이벤트 전달
        Yes = _yes;
        rewardMultiple = _rewardMultiple;

        if (rewardMultiple > 1)
            rewardMultipleText.text = "X " + rewardMultiple.ToString();
        else
            rewardMultipleText.text = "";


        ButtonOK.onClick.RemoveAllListeners();
        ButtonOK.onClick.AddListener(() => { BtnOK(); });


        share = this.GetComponent<NativeShareScript>();
        ButtonShare.gameObject.SetActive(true);
        ButtonShare.onClick.RemoveAllListeners();
        ButtonShare.onClick.AddListener(() => { share.ShareBtnPress(); });

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
            else if (_x[i] == 2)
            {
                float win = _bet[i] * 3;
                prizeGold += win;
                winText[i].text = GlobalManager.Instance.GetGold2Unit(win);
            }
        }
        TotalPrizeGold.text = GlobalManager.Instance.GetGold2Unit(prizeGold);
    }

    public void BtnOK()
    {
        if (Yes != null)
        {
            if (prizeGold > 0)
            {
                GlobalManager.Instance.gold += (prizeGold * rewardMultiple);
                UIManager.Instance.ShowGetGold("+" + GlobalManager.Instance.GetGold2Unit(prizeGold * rewardMultiple));
                UIManager.Instance.ShowTotalGold(GlobalManager.Instance.gold);
                GlobalManager.Instance.DatabaseSave();

                //Debug.Log(GlobalManager.Instance.gold);
            }
            Yes();
        }
    }
}
