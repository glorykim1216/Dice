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
        startBtn.onClick.AddListener(() => { GameManager.Instance.GameStart(); });
        resetBtn.onClick.AddListener(() => { GameManager.Instance.GameReset(); });
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
        numBtn[_num[3]].transform.Find("Star").gameObject.SetActive(true);
    }
}
