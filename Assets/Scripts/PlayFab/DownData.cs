using UnityEngine;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ServerModels;

public class DownData : MonoBehaviour
{

    public string UserA = "EC12C7A58B77163D";

    [ContextMenu("Down Data UserA")]
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
                    Debug.Log("Down Data UserA successful");
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data = new Dictionary<string, string>();
                    foreach (var item in result.Data)
                    {
                        //Debug.Log("    " + item.Key + " == " + item.Value.Value);
                        data.Add(item.Key, item.Value.Value);
                    }
                    WriteFile(data);
                }
            },
            (error) =>
            {
                Debug.Log("GetUserData error:");
                Debug.Log(error.ErrorMessage);
            }
        );
    }

    private void WriteFile(Dictionary<string, string> data)
    {
        string link = Application.persistentDataPath + "/DataUser.txt";
        print("link= " + link);
        StreamWriter sw = new StreamWriter(link);
        foreach (var item in data)
        {
            sw.WriteLine(item.Key);
            sw.WriteLine(item.Value);
        }
        sw.WriteLine("|||");
        sw.WriteLine("|||");
        sw.Close();
    }

}
