using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using PlayFab;
using PlayFab.ServerModels;
using Assets.Scripts.Boss;

public class PlayFabManager : MonoBehaviour {

    #region PlayFab
    [ContextMenu("Send All Data To PlayFab")]
    public void SendAllDataToPlayFab()
    {
        SendDataFromJson();
        SendLevels();
        SendLevelsTower();
        SendDataGame();
    }

    private void SetTitleData(string key, string value)
    {
        var updateRequest = new PlayFab.ServerModels.SetTitleDataRequest();
        updateRequest.Key = key;
        updateRequest.Value = value;
        PlayFabServerAPI.SetTitleData(updateRequest, (result) =>
        {
            Debug.Log("Set titleData successful");
        },
        (error) =>
        {
            Debug.Log("Got error setting titleData:");
            Debug.Log(error.ErrorMessage);
        });
    }
    #endregion

    #region Send Data From Json
    [ContextMenu("Send Data From Json")]
    public void SendDataFromJson()
    {
        string urlInfo = "http://nhadandungaz.com/petvengers/v1.1.1/info.php";
        ConnectionManager.Instance.SynsDataFromServer(urlInfo, GetInfoCallback);
    }

    private void GetInfoCallback(string message) {
        if (message == null || message == "" || message.Length < 10)
        {
            print("Error");
        } else
        {
            var jsonAll = Json.Deserialize(message) as Dictionary<string, object>;

            var jsonInfo = jsonAll["info"] as List<object>;
            if (jsonInfo != null)
            {
                int i = 0;
                foreach (var item in jsonInfo)
                {
                    var dict = item as Dictionary<string, object>;
                    string name = dict["name"] + "";
                    string data = dict["data"] + "";
                    print(++i + "info: " + name + " " + data);
                    SetTitleData(name, data);
                }
            }
        }
    }
    #endregion

    #region Levels.xml
    [ContextMenu("Send Levels.xml")]
    public void SendLevels()
    {
        var xmlFileMap = Resources.Load("Maps/Levels", typeof(TextAsset)) as TextAsset;
        var xmlContent = xmlFileMap.text;
        print("Levels.xml: " + xmlContent);
        SetTitleData("Levels.xml", xmlContent);
    }
    #endregion

    #region LevelsTower.xml
    [ContextMenu("Send LevelsTower.xml")]
    public void SendLevelsTower()
    {
        var xmlFileMap = Resources.Load("Maps/LevelsTower", typeof(TextAsset)) as TextAsset;
        var xmlContent = xmlFileMap.text;
        print("LevelsTower.xml: " + xmlContent);
        SetTitleData("LevelsTower.xml", xmlContent);
    }
    #endregion

    #region DataGame
    [ContextMenu("Send DataGame")]
    public void SendDataGame()
    {
        SetTitleData("TableBoss",DataGame.Instance.GetTableBoss());
        SetTitleData("TableBossTower", DataGame.Instance.GetTableBossTower());
        SetTitleData("TableDraw", DataGame.Instance.GetTableDraw());
        SetTitleData("TableEnergy", DataGame.Instance.GetTableEnergy());
        SetTitleData("TableHero", DataGame.Instance.GetTableHero());
        SetTitleData("TableHeroCastle", DataGame.Instance.GetTableHeroCastle());
        SetTitleData("TableLevel", DataGame.Instance.GetTableLevel());
        SetTitleData("TableLevelTower", DataGame.Instance.GetTableLevelTower());
        SetTitleData("TableReward", DataGame.Instance.GetTableReward());
        SetTitleData("TableSkill", DataGame.Instance.GetTableSkill());
        SetTitleData("TableUnlockHero", DataGame.Instance.GetTableUnlockHero());
    }
    #endregion
}
