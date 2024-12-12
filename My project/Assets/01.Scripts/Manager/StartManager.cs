using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class StartManager : MonoBehaviour
{
    private Button _startButton; // 시작 버튼.
    private GameData _gameData; // 로드된 데이터를 저장.

    private GameObject _newPlayerPopUp; // 신규 플레이어 초기설정을 위한 팝업창.
    private TMP_InputField _setNickName; // 신규 플레이어 닉네임 적는곳.
    private Button _setNickNameSave; // 신규 플레이어 닉네임 저장하는곳.

    private void Awake()
    {
        _startButton = transform.Find("GameObject - Buttons/Button - Start").GetComponent<Button>();

        _newPlayerPopUp = transform.Find("Panel - NewPlayerPopUp").gameObject;
        _setNickName = transform.Find("Panel - NewPlayerPopUp/InputField (TMP) - SetNickName").GetComponent<TMP_InputField>();
        _setNickNameSave = transform.Find("Panel - NewPlayerPopUp/Button - SaveNickName").GetComponent<Button>();
    }

    private void Start()
    {
        _newPlayerPopUp.SetActive(false); // 기본상태 비황성화.
        _startButton.onClick.AddListener(StartButtonClick); // 시작버튼 눌렀을때 실행할 이벤트.
        _setNickNameSave.onClick.AddListener(SaveNickNameButtonClick); // 신규 플레이어 닉네임 저장 버튼 눌렀을때 실행할 이벤트.
    }

    /// <summary>
    /// 시작 버튼눌렀을때 실행할 함수.
    /// </summary>
    private void StartButtonClick()
    {
        Utils.Log("C_LoadDataCoroutine 실행 전");
        StartCoroutine(C_LoadDataCoroutineWithCallback(() =>
        {
            Utils.LogGreen("로드된 데이터 닉네임: " + _gameData.playerName);

            if (_gameData.playerName == "Guest")
            {
                Utils.Log("기본 설정을 불러왔습니다.");
                _newPlayerPopUp.SetActive(true);
            }
            else
            {
                Utils.Log("저장된 데이터를 불러왔습니다: " + _gameData.playerName);
                StartCoroutine(C_SaveDataAndChangeScene());
            }
        }));
    }

    /// <summary>
    /// 신규플레이어 닉네임 저장 버튼을 눌렀을때 실행할 함수.
    /// </summary>
    private void SaveNickNameButtonClick()
    {
        _gameData.playerName =_setNickName.text;
        _newPlayerPopUp.SetActive(false) ;
        Utils.Log("플레이어 닉네임을 설정했습니다. " + _gameData.playerName);
        Utils.Log("C_SaveDataAndChangeScene 코루틴 실행전");
        StartCoroutine(C_SaveDataAndChangeScene());
    }

    /// <summary>
    /// 씬 변경전에 유저데이터 정보를 넘기는 코루틴.
    /// </summary>
    private IEnumerator C_SaveDataAndChangeScene()
    {
        if (_gameData != null)
        {
            Utils.Log("데이터 저장 실행 중");
            UserDataManager.Instance.SetUserData(_gameData);
        }
        else
        {
            Utils.LogRed("유저 데이터가 없습니다!");
            yield break;
        }

        yield return null; // 데이터 저장 후 한 프레임 대기 (선택 사항).

        // 비동기로 씬 로드.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        while (!asyncLoad.isDone)
        {
            // 로드 진행 상황 표시 등 추가 작업 가능.
            yield return null;
        }
    }

    /// <summary>
    /// 코루틴을 이용한 데이터 불러오기.
    /// </summary>
    /// <param name="callback"> 데이터 불러왔다는 알림. </param>
    /// <returns> 불러온 데이터. </returns>
    private IEnumerator C_LoadDataCoroutineWithCallback(System.Action callback)
    {
        // 파일 경로 설정.
        string path = Application.persistentDataPath + "/GameData.json";

        // 비동기적으로 로드 처리 (지연 시뮬레이션).
        yield return new WaitForSeconds(1.0f);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            _gameData = JsonUtility.FromJson<GameData>(json);
            Utils.Log("데이터 불러오기 성공: " + json);
        }
        else
        {
            Utils.LogRed("저장된 데이터가 없습니다. 기본값을 불러옵니다.");
            _gameData = new GameData();
            _gameData.SetDefaultValues();
        }

        Utils.Log("데이터 로드 완료.");
        callback?.Invoke(); // 코루틴 완료 후 콜백 호출.
    }
}

