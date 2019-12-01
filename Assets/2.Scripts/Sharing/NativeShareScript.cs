using UnityEngine;
using System.Collections;
using System.IO;

public class NativeShareScript : MonoBehaviour
{
    public void ShareBtnPress()
    {
        StartCoroutine(TakeScreenShotAndShare());
    }

    // 화면 캡쳐 & 공유
    private IEnumerator TakeScreenShotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).Share();
    }
}