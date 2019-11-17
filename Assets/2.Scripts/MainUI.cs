using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button playBtn;

    private bool isBanner = true;
    public Button bannerAd;
    public Button screenAd;
    public Button rewardAd;

    void Start()
    {
        playBtn.onClick.AddListener(()=> { SceneManager.LoadScene("Dice"); });

        GlobalManager.Instance.startGame();

        //bannerAd.onClick.AddListener(() => { isBanner = !isBanner; AdmobBanner.Instance.ToggleAd(isBanner); });
        //screenAd.onClick.AddListener(() => { AdmobScreenAd.Instance.ShowScreenAd(); });
        //rewardAd.onClick.AddListener(() => { AdmobReward.Instance.ShowRewardAd(); });
    }
}
