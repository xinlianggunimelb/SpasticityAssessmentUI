using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 该脚本的作用主要是用于切换鼠标的图标形式的
/// </summary>
public class MouseItemChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>鼠标手 /// </summary>
    public Texture2D cursor;

    /// <summary>新的光标  /// </summary>
    public Texture2D pointer;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(pointer, Vector2.zero, CursorMode.ForceSoftware);
    }

    /// <summary>
    /// 如果目标物体隐藏了，将强制将鼠标切换为正常状态
    /// </summary>
    public void OnDisable()
    {
        Cursor.SetCursor(pointer, Vector2.zero, CursorMode.ForceSoftware);
    }
}
