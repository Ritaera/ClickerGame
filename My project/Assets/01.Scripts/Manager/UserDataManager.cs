using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager Instance { get; private set; }
    public GameData UserData { get; private set; } // 유저 데이터.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시 파괴되지 않도록 설정.
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 생성되지 않도록 방지.
        }
    }

    // 데이터를 설정하는 메서드.
    public void SetUserData(GameData data)
    {
        UserData = data;
    }

    // 데이터를 가져오는 메서드 (필요 시 사용).
    public GameData GetUserData()
    {
        return UserData;
    }
}
