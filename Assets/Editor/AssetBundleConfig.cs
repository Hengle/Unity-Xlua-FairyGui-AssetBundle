using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AssetBundleConfig
{

    //AssetBundle打包路径
    public static readonly string ASSETBUNDLE_PATH = Application.dataPath + "/AssetBundles/";

    //资源地址
    public static readonly string APPLICATION_PATH = Application.dataPath + "/";

    //工程地址
    public static readonly string PROJECT_PATH = APPLICATION_PATH.Substring(0, APPLICATION_PATH.Length - 7);

    //AssetBundle存放的文件夹名
    public static readonly string ASSETBUNDLE_FILENAM = "AssetBundles";

    //AssetBundle打包的后缀名
    public static readonly string SUFFIX = "";

    //API服务器地址
    public static readonly string SERVERAPI = "";

    // version.txt
    public static readonly string VERSIONFILE = "version.txt";

}
