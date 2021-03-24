/*************************************************
Simtop
Author: 刘全
Description: 
Others:
Function List: 
History: 
// 者及修改内 容简述
1. Date:
Author:
Modification:
*************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager> {
    public Dictionary<string, UIBaseForm> allUIForms = new Dictionary<string, UIBaseForm>();
    
    public void RegisterUI(string uiName, UIBaseForm form)
    {
        if (!allUIForms.ContainsKey(uiName))
        {
            allUIForms.Add(uiName, form);
            if (form.closeOnStart)
            {
                form.Hide();
            }
        }
    }

    public void UnRegisterUI(string uiName)
    {
        if (allUIForms.ContainsKey(uiName))
        {
            allUIForms.Remove(uiName);
        }
    }

    public void ShowUIForm(string uiName)
    {
        var forms = FindObjectsOfType<UIBaseForm>();
        if (allUIForms.ContainsKey(uiName))
        {
            allUIForms[uiName].Show();
        }
        else
        {
            foreach (var item in forms)
            {
                if (string.Equals(uiName, item.UIName))
                {
                    RegisterUI(uiName, item);
                    item.Show();
                }
            }
        }
    }

    public void HideUIForm(string uiName)
    {
        allUIForms[uiName].Hide();
    }

    public UIBaseForm GetUIForm(string uiName)
    {
        if (allUIForms.ContainsKey(uiName))
        {
            return allUIForms[uiName];
        }
        return null;
    }
}
