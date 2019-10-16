using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Button startBtn;
    public Button resetBtn;
    public Button[] numBtn;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(720, 1280, true);

        startBtn.onClick.AddListener(() => { GameManager.Instance.GameStart(); });
        resetBtn.onClick.AddListener(() => { GameManager.Instance.GameReset(); });

        // ex
        numBtn[0].onClick.AddListener(() => 
        {
            GameObject objUI = UITools.Instance.ShowUI(eUIType.PF_UI_BETS);
            UIBets popup = objUI.GetComponent<UIBets>();
            popup.Init(
                () =>
                {
                    Debug.Log("OK");
                },
                () =>
                {
                },
                "",
                ""
                );
        });
    }

    public void StarInit()
    {
        for (int i = 0; i < numBtn.Length; i++)
        {
            numBtn[i].transform.Find("Star").gameObject.SetActive(false);
        }
    }
    public void StarOn(int[] _num)
    {
        numBtn[_num[0]].transform.Find("Star").gameObject.SetActive(true);
        numBtn[_num[1]].transform.Find("Star").gameObject.SetActive(true);
        numBtn[_num[2]].transform.Find("Star").gameObject.SetActive(true);
    }
}
