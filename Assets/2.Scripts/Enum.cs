﻿// 공통으로 사용되는 Enum 값

public enum eScene             
{
    SCENE_NONE,
    SCENE01_INTRO,
    SCENE02_BASIC_TUTORIAL,
    SCENE03_BASIC_PRACTICE,
    SCENE04_S_COURSE,
    SCENE05_EXCAVATION,
    MAX
}

public enum eUIType         // UI 프리펩
{
    PF_UI_BETS,
    PF_UI_BET_TABLE,
    PF_UI_REWARD_AD,

    MAX
}

public enum eDiceNum
{
    ONE = 0,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX
}

public enum eGoldUnit
{
    NONE,
    K,      // 킬로
    M,      // 메가
    G,      // 기가
    T,      // 테라
    P,      // 페타
    E       // 엑사
}
