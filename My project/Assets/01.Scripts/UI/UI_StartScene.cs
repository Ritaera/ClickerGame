using UnityEngine;
using UnityEngine.UI;


public class UI_StartScene : MonoBehaviour
{

    // 여기는 Start Scene에 있는 UI 관련된 버튼을 관리할 스크립트임.
    // 버튼 생성시 어디에서 어떤목적으로 사용할지 주석 달아주기.

    private Button _uiUpgradeButton; // 업그레이드 버튼
    private Button _uiMiniGameButton; // 미니게임 버튼
    private Button _uiBagButton; // 가방 버튼
    private Button _uiDispatchedButton; // 파견 버튼
    private Button _uiShopButton; // 상점 버튼

    private GameObject _popUpPanal; // 팝업 게임오브젝트
    private GameObject _upgradeScrollViewGameObject; // 업그레이드 스크롤뷰 게임오브젝트
    private GameObject _miniGameScrollViewGameObject; // 미니게임 스크롤뷰 게임오브젝트
    private GameObject _bagScrollViewGameObject; // 가방 스크롤뷰 게임오브젝트
    private GameObject _dispatchedScrollViewGameObject; // 파견 스크롤뷰 게임오브젝트

    private Button _shopBackButton; // 상점에서 나가기 버튼

    private bool _upgradeScrollViewSetActive = false;
    private bool _miniGameScrollViewSetActive = false;
    private bool _bagScrollViewSetActive = false;
    private bool _dispatchedScrollViewSetActive = false;

    private void Awake()
    {
        _uiUpgradeButton = transform.Find("Image - BottomButton/GameObject - Buttons/Button - UIUpgrade").GetComponent<Button>();
        _uiMiniGameButton = transform.Find("Image - BottomButton/GameObject - Buttons/Button - UIMiniGame").GetComponent<Button>();
        _uiBagButton = transform.Find("Image - BottomButton/GameObject - Buttons/Button - UIBag").GetComponent<Button>();
        _uiDispatchedButton = transform.Find("Image - BottomButton/GameObject - Buttons/Button - UIDispatched").GetComponent<Button>();
        _uiShopButton = transform.Find("Image - BottomButton/GameObject - Buttons/Button - UIShop").GetComponent<Button>();

        _popUpPanal = gameObject.transform.Find("GameObject - Popups/Panel - PopUp").gameObject;
        _upgradeScrollViewGameObject = gameObject.transform.Find("GameObject - Popups/Panel - PopUp/Scroll View - Upgrade").gameObject;
        _miniGameScrollViewGameObject = gameObject.transform.Find("GameObject - Popups/Panel - PopUp/Scroll View - MiniGame").gameObject;
        _bagScrollViewGameObject = gameObject.transform.Find("GameObject - Popups/Panel - PopUp/Scroll View - Bag").gameObject;
        _dispatchedScrollViewGameObject = gameObject.transform.Find("GameObject - Popups/Panel - PopUp/Scroll View - Dispatched").gameObject;

        _shopBackButton = transform.Find("Panel - Shop/GameObject - Buttons/Button - ShopBack").GetComponent<Button>();
    }

    private void Start()
    {
        // 시작했을때 비활성화 해야하는것들
        _popUpPanal.SetActive(false);
        SetActiveFalseSetting();

        _uiUpgradeButton.onClick.AddListener(UiUpgradeButtonClick);
        _uiMiniGameButton.onClick.AddListener(UiMiniGameButtonClick);
        _uiBagButton.onClick.AddListener(UiBagButtonClick);
        _uiDispatchedButton.onClick.AddListener(UiDispatchedButtonClick);
        // _uiShopButton.onClick.AddListener();
        // _shopBackButton.onClick.AddListener();
    }

    /// <summary>
    /// 스크롤뷰 전체 비활성화
    /// </summary>
    private void SetActiveFalseSetting()
    {
        _upgradeScrollViewGameObject.SetActive(false);
        _miniGameScrollViewGameObject.SetActive(false);
        _bagScrollViewGameObject.SetActive(false);
        _dispatchedScrollViewGameObject.SetActive(false);
    }

    /// <summary>
    /// UIUpgrade버튼눌렀을때 실행될 함수.
    /// </summary>
    private void UiUpgradeButtonClick()
    {
        if (_upgradeScrollViewSetActive)
        {
            _popUpPanal.SetActive(false);
            SetActiveFalseSetting();
            _upgradeScrollViewSetActive = !_upgradeScrollViewSetActive;
        }
        else
        {
            SetActiveFalseSetting();
            _popUpPanal.SetActive(true);
            _upgradeScrollViewGameObject.SetActive(true);
            _upgradeScrollViewSetActive = !_upgradeScrollViewSetActive;

            _miniGameScrollViewSetActive = false;
            _bagScrollViewSetActive = false;
            _dispatchedScrollViewSetActive = false;
        }
    }

    /// <summary>
    /// UIMiniGame 버튼눌렀을때 실행될 함수.
    /// </summary>
    private void UiMiniGameButtonClick()
    {
        if (_miniGameScrollViewSetActive)
        {
            _popUpPanal.SetActive(false);
            SetActiveFalseSetting();
            _miniGameScrollViewSetActive = !_miniGameScrollViewSetActive;

        }
        else
        {
            SetActiveFalseSetting();
            _popUpPanal.SetActive(true);
            _miniGameScrollViewGameObject.SetActive(true);
            _miniGameScrollViewSetActive = !_miniGameScrollViewSetActive;

            _upgradeScrollViewSetActive = false;
            _bagScrollViewSetActive = false;
            _dispatchedScrollViewSetActive = false;
        }
    }

    /// <summary>
     /// UIBag 버튼눌렀을때 실행될 함수.
     /// </summary>
    private void UiBagButtonClick()
    {
        if (_bagScrollViewSetActive)
        {
            _popUpPanal.SetActive(false);
            SetActiveFalseSetting();
            _bagScrollViewSetActive = !_bagScrollViewSetActive;

        }
        else
        {
            SetActiveFalseSetting();
            _popUpPanal.SetActive(true);
            _bagScrollViewGameObject.SetActive(true);
            _bagScrollViewSetActive = !_bagScrollViewSetActive;

            _upgradeScrollViewSetActive = false;
            _miniGameScrollViewSetActive = false;
            _dispatchedScrollViewSetActive = false;
        }
    }

    /// <summary>
     /// UIDispatched 버튼눌렀을때 실행될 함수.
     /// </summary>
    private void UiDispatchedButtonClick()
    {
        if (_dispatchedScrollViewSetActive)
        {
            _popUpPanal.SetActive(false);
            SetActiveFalseSetting();
            _dispatchedScrollViewSetActive = !_dispatchedScrollViewSetActive;

        }
        else
        {
            SetActiveFalseSetting();
            _popUpPanal.SetActive(true);
            _dispatchedScrollViewGameObject.SetActive(true);
            _dispatchedScrollViewSetActive = !_dispatchedScrollViewSetActive;

            _upgradeScrollViewSetActive = false;
            _miniGameScrollViewSetActive = false;
            _bagScrollViewSetActive = false;
        }
    }
}
