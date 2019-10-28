using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoSingleton<GlobalManager>
{
    public int gold = 10000;
    public int[] betGold = new int[6];
}
