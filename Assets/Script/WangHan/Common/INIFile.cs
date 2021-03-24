using UnityEngine;
using System.Collections;
using System.IO;

public class INIFile
{

    //    private static string FilePath =  Application.dataPath +"//config.ini";Document
	private static string FilePath = Directory.GetCurrentDirectory() + "/Config.ini";

    // 声明INI文件的写操作函数 WritePrivateProfileString()
    [System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    // 声明INI文件的读操作函数 GetPrivateProfileString()
    [System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);


    public static void Write(string path,string section,string key,string value)
    {
        WritePrivateProfileString(section, key, value, path);
    }

    public static void Write(string section, string key, string value)
    {
        // section=配置节，key=键名，value=键值，path=路径
        WritePrivateProfileString(section, key, value, FilePath);
    }

    public static string Read(string path,string section,string key)
    {

        // 每次从ini中读取多少字节
        System.Text.StringBuilder temp = new System.Text.StringBuilder(255);

        // section=配置节，key=键名，temp=上面，path=路径
        GetPrivateProfileString(section, key, "", temp, 255, path);
        return temp.ToString();
    }

    public static string Read(string section, string key)
    {
        // 每次从ini中读取多少字节
        System.Text.StringBuilder temp = new System.Text.StringBuilder(255);

        // section=配置节，key=键名，temp=上面，path=路径
        GetPrivateProfileString(section, key, "", temp, 255, FilePath);

        return temp.ToString();
    }
}
