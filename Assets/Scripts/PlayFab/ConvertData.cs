using UnityEngine;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ServerModels;

public class ConvertData : MonoBehaviour
{
    public string UserA = "EC12C7A58B77163D";
    public string UserB = "45EB0EDEFDA5BEFB";

    [ContextMenu("Convert UserA to UserB")]
    public void ConvertUserAtoUserB()
    {
        GetUserData();
    }

    public void GetUserData()
    {
        GetUserDataRequest request = new GetUserDataRequest()
        {
            PlayFabId = UserA,
            Keys = null
        };

        PlayFabServerAPI.GetUserData(
            request,
            (result) =>
            {
                if ((result.Data == null) || (result.Data.Count == 0))
                {
                    Debug.Log("No user data available");
                }
                else
                {
                    Debug.Log("GetUserData successful");
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data = new Dictionary<string, string>();
                    foreach (var item in result.Data)
                    {
                        data.Add(item.Key, item.Value.Value);
                    }
                    UpdateUserData(data);
                }
            },
            (error) =>
            {
                Debug.Log("GetUserData error:");
                Debug.Log(error.ErrorMessage);
            }
        );
    }

    public void UpdateUserData(Dictionary<string, string> data)
    {
        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            PlayFabId = UserB,
            Data = data
        };

        PlayFabServerAPI.UpdateUserData(
            request,
            (result) =>
            {
                Debug.Log("UpdateUserData successful");
            },
            (error) =>
            {
                Debug.Log("UpdateUserData error:");
                Debug.Log(error.ErrorMessage);
            }
        );
    }
}
