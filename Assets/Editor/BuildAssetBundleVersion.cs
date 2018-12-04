using UnityEngine;
using System.Text;
using System;
using System.IO;
using UnityEditor;
using System.Linq;
using System.Security.Cryptography;

public static class BuildAssetBundleVersion
{
    private static string assetPath = string.Empty;
    public static void BuildVersion(string fullName)
    {
        //assetPath = Path.Combine(Application.dataPath + "/../", "AssetBundle");
        assetPath = fullName;
        Caching.ClearCache();

        CreateUpdateTXT();
        AssetDatabase.Refresh();
    }

    // 创建更新文本
    private static void CreateUpdateTXT()
    {
        string[] files = Directory.GetFiles(assetPath, "*.*", SearchOption.AllDirectories);

        StringBuilder stringBuilder = new StringBuilder();
        foreach (string filePath in files)
        {
            string md5 = BuildFileMd5(filePath);

            string fileName = filePath.Substring(filePath.LastIndexOf(AssetBundleConfig.ASSETBUNDLE_FILENAM + "\\") + (AssetBundleConfig.ASSETBUNDLE_FILENAM + "\\").Length);
            stringBuilder.AppendLine(string.Format("{0}:{1}", fileName, md5));
        }

        string updatePath = Path.Combine(assetPath, "update.txt");
        WriteTXT(updatePath, stringBuilder.ToString());
    }

    private static string BuildFileMd5(string filePath)
    {
        string fileMd5 = string.Empty;
        try
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                MD5 md5 = MD5.Create();
                byte[] fileMd5Bytes = md5.ComputeHash(fs);  // 计算FileStream 对象的哈希值
                fileMd5 = System.BitConverter.ToString(fileMd5Bytes).Replace("-", "").ToLower();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex);
        }

        return fileMd5;
    }

    private static void WriteTXT(string path, string content)
    {
        string directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = File.Create(path))
        {
            StreamWriter sw = new StreamWriter(fs, Encoding.ASCII);
            try
            {
                sw.Write(content);

                sw.Close();
                fs.Close();
                fs.Dispose();
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}