using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XLua;

public class ScriptLoader : MonoBehaviour {

    static LuaEnv luaEnv = new LuaEnv();
    public string bundleUrl;
    public string assetName;
    //public GameObject prefab;

    // Use this for initialization
    // 	void Start () {
    //         GameObject prefabObject = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
    //  

    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        //#if UNITY_EDITOR 
#if false
        TextAsset txt = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Resources/HotFixTest.lua.txt", typeof(TextAsset)) as TextAsset;
        luaEnv.DoString(txt.text);
        yield return null;

#else
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        //using (WWW www = new WWW(bundleUrl))
        using (WWW www = WWW.LoadFromCacheOrDownload(bundleUrl, 4))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
            if (assetName == "")
                Instantiate(bundle.mainAsset);
            else
                Instantiate(bundle.LoadAsset(assetName));

            TextAsset txt = bundle.LoadAsset("HotFixTest.lua", typeof(TextAsset)) as TextAsset;
            luaEnv.DoString(txt.text);

            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
#endif
    }
    // Update is called once per frame
    void Update () {
		
	}
}
