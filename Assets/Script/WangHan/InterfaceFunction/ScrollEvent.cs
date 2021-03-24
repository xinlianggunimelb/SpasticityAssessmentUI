using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollEvent : MonoBehaviour,IEndDragHandler,IScrollHandler
{
    /// <summary>是否需要滚动操作 /// </summary>
    public bool isNeedScroll;

    /// <summary>是否需要拖拽操作 /// </summary>
    public bool isNeedDrag;

    /// <summary> 滑动区域 /// </summary>
    public  ScrollRect rect;

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isNeedDrag)
        {
            CheckScrollStatus();
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (isNeedScroll)
        {
            CheckScrollStatus();
        }
    }

    private void CheckScrollStatus()
    {

    }
}
