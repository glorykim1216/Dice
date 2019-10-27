using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBets : MonoBehaviour
{
    //public delegate void YesEvent();
    //public delegate void NoEvent();

    //YesEvent Yes;
    //NoEvent No;

    //public Button ButtonOK;

    //public void Init(YesEvent _yes, NoEvent _no, string _title, string _contens)
    //{
    //    // 이벤트 전달
    //    Yes = _yes;     
    //    No = _no;

    //    ButtonOK.onClick.AddListener(() => { BtnOK(); });

    //    //titleText.text = _title;

    //    //contentsText.text = _contens;
    //}
    //public void BtnOK()
    //{
    //    if (Yes != null)
    //    {
    //        Yes();
    //        UITools.Instance.HideUI(eUIType.PF_UI_BETS);
    //    }
    //}

    public delegate void YesEvent();

    YesEvent Yes;

    public Button ButtonOK;
    public Text titleText;
    public Text goldText;
    public float betGold;
    public Slider slider;

    public void Init(YesEvent _yes, string _title, Color32 _color)
    {
        // 이벤트 전달
        Yes = _yes;

        ButtonOK.onClick.AddListener(() => { BtnOK(); });

        titleText.text = _title;
        titleText.color = _color;
        slider.value = 0;

        slider.onValueChanged.AddListener(delegate { valueChanged(); });
    }
    void valueChanged()
    {
        betGold = Mathf.Floor(slider.value * GlobalManager.Instance.gold);
        goldText.text = betGold.ToString();
    }
    public void BtnOK()
    {
        if (Yes != null)
        {
            GlobalManager.Instance.gold -= betGold;     // - 값 예외 처리 필요
            Debug.Log(GlobalManager.Instance.gold);
            ButtonOK.onClick.RemoveAllListeners();
            Yes();
        }
    }

}
