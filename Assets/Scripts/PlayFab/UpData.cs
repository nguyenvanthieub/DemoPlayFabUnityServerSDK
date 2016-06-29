using UnityEngine;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ServerModels;

public class UpData : MonoBehaviour
{
    public string UserB = "45EB0EDEFDA5BEFB";

    [ContextMenu("Up Data UserB")]
    public void UpdateUserData()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data = ReadFile();
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

    private Dictionary<string, string> ReadFile()
    {
        string link = Application.persistentDataPath + "/DataUser.txt";
        print("link= " + link);
        StreamReader sr = new StreamReader(link);
        string line1 = "";
        string line2 = "";
        Dictionary<string, string> data = new Dictionary<string, string>();
        while (line1 != "|||")
        {
            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            if (line1 != "|||")
                data.Add(line1, line2);
        }
        sr.Close();
        return data;
    }
}
