using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDropdown : MonoBehaviour
{
    /// <summary> 按钮下滑速度/// </summary>
    public float speed = 10f;

    /// <summary> 列表栏/// </summary>
    private Transform content;

    private void GetContent()
    {
        content = transform.Find("Dropdown List/Viewport/Content");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetContent();
            if (content)
            {
                content.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetContent();
            if (content)
            {
                content.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
