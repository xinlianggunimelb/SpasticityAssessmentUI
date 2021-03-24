using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Win32;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class 工具栏选项 
{
   [MenuItem("Tools/项目文档")]
   private static void 打开项目文档()
   {
        string currentDirectory = Directory.GetCurrentDirectory();
        DirectoryInfo currentDir = new DirectoryInfo(currentDirectory);
      StringBuilder dir =new StringBuilder(currentDir.Parent.ToString());
      dir.Append("/R&D");
      if (Directory.Exists(dir.ToString()))
      {
         Process.Start(dir.ToString());
      }
      else
      {
         EditorUtility.DisplayDialog("提示","找不到项目文档文件夹","确定");
      }
   }

   [MenuItem("Tools/打开Git GUI %#g")]
   private static void 打开GitGUI()
   {
      StringBuilder gitPath= new StringBuilder(GetRegistData("InstallPath"));
      gitPath.Append(@"\cmd\git-gui.exe");
      ProcessStartInfo info=new ProcessStartInfo(gitPath.ToString(),"--working-dir \"" + Application.dataPath + "\"");
      Process.Start(info);
   }

   [MenuItem("Tools/打开Git Bash %#h")]
   private static void 打开GitBash()
   {
      StringBuilder gitPath= new StringBuilder(GetRegistData("InstallPath"));
      gitPath.Append(@"\git-bash.exe");
      ProcessStartInfo info=new ProcessStartInfo(gitPath.ToString());
      Process.Start(info);
   }
   

   /// <summary>
   /// 获取注册表数值的方法
   /// </summary>
   /// <param name="name"></param>
   /// <returns></returns>
   private static string GetRegistData(string name)
   {
      RegistryKey hkml = Registry.LocalMachine;
      RegistryKey software = hkml.OpenSubKey("SOFTWARE", false);
      RegistryKey aimdir = software.OpenSubKey("GitForWindows", false);
      string  registData = aimdir.GetValue(name).ToString(); 
      return registData; 
   }

}
