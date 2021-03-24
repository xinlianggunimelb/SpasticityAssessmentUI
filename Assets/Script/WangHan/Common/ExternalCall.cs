/*************************************************
Simtop
Author: 王晗
Description: 
Others: // 其它内容的说明
Function List: // 主要函数列表，每条记录应包括函数名及功能简要说明
1. ....
History: // 修改历史记录列表，每条修改记录应包括修改日期、修改
// 者及修改内 容简述
1. Date:
Author:
Modification:
2. ...
*************************************************/

using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Application = UnityEngine.Application;
using System;
using System.Text;
using UnityEngine.Networking;

public class ExternalCall
{
    private static string defaultPath = Global.GetDesktopPath();
    ///// <summary>
    ///// 选择“是”或者“否”的面板
    ///// </summary>
    ///// <param name="title">标题名</param>
    ///// <param name="message">内容</param>
    ///// <returns></returns>
    //public static bool DisplayDialog(string title, string message)
    //{
    //    Process p = new Process();
    //    p.StartInfo.FileName = Application.streamingAssetsPath+ "/OpenFilePanel/UnityDisplayDialog";
    //    p.StartInfo.Arguments = title+" "+ message+" " + (int)MessageBoxButtons.YesNo + " " + (int)MessageBoxIcon.Question;
    //    p.StartInfo.CreateNoWindow = true;
    //    p.StartInfo.UseShellExecute = false;
    //    p.StartInfo.RedirectStandardInput = true;
    //    p.StartInfo.RedirectStandardOutput = true;
    //    //p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("gbk");//Unity不支持gbk
    //    p.Start();
    //    string output = WWW.UnEscapeURL(p.StandardOutput.ReadToEnd());
    //    p.WaitForExit();
    //    p.Close();
    //    return bool.Parse(output);
    //}

    /// <summary>
    /// 选择文件面板
    /// </summary>
    /// <param name="titles">标题</param>
    /// <param name="filters">后缀分类需要成对文件类型和文件后，例如 { "CSharp", "cs,txt" }</param>
    /// <param name="directory">打开的文件夹位置</param>
    /// <returns></returns>
    public static string OpenFilePanel(string titles, string[] filters,string directory=null )
    {
        //如果路径为空，则设置路径为桌面路径
        if (string.IsNullOrEmpty(directory))
        {
            directory = defaultPath;
        }
        string filterStr = null;
        if (filters != null)
        {
            filterStr = ExtenSplit(filters);
        }
        else
        {
            filterStr = "All files|*.*";
        }
        Process p = new Process();
        p.StartInfo.FileName = Application.streamingAssetsPath + "/OpenFilePanel/UnityOpenFilePanel";
        p.StartInfo.Arguments = titles+ " " + directory + " "+ filterStr + " false";
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        //p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("gbk");//Unity不支持gbk
        p.Start();
        string output = UnityWebRequest.UnEscapeURL(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
        output=output.Replace("\r\n", "");
        return output;
    }

    /// <summary>
    /// 选择文件夹
    /// </summary>
    /// <param name="titles">标题名</param>
    /// <param name="directory">打开的文件夹位置</param>
    public static string OpenFolderPanel(string titles,string directory=null)
    {
        //如果路径为空，则设置路径为桌面路径
        if (string.IsNullOrEmpty(directory))
        {
            directory = defaultPath;
        }
        Process p = new Process();
        p.StartInfo.FileName = Application.streamingAssetsPath + "/OpenFilePanel/UnityOpenFolderPanel";
        p.StartInfo.Arguments = titles+" "+ directory;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        string output = UnityWebRequest.UnEscapeURL(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
        output = output.Replace("\r\n", "");
        return output;
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="title">标题名</param>
    /// <param name="defaultName">默认的文件名</param>
    /// <param name="extension">后缀名，例如 txt </param>
    /// <param name="directory">打开的文件位置</param>
    /// <returns></returns>
    public static string SaveFilePanel(string title,  string defaultName, string extension, string directory=null)
    {
        //如果路径为空，则设置路径为桌面路径
        if (string.IsNullOrEmpty(directory))
        {
            directory = defaultPath;
        }
        StringBuilder newExtension = new StringBuilder();
        newExtension.Append(extension).Append("|*.").Append(extension);
        Process p = new Process();
        p.StartInfo.FileName = Application.streamingAssetsPath + "/OpenFilePanel/UnitySaveFilePanel";
        p.StartInfo.Arguments = title+" "+ directory+" "+ defaultName+" "+ newExtension.ToString();
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        //p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("gbk");//Unity不支持gbk
        p.Start();
        string output = UnityWebRequest.UnEscapeURL(p.StandardOutput.ReadToEnd());
        p.WaitForExit();
        p.Close();
        output = output.Replace("\r\n", "");
        return output;
    }

    /// <summary>
    /// 改变网络配置参数
    /// </summary>
    /// <param name="newworkConfig"></param>
    public static void ChangeNetwork(string ip,string subMask,string gateway,string preferredDNS,string standbyDNS)
    {
        StringBuilder args = new StringBuilder();
        args.Append(ip).Append(" ").Append(subMask).Append(" ").Append(gateway).Append(" ").Append(preferredDNS).Append(" ").Append(standbyDNS);
        Process p = new Process();
        p.StartInfo.FileName = Application.streamingAssetsPath + "/Network/Network";
        p.StartInfo.Arguments = args.ToString();
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        p.WaitForExit();
        p.Close();
    }

    /// <summary>
    /// 设置网络为DHCP模式
    /// </summary>
    public static void SetDHCPMode()
    {
        Process p = new Process();
        p.StartInfo.FileName = Application.streamingAssetsPath + "/Network/SetDHCPMode";
        //p.StartInfo.Arguments = null;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        p.WaitForExit();
        p.Close();
    }

    /// <summary>
    /// 分割后缀名
    /// </summary>
    /// <param name="filters"></param>
    /// <returns></returns>
    private static string ExtenSplit(string[] filters)
    {
        StringBuilder filterStr = new StringBuilder();
        for (int i = 0; i < filters.Length; i++)
        {
            if (i % 2 == 0)
            {
                filterStr.Append(filters[i]).Append("|");
            }
            else if (i % 2 == 1)
            {
                string[] splitArray = filters[i].Split(',');
                StringBuilder extens = new StringBuilder();
                if (splitArray.Length > 0)
                {
                    extens.Append("*.").AppendFormat(splitArray[0]);
                    for (int j = 1; j < splitArray.Length; j++)
                    {
                        extens.Append(";*.").Append(splitArray[j]);
                    }
                }
                if (i+1<filters.Length)
                {
                    extens.Append("|");
                }
                filterStr.Append(extens);
            }
        }
        return filterStr.ToString();
    }

   
}
