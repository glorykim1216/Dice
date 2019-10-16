using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBets : MonoBehaviour
{
    public delegate void YesEvent();
    public delegate void NoEvent();

    YesEvent Yes;
    NoEvent No;

    public Button ButtonOK;

    public void Init(YesEvent _yes, NoEvent _no, string _title, string _contens)
    {
        // 이벤트 전달
        Yes = _yes;     
        No = _no;

        ButtonOK.onClick.AddListener(() => { BtnOK(); });

        //titleText.text = _title;

        //contentsText.text = _contens;
    }
    public void BtnOK()
    {
        if (Yes != null)
        {
            Yes();
            UITools.Instance.HideUI(eUIType.PF_UI_BETS);
        }
    }

}
