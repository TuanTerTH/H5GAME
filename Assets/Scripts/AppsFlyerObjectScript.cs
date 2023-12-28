using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using AppsFlyerSDK;
using System;

public class AppsFlyerObjectScript : MonoBehaviour
{
    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        AppsFlyer.OnRequestResponse += AppsFlyerOnRequestResponse;

        AppsFlyer.OnInAppResponse += (sender, args) =>
        {
            Debug.LogError("response>>>>333");
            var af_args = args as AppsFlyerRequestEventArgs;
            AppsFlyer.AFLog("AppsFlyerOnRequestResponse", " status code " + af_args.statusCode);
        };
        AppsFlyer.setIsDebug(true);
        AppsFlyer.initSDK("aU4RAwZbeA9MrLfAQeYw6R", "");
        Debug.LogError("response>>>>111");
        var id = PlayerPrefs.GetString("CID");
        if (id == null || id == "")
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            id = "" + now.ToUnixTimeMilliseconds();
            PlayerPrefs.SetString("CID", id);
        }
        AppsFlyer.setCustomerUserId(id);
        AppsFlyer.startSDK();
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        eventValues.Add("uid", id);
        //eventValues.Add(AFInAppEvents.REVENUE, "0.99");
        // eventValues.Add("af_quantity", "1");
        AppsFlyer.sendEvent(AFInAppEvents.LOGIN, eventValues);
        Debug.LogError("response>>>>222");
    }
    void AppsFlyerOnRequestResponse(object sender, EventArgs e)
    {
        Debug.LogError("response>>>>4444");
        var args = e as AppsFlyerRequestEventArgs;
        AppsFlyer.AFLog("AppsFlyerOnRequestResponse", " status code " + args.statusCode);
    }
}