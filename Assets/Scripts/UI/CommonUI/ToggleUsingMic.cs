using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUsingMic : MonoBehaviour
{
    public Toggle toggle;

    void Awake()
    {
        // Toggle 컴포넌트를 가져옵니다.
        toggle = GetComponent<Toggle>();

        // 초기 상태를 설정
        toggle.isOn = Managers.Setting.UsingMic;

        // Toggle의 값 변경 리스너 추가
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Toggle 값이 변경될 때 호출되는 메서드
    void OnToggleValueChanged(bool value)
    {
        // 전달된 value를 사용하여 설정 값 변경
        Managers.Setting.UsingMic = value;

        if (Managers.Setting.MicCheckUI == null)
            Managers.Setting.MicCheckUI = GameObject.Find("CheckInferencing");

        if (!value && Managers.Setting.MicCheckUI != null)
            Managers.Setting.ChangeMicStateFalse();
        //Managers.Setting.MicCheckUI.GetComponent<TMP_Text>().text = "키워드를 알맞은 칸에 넣으세요";

        else if (value && Managers.Setting.MicCheckUI != null)
            Managers.Setting.ChangeMicStateTrue();
        //Managers.Setting.MicCheckUI.GetComponent<TMP_Text>().text = "키를 눌러 녹음을 시작하세요.";
    }
}

