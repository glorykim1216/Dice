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

    public Text tapToStart;
    void Start()
    {
        playBtn.onClick.AddListener(()=> { SceneManager.LoadScene("Dice"); });

        GlobalManager.Instance.startGame();

        StartCoroutine("cor_Blinking");
        
        //bannerAd.onClick.AddListener(() => { isBanner = !isBanner; AdmobBanner.Instance.ToggleAd(isBanner); });
        //screenAd.onClick.AddListener(() => { AdmobScreenAd.Instance.ShowScreenAd(); });
        //rewardAd.onClick.AddListener(() => { AdmobReward.Instance.ShowRewardAd(); });
    }

    IEnumerator cor_Blinking()
    {
        while (true)
        {
            float alphaTime = 0;
            float alpha = 0;
            Color textUIColor = tapToStart.color;
            while (alphaTime <= 1.0f)
            {
                alphaTime += Time.deltaTime * 1.5f;
                alpha = Mathf.Lerp(1.0f, 0.0f, alphaTime);

                textUIColor.a = alpha;
                tapToStart.color = textUIColor;

                yield return null;
            }
            alphaTime = 0;
            yield return new WaitForSeconds(0.5f);
            while (alphaTime <= 1.0f)
            {
                alphaTime += Time.deltaTime * 2.5f;
                alpha = Mathf.Lerp(0.0f, 1.0f, alphaTime);

                textUIColor.a = alpha;
                tapToStart.color = textUIColor;

                yield return null;
            }
            yield return new WaitForSeconds(0.5f);

        }
    }
}
