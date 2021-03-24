using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ImageEvent : MonoBehaviour,IPointerEnterHandler,IPointerUpHandler,IPointerExitHandler
{
    /// <summary>  鼠标左键按下时触发的事件  /// </summary>
    public Action pointerClickAction;

    /// <summary>  鼠标右键按下时触发的事件  /// </summary>
    public Action pointerRightClickAction;

    /// <summary>  鼠标松开时触发的事件  /// </summary>
    public Action pointerUpAction;

    /// <summary>光标是否进入到UI上面 /// </summary>
    private bool isEnter;

    private void Update()
    {
        if (isEnter)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButton(0))
                {
                    if (pointerClickAction != null)
                    {
                        pointerClickAction.Invoke();
                    }
                }
                else if (Input.GetMouseButton(1))
                {
                    if (pointerRightClickAction!=null)
                    {
                        pointerRightClickAction.Invoke();
                    }
                }

            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (pointerUpAction!=null)
        {
            //print("鼠标抬起了");
            pointerUpAction.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }
}
