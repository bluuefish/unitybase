using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadFromFile : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start ()
	{   //本地下载
	    string path = "File:///D:/unity project/AssetBundleProeject/AssetBundle/scene/cubewall.ab";
        //远程下载
	    string path1 = "http://localhost:51888/AssetBundle/scene/cubewall.ab";
	    string s = "http://www.baidu.com";
        //ab加载
        //AssetBundle ab1 = AssetBundle.LoadFromFile("AssetBundle/mat/share.ab");
        //   AssetBundle ab=AssetBundle.LoadFromFile("AssetBundle/scene/cubewall.ab");


        //第二种ab加载 使用WWW.LoadFromCacheOrDownload(进行本地或远程加载
        //   while (Caching.ready==false)
        //{
        //    yield return null;
        //}
        //   WWW www=WWW.LoadFromCacheOrDownload(path,1);
        //yield return www;
        //if (!string.IsNullOrEmpty(www.error))
        //{
        //    Debug.Log(www.error); yield break;
	    //}
	    //  AssetBundle ab = www.assetBundle;
        //第三种加载 使用Unitywebrequest加载
        UnityWebRequest request=UnityWebRequestAssetBundle.GetAssetBundle(path);
	    yield return request.SendWebRequest();
        //1种
	    AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        //2种
	    AssetBundle ab1 = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

	 
	    GameObject wall = ab.LoadAsset<GameObject>("Cube");
	    Instantiate(wall);

    }
}
