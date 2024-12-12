[System.Serializable]
public class GameData
{
    // 게임에서 저장시킬 데이터들.
    public int highScore;
    public float coins;
    public string playerName;

    // 기본값 설정
    public void SetDefaultValues()
    {
        highScore = 0;
        coins = 100.0f; // 기본 코인 값
        playerName = "Guest";
    }
}