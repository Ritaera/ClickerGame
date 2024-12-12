using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    // 여기는 세팅에 관련된 버튼을 관리할 스크립트임.
    // 버튼 생성시 어디에서 어떤목적으로 사용할지 주석 달아주기.

    private Button _settingButton; // 세팅 버튼
    private Button _settingSaveButton; // 세팅창 Save 버튼
    private Button _settingBackButton; // 세팅창 Back 버튼
    private GameObject _settingPanal; // 세팅 패널 온오프 용도

    private void Awake()
    {
        // 오브젝트가 어떤건지 지정해주는 부분
        _settingButton = transform.Find("Button - Setting").GetComponent<Button>();
        _settingSaveButton = transform.Find("Panel - Popup/Button - Save").GetComponent<Button>();
        _settingBackButton = transform.Find("Panel - Popup/Button - Back").GetComponent<Button>();
        _settingPanal = transform.Find("Panel - Popup").gameObject;

    }

    private void Start()
    {

        // 시작할때 이 팝업창은 비활성화 상태여야함.
        _settingPanal.SetActive(false);

        // 버튼이벤트 등록부분.
        _settingButton.onClick.AddListener(SettingButtonClick);
        _settingSaveButton.onClick.AddListener(() => SettingPopUpButtonClick(0));
        _settingBackButton.onClick.AddListener(() => SettingPopUpButtonClick(1));

    }

    /// <summary>
    /// 세팅 버튼 클릭시 호출할 함수.
    /// </summary>
    private void SettingButtonClick()
    {
        Utils.Log(" 세팅 버튼 클릭 ");
        _settingPanal.SetActive(true);
    }

    /// <summary>
    /// 세팅창 팝업 버튼 클릭했을때 실행할 함수.
    /// </summary>
    /// <param name="num"> 0 = Save / 1 = Back </param>
    private void SettingPopUpButtonClick(int num)
    {
        switch (num)
        {
            case 0:
                // Todo: 설정 저장하는 처리 로직.
                Utils.Log(" Save 버튼 클릭 , 저장하는 로직 처리 ");

                break;
            case 1:
                Utils.Log(" Back 버튼 클릭 ");

                break;

            default:
                break;
        }

        // 팝업창 숨기기.
        _settingPanal.SetActive(false);

    }

}
