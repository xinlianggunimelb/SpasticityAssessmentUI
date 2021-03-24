using UnityEngine;
using System.Collections;

/// <summary>
/// 该脚本挂载到场景中一直存在的canvans中，检测当按下Table时，鼠标光标可以跳转至下一个输入框中
/// </summary>
public class InputTables : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InputFiledkeyControl.InputTable(transform);
        }
    }
}
