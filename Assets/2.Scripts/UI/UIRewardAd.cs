using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardAd : MonoBehaviour
{
    public delegate void YesEvent();
    public delegate void NoEvent();

    YesEvent Yes;
    NoEvent No;

    public Button ButtonOK;
    public Button ButtonNO;

    public Text rewardMultipleText;

    public void Init(YesEvent _yes, NoEvent _no, int _rewardMultiple)
    {
        // 이벤트 전달
        Yes = _yes;
        No = _no;
        rewardMultipleText.text = "X " + _rewardMultiple.ToString();

        ButtonOK.onClick.RemoveAllListeners();
        ButtonNO.onClick.RemoveAllListeners();
        ButtonOK.onClick.AddListener(() => { BtnOK(); });
        ButtonNO.onClick.AddListener(() => { BtnNO(); });
    }

    public void BtnOK()
    {
        if (Yes != null)
        {
            Yes();
        }
    }
    public void BtnNO()
    {
        if (No != null)
        {
            No();
        }
    }
}
