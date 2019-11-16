using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent("Login");
        Firebase.Analytics.FirebaseAnalytics.LogEvent("Score", "percent", Random.Range(0, 100));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
