using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticManager : MonoBehaviour
{
    void Start()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent("Login");
        //Firebase.Analytics.FirebaseAnalytics.LogEvent("Score", "percent", Random.Range(0, 100));
    }
}
