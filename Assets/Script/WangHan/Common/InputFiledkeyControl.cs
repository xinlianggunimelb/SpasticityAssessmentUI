using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 在所有InputField中，输入Tables键，光标跳转至下一个InputField
/// </summary>
public static class InputFiledkeyControl 
{
    /// <summary>
    /// 输入Table键时触发
    /// </summary>
    /// <param name="parentTran">指定一个组件</param>
    public static void InputTable(Transform parentTran)
    {
        InputField[] inputFieldArray = PretreatmentTran(parentTran);
        if (Input.GetKey(KeyCode.Tab))
        {
            GameObject obj = EventSystem.current.currentSelectedGameObject;
            if (obj == null || (obj != null && obj.GetComponent<InputField>() == null))
                SetActivateGameObject(inputFieldArray[0].gameObject);
            else if (obj.GetComponent<InputField>() != null)
            {
                for (int i = 0; i < inputFieldArray.Length; i++)
                {
                    if (inputFieldArray[i] == obj.GetComponent<InputField>()
                        && (i + 1) < inputFieldArray.Length)
                    {
                        SetActivateGameObject(inputFieldArray[i + 1].gameObject);
                        return;
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// 对需要处理的组件做一个预处理（调整输入框的排列顺序）
    /// </summary>
    /// <param name="parentTran">需要做预处理的组件</param>
    /// <returns></returns>
    private static InputField[] PretreatmentTran(Transform parentTran)
    {
        //首先获取父物体的InputField
        InputField parentTranInputField = parentTran.GetComponent<InputField>();
        List<InputField> inputFieldList = new List<InputField>();
        //其次判断父物体的InputField是否为空
        if (parentTranInputField != null)
        {
            //如果输入框是激活的则添加到输入框队列里面
            if (parentTranInputField.interactable)
            {
                inputFieldList.Add(parentTranInputField);
            }
        }
        List<InputField> childInputFieldList = GetTransformByRecursion<InputField>(parentTran);
        for (int i = 0; i < childInputFieldList.Count; i++)
        {
            //如果输入框是激活的则添加到输入框队列里面
            if (childInputFieldList[i].interactable)
            {
                inputFieldList.Add(childInputFieldList[i]);
            }
        }
        InputField[] inputFieldArray = inputFieldList.ToArray();
        return inputFieldArray;
    }

    /// <summary>
    /// 设置当前状态下需要激活的物体
    /// </summary>
    /// <param name="obj">需要激活的物体</param>
    private static void SetActivateGameObject(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(obj);
    } 


    /// <summary>
    /// 通过递归获取所有想要类型的组件
    /// </summary>
    /// <typeparam name="T">需要的类型</typeparam>
    /// <param name="parentTran">需要遍历的组件</param>
    /// <returns></returns>
    private static List<T> GetTransformByRecursion<T>(Transform parentTran)
    {
        List<T> typeOfT = new List<T>();
        int childCount = parentTran.childCount;
        for (int i = 0; i < childCount; i++)
        {
            T needType=parentTran.GetChild(i).GetComponent<T>();
            if(needType!=null)
            {
                typeOfT.Add(needType);
            }
         List<T> typeofTs=GetTransformByRecursion<T>(parentTran.GetChild(i));
            for (int j = 0; j < typeofTs.Count; j++)
            {
                typeOfT.Add(typeofTs[j]);
            }
        }
        return typeOfT;
    }
}
