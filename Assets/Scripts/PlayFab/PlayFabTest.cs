using UnityEngine;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ServerModels;

public class PlayFabTest : MonoBehaviour {

    public string UserA = "EC12C7A58B77163D";
    //public string TitleIdA = "FD55";
    //public string TitleSecretKeyA = "XARP9R9QSTBJ4MBEG8XRKTZ3EAYRBJGAHFJFGU4E94AT8HISIT";

    public string UserB = "45EB0EDEFDA5BEFB";
    //public string TitleIdB = "CC9D";
    //public string TitleSecretKeyB = "483M4BIQCPX4HII46ZD6ZSG1YJNUQBY15QO6EISP376QINA4GH";

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    //public void ConvertUserAtoUserB()
    //{
    //    GetUserData();
    //}

    [ContextMenu("GetUserData")]
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
                Debug.Log("GetUserData successful");
                if ((result.Data == null) || (result.Data.Count == 0))
                {
                    Debug.Log("No user data available");
                }
                else
                {
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

    [ContextMenu("UpdateUserData")]
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

    private void WriteFile(Dictionary<string, string> data) {
        string link = Application.persistentDataPath + "/DataUser.txt";
        print("link= " + link);
        StreamWriter sw = new StreamWriter(link);
        foreach (var item in data) {
            sw.WriteLine(item.Key);
            sw.WriteLine(item.Value);
        }
        sw.WriteLine("|||");
        sw.WriteLine("|||");
        sw.Close();
    }

    private Dictionary<string, string> ReadFile() {
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
