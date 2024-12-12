using UnityEngine;

public class Utils
{

    // Debug.Log 를 사용안하고 유니티에티터 에서만 사용하기 위해 만든 스크립트.
    // 나중에 Utils.Log 를 안지워도 성능문제는 없음.

    public static void Log(object message)
    {
#if UNITY_EDITOR
        Debug.Log(message);
#endif
    }

    public static void LogRed(object message)
    {
#if UNITY_EDITOR
        Debug.Log($"<color=red>{message}</color>");
#endif
    }

    public static void LogGreen(object message)
    {
#if UNITY_EDITOR
        Debug.Log($"<color=green>{message}</color>");
#endif
    }
}