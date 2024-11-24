using Google.Protobuf.Protocol;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MPX_Clothing_Panel : MonoBehaviour
{ 
    public int checkingCount = 0;
    List<GameObject> blankSlot;
    List<GameObject> clothingSlot;
    GameObject Order;
    private void Awake()
    {
        Order = Util.FindChild(gameObject, "Order");
        Managers.Object.MyPlayer.State = CreatureState.Conversation;
    }
    public void Open_MPX_Panel()
    {
        if (Managers.Scenario.CurrentScenarioInfo.Position != Managers.Object.MyPlayer.Position)
        {
            Managers.UI.CreateSystemPopup("WarningPopup", "해당 구역이 아닙니다.", UIManager.NoticeType.Warning);
            return;
        }
        Managers.Object.MyPlayer.State = CreatureState.Conversation;
    }

    public void CloseMPX_Panel()
    {
        Managers.UI.DestroyUI(gameObject);
        Managers.Object.MyPlayer.State = CreatureState.Idle;
    }

    public void CheckOrder()
    {
        if (checkingCount == Order.transform.childCount)
        {
            Managers.UI.CreateSystemPopup("WarningPopup", "정답입니다.", UIManager.NoticeType.Info);
            CloseMPX_Panel();
            Managers.Scenario.CompleteCount++;
            //Destroy(gameObject);
        }
        else
        {
            Managers.UI.CreateSystemPopup("WarningPopup", "틀렸습니다.", UIManager.NoticeType.Info);
            Managers.UI.CreateUI(Managers.Scenario.CurrentScenarioInfo.Action);
            Destroy(gameObject);
        }
    }
}
