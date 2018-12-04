using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle
{
    //[MenuItem("Assets/AssetsBundles/Build Android")]
    //static void BuildAllAssetBundlesAndroid()
    //{
    //    string dir = AssetBundleConfig.ASSETBUNDLE_FILENAM;
    //    if (Directory.Exists(dir))
    //    {
    //        Directory.Delete(dir, true);
    //    }
    //    DirectoryInfo info = Directory.CreateDirectory(dir);
    //    BuildPipeline.BuildAssetBundles(dir,
    //        BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.DeterministicAssetBundle,
    //        BuildTarget.Android
    //    );
    //    BuildAssetBundleVersion.BuildVersion(info.FullName);
    //}

    //[MenuItem("Assets/AssetsBundles/Build IOS")]
    //static void BuildAllAssetBundlesIos()
    //{
    //    string dir = AssetBundleConfig.ASSETBUNDLE_FILENAM;
    //    if (Directory.Exists(dir))
    //    {
    //        Directory.Delete(dir, true);
    //    }
    //    DirectoryInfo info = Directory.CreateDirectory(dir);
    //    BuildPipeline.BuildAssetBundles(dir,
    //         BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.DeterministicAssetBundle,
    //         BuildTarget.iOS
    //    );
    //    BuildAssetBundleVersion.BuildVersion(info.FullName);
    //}

    //[MenuItem("Assets/AssetsBundles/Build Window64")]
    //static void BuildAllAssetBundlesWin64()
    //{
    //    string dir = AssetBundleConfig.ASSETBUNDLE_FILENAM;
    //    if (Directory.Exists(dir))
    //    {
    //        Directory.Delete(dir, true);
    //    }
    //    DirectoryInfo info = Directory.CreateDirectory(dir);
    //    BuildPipeline.BuildAssetBundles(dir,
    //        BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.DeterministicAssetBundle,
    //        BuildTarget.StandaloneWindows64
    //    );
    //    BuildAssetBundleVersion.BuildVersion(info.FullName);
    //}


    [MenuItem("Window/1、Set AssetBundle Name", priority = 2049)]
    static void BuildAutoAssetBundleName()
    {
        //UnityEngine.Object[] SelectedAsset = Selection.GetFiltered(typeof(Object),SelectionMode.Assets | SelectionMode.ExcludePrefab);
        //此处添加需要命名的资源后缀名,注意大小写。
        string[] Filtersuffix = new string[] { ".txt", ".unity", ".prefab", ".jpg", ".png", ".bytes" };

        string[] Excludefolder = new string[] { "xlua", "fairygui", "editor", "plugins" };

        //if (!(SelectedAsset.Length == 1)) return;

        //string fullPath = AssetBundleConfig.PROJECT_PATH + AssetDatabase.GetAssetPath(SelectedAsset[0]);

        string fullPath = AssetBundleConfig.APPLICATION_PATH;

        if (Directory.Exists(fullPath))
        {
            DirectoryInfo dir = new DirectoryInfo(fullPath);

            DirectoryInfo[] folders = dir.GetDirectories();

            for (int j = 0; j < folders.Length; j++)
            {
                DirectoryInfo folder = folders[j];
                //if (!Include(Excludefolder, folder.Name))
                //{
                var files = folder.GetFiles("*", SearchOption.AllDirectories);

                for (var i = 0; i < files.Length; ++i)
                {
                    var fileInfo = files[i];
                    EditorUtility.DisplayProgressBar("设置AssetName名称", "正在设置AssetName名称中...", 1f * i / files.Length);
                    foreach (string suffix in Filtersuffix)
                    {
                        if (fileInfo.Name.EndsWith(suffix))
                        {
                            string path = fileInfo.FullName.Replace('\\',
                            '/').Substring(AssetBundleConfig.PROJECT_PATH.Length);
                            var importer = AssetImporter.GetAtPath(path);
                            if (importer)
                            {
                                string name = path.Substring(fullPath.Substring(
                                AssetBundleConfig.PROJECT_PATH.Length).Length);
                                switch (folder.Name.ToLower())
                                {
                                    case "resources":
                                        {
                                            importer.assetBundleName = name.Substring(0,
                                            name.LastIndexOf('/')) + AssetBundleConfig.SUFFIX;
                                            break;
                                        }
                                    case "lua":
                                    case "scenes":
                                        {
                                            importer.assetBundleName = name.Substring(0,
                                            name.LastIndexOf('.')) + AssetBundleConfig.SUFFIX;
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                //}
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Window/3、Set Version.txt", priority = 2051)]
    static void BuildAssetBundleVersion()
    {
        string[] directorys = Directory.GetDirectories(Path.Combine(AssetBundleConfig.PROJECT_PATH, AssetBundleConfig.ASSETBUNDLE_FILENAM));
        foreach (string path in directorys)
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            StringBuilder stringBuilder = new StringBuilder();
            DirectoryInfo current = new DirectoryInfo(path);
            for (var i = 0; i < files.Length; ++i)
            {
                var filePath = files[i];
                EditorUtility.DisplayProgressBar("设置version.txt的md5", "正在设置" + current.Name + "中...", 1f * i / files.Length);
                string fileMd5 = string.Empty;
                using (FileStream fs = File.OpenRead(filePath))
                {
                    MD5 md5 = MD5.Create();
                    byte[] fileMd5Bytes = md5.ComputeHash(fs);  // 计算FileStream 对象的哈希值
                    fileMd5 = System.BitConverter.ToString(fileMd5Bytes).Replace("-", "").ToLower();
                }
                string fileName = filePath.Substring(filePath.LastIndexOf(AssetBundleConfig.ASSETBUNDLE_FILENAM + "\\") + (current.Name + "\\" + AssetBundleConfig.ASSETBUNDLE_FILENAM + "\\").Length);
                stringBuilder.AppendLine(string.Format("{0}:{1}", fileName, fileMd5));
            }
            string updatePath = Path.Combine(path, AssetBundleConfig.VERSIONFILE);

            if (File.Exists(updatePath))
            {
                File.Delete(updatePath);
            }

            using (FileStream fs = File.Create(updatePath))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.ASCII);
                sw.Write(stringBuilder.ToString());
                sw.Close();
                fs.Close();
                fs.Dispose();
            }
        }
        EditorUtility.ClearProgressBar();
    }

    [MenuItem("Window/4、Clean AssetBundle Name", priority = 2053)]
    static void CleanAutoAssetBundleName()
    {
        //UnityEngine.Object[] SelectedAsset = Selection.GetFiltered(typeof(Object),
        //                        SelectionMode.Assets | SelectionMode.ExcludePrefab);
        //此处添加需要命名的资源后缀名,注意大小写。
        string[] Filtersuffix = new string[] { ".txt", ".unity", ".prefab", ".jpg", ".png", ".bytes" };

        //if (!(SelectedAsset.Length == 1)) return;

        //string fullPath = AssetBundleConfig.PROJECT_PATH + AssetDatabase.GetAssetPath(SelectedAsset[0]);
        string fullPath = AssetBundleConfig.APPLICATION_PATH;

        if (Directory.Exists(fullPath))
        {
            DirectoryInfo dir = new DirectoryInfo(fullPath);

            var files = dir.GetFiles("*", SearchOption.AllDirectories);

            for (var i = 0; i < files.Length; ++i)
            {
                var fileInfo = files[i];
                EditorUtility.DisplayProgressBar("清除AssetName名称",
                "正在清除AssetName名称中...", 1f * i / files.Length);
                foreach (string suffix in Filtersuffix)
                {
                    if (fileInfo.Name.EndsWith(suffix))
                    {
                        string path = fileInfo.FullName.Replace('\\',
                        '/').Substring(AssetBundleConfig.PROJECT_PATH.Length);
                        var importer = AssetImporter.GetAtPath(path);
                        if (importer)
                        {
                            importer.assetBundleName = null;
                        }
                    }
                }
            }
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.RemoveUnusedAssetBundleNames();
    }

    private static bool Include(string[] arr, string txt)
    {
        bool bl = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].ToLower() == txt.ToLower())
            {
                bl = true;
            }
        }
        return bl;
    }
}
