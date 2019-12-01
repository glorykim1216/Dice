using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossBanner : MonoBehaviour
{
    public Button crossBannerBtn;

    public Image crossBannerImg;
    public Sprite[] crossBannerSprites;

    void Start()
    {
        crossBannerBtn.onClick.AddListener(OpenPlayStore);

        crossBannerSprites = Resources.LoadAll<Sprite>("CrossBanner");

        StartCoroutine(cor_CrossBannerAnim());
    }

    IEnumerator cor_CrossBannerAnim()
    {
        while (true)
        {
            for (int i = 0; i < crossBannerSprites.Length; i++)
            {
                yield return new WaitForSeconds(0.05f);
                crossBannerImg.sprite = crossBannerSprites[i];
            }
        }
    }

    public void OpenPlayStore()
    {
        Application.OpenURL("market://details?id=com.planb.goatjump");
    }

}
