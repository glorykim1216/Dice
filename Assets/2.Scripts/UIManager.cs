using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingleton<UIManager>
{
    public Button backBtn;
    public Button startBtn;
    public Button resetBtn;
    public Button[] numBtn;

    public Text goldText;

    public Text rewardMultipleText;
    public int rewardMultiple;

    public override void Init() { }

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(() => { SceneManager.LoadScene("Main"); });
        startBtn.onClick.AddListener(() => { GameManager.Instance.GameStart(); });
        resetBtn.onClick.AddListener(() =>
        {
            bool isGaming = GameManager.Instance.GameReset();

            int random = Random.Range(0, 3); // 1/3 확률로 보상광고
            if (isGaming == false && random == 0)
            {
                rewardMultiple = Random.Range(2, 7);     // 2~6 배
                ShowRewardMultiplePopup(rewardMultiple);
            }
        });

        // 버튼 연결
        numBtn[0].onClick.AddListener(() => { GetBetsPopup(eDiceNum.ONE, new Color32(0, 255, 0, 255)); });
        numBtn[1].onClick.AddListener(() => { GetBetsPopup(eDiceNum.TWO, new Color32(255, 0, 0, 255)); });
        numBtn[2].onClick.AddListener(() => { GetBetsPopup(eDiceNum.THREE, new Color32(0, 0, 255, 255)); });
        numBtn[3].onClick.AddListener(() => { GetBetsPopup(eDiceNum.FOUR, new Color32(120, 0, 170, 255)); });
        numBtn[4].onClick.AddListener(() => { GetBetsPopup(eDiceNum.FIVE, new Color32(60, 190, 220, 255)); });
        numBtn[5].onClick.AddListener(() => { GetBetsPopup(eDiceNum.SIX, new Color32(255, 150, 50, 255)); });

    }
    public void GetBetsPopup(eDiceNum _num, Color32 _color)
    {
        if (GameManager.Instance.isGaming == true)
            return;

        GameObject objUI = UITools.Instance.ShowUI(eUIType.PF_UI_BETS);
        UIBets popup = objUI.GetComponent<UIBets>();
        popup.Init(() =>
            {
                UITools.Instance.HideUI(eUIType.PF_UI_BETS);
                Debug.Log("OK");
            },
            _num,
            _color
        );
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

    public void ShowGold(float _gold)
    {
        goldText.text = GlobalManager.Instance.GetGold2Unit(_gold);
    }

    // 결과 팝업
    public void ShowBetTablePopup(float[] _bet, int[] _x, int _rewardMultiple)
    {
        GameObject objUI = UITools.Instance.ShowUI(eUIType.PF_UI_BET_TABLE);
        UIBetTable popup = objUI.GetComponent<UIBetTable>();
        popup.Init(
            () =>
            {
                UITools.Instance.HideUI(eUIType.PF_UI_BET_TABLE);

                GlobalManager.Instance.InitRewardMultiple();

                int random = Random.Range(0, 2);    // 1/2 확률로 전면광고
                if (random == 0)
                    AdmobScreenAd.Instance.ShowScreenAd();  

            },
            _bet,
            _x,
            _rewardMultiple
        );
    }
    public void ShowRewardMultiplePopup(int _rewardMultiple)
    {
        GameObject objUI = UITools.Instance.ShowUI(eUIType.PF_UI_REWARD_AD);
        UIRewardAd popup = objUI.GetComponent<UIRewardAd>();
        popup.Init(
            () =>
            {
                UITools.Instance.HideUI(eUIType.PF_UI_REWARD_AD);
                AdmobReward.Instance.ShowRewardAd();
            },
            () =>
            {
                UITools.Instance.HideUI(eUIType.PF_UI_REWARD_AD);
            },
            _rewardMultiple
        );
    }

}
