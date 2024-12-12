using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    // ����� ���ÿ� ���õ� ��ư�� ������ ��ũ��Ʈ��.
    // ��ư ������ ��𿡼� ��������� ������� �ּ� �޾��ֱ�.

    private Button _settingButton; // ���� ��ư
    private Button _settingSaveButton; // ����â Save ��ư
    private Button _settingBackButton; // ����â Back ��ư
    private GameObject _settingPanal; // ���� �г� �¿��� �뵵

    private void Awake()
    {
        // ������Ʈ�� ����� �������ִ� �κ�
        _settingButton = transform.Find("Button - Setting").GetComponent<Button>();
        _settingSaveButton = transform.Find("Panel - Popup/Button - Save").GetComponent<Button>();
        _settingBackButton = transform.Find("Panel - Popup/Button - Back").GetComponent<Button>();
        _settingPanal = transform.Find("Panel - Popup").gameObject;

    }

    private void Start()
    {

        // �����Ҷ� �� �˾�â�� ��Ȱ��ȭ ���¿�����.
        _settingPanal.SetActive(false);

        // ��ư�̺�Ʈ ��Ϻκ�.
        _settingButton.onClick.AddListener(SettingButtonClick);
        _settingSaveButton.onClick.AddListener(() => SettingPopUpButtonClick(0));
        _settingBackButton.onClick.AddListener(() => SettingPopUpButtonClick(1));

    }

    /// <summary>
    /// ���� ��ư Ŭ���� ȣ���� �Լ�.
    /// </summary>
    private void SettingButtonClick()
    {
        Utils.Log(" ���� ��ư Ŭ�� ");
        _settingPanal.SetActive(true);
    }

    /// <summary>
    /// ����â �˾� ��ư Ŭ�������� ������ �Լ�.
    /// </summary>
    /// <param name="num"> 0 = Save / 1 = Back </param>
    private void SettingPopUpButtonClick(int num)
    {
        switch (num)
        {
            case 0:
                // Todo: ���� �����ϴ� ó�� ����.
                Utils.Log(" Save ��ư Ŭ�� , �����ϴ� ���� ó�� ");

                break;
            case 1:
                Utils.Log(" Back ��ư Ŭ�� ");

                break;

            default:
                break;
        }

        // �˾�â �����.
        _settingPanal.SetActive(false);

    }

}
