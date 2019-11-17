using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdmobScreenAd : MonoSingleton<AdmobScreenAd>
{
    private readonly string unitID = "ca-app-pub-3940256099942544/1033173712";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd screenAd;

    public override void Init()
    {
        InitAd();
        base.Init();
    }

    private void InitAd()
    {
        screenAd = new InterstitialAd(unitID);

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);

        screenAd.OnAdClosed += (sender, e) => { screenAd.Destroy(); InitAd(); };    // 광고를 보면 다시로드
    }
    public void ShowScreenAd()
    {
        StartCoroutine("cor_ShowScreenAd");
    }
    private IEnumerator cor_ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            yield return null;
        }
        screenAd.Show();
    }

}
