using UnityEngine;
using System.Collections;

public class Vibration : MonoSingleton<Vibration>
{

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"); 
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public void Vibrate()
    {
        if (isAndroid())
            vibrator.Call("vibrate");
        else
            Handheld.Vibrate();
    }


    public void Vibrate(long milliseconds)
    {
        if (isAndroid())
            vibrator.Call("vibrate", milliseconds);
        else
            Handheld.Vibrate();
    }

    // 패턴 ex) Virate(new long[] {1000, 50, 2000, 100},1);   =>   1000m진동 50쉬고 2000m진동 100쉬고
    public void Vibrate(long[] pattern, int repeat)
    {
        if (isAndroid())
            vibrator.Call("vibrate", pattern, repeat);
        else
            Handheld.Vibrate();
    }

    private bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true; 
#else
        return false;
#endif
    }
}