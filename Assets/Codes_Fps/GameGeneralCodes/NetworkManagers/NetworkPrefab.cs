using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NetworkPrefab 
{
    public GameObject Prefab;
    public string Path;
    public NetworkPrefab(GameObject obj, string path)
    {
        Prefab = obj;
        Path = RetunPrefabPathModifier(path);
        //Assets / Codes_Fps / Resources / Cube.prefab
    }
    private string RetunPrefabPathModifier(string path)
    {
        int extentsionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");
        if (startIndex == -1)
            return string.Empty;
        else
            return path.Substring(startIndex+additionalLength, path.Length - (additionalLength + startIndex + extentsionLength));

       


    }
}
