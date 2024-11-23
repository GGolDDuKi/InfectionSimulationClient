using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrderBlankUI : MPX_Clothing_Panel, IDropHandler
{
    public Image slotImage; // 빈칸의 이미지 컴포넌트

    bool check = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (!check)
        {
            // 드래그된 오브젝트 가져오기
            MPX_Clothing_Slot draggedItem = eventData.pointerDrag?.GetComponent<MPX_Clothing_Slot>();
            if (draggedItem != null)
            {
                // 드래그된 이미지의 스프라이트 가져오기
                Image draggedImage = draggedItem.GetComponent<Image>();
                if (draggedImage != null)
                {
                    if(draggedItem.name == gameObject.name)
                        checkingCount++;

                    // 빈칸의 이미지를 드래그된 이미지로 교체
                    slotImage.sprite = draggedImage.sprite;
                    slotImage.color = Color.white; // 이미지를 보이도록 설정
                    check = true;
                    // 드래그된 오브젝트 비활성화
                    draggedItem.gameObject.SetActive(false);
                }
            }
        }
    }
}
