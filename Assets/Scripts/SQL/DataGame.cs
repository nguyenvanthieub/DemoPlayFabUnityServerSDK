using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Linq;

public class DataGame : MonoBehaviour {

    public static DataGame Instance;

    public const string WordSeparate = "|";
    public const string LineSeparate = "#";

    void Awake()
    {
        Instance = this;
    }

    #region Read Db
    public string GetTableBoss()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Boss ORDER BY id_boss ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_boss = qr.IsNULL("id_boss") ? 0 : qr.GetInteger("id_boss");
            int type = qr.IsNULL("type") ? 0 : qr.GetInteger("type");
            int id_level = qr.IsNULL("id_level") ? 0 : qr.GetInteger("id_level");
            string name_boss = qr.IsNULL("name_boss") ? "0" : qr.GetString("name_boss");
            int blood = qr.IsNULL("blood") ? 0 : qr.GetInteger("blood");
            int resist = qr.IsNULL("resist") ? 0 : qr.GetInteger("resist");
            int special = qr.IsNULL("special") ? 0 : qr.GetInteger("special");
            int move = qr.IsNULL("move") ? 0 : qr.GetInteger("move");
            int blood_special = qr.IsNULL("blood_special") ? 0 : qr.GetInteger("blood_special");
            int num_special = qr.IsNULL("num_special") ? 0 : qr.GetInteger("num_special");
            string img = qr.IsNULL("img") ? "0" : qr.GetString("img");

            string line = id_boss + DataGame.WordSeparate 
                + type + DataGame.WordSeparate 
                + id_level + DataGame.WordSeparate 
                + name_boss + DataGame.WordSeparate 
                + blood + DataGame.WordSeparate 
                + resist + DataGame.WordSeparate 
                + special + DataGame.WordSeparate 
                + move + DataGame.WordSeparate 
                + blood_special + DataGame.WordSeparate 
                + num_special + DataGame.WordSeparate 
                + img + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableBoss: " + lines);
        return lines;
    }

    public string GetTableBossTower()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_BossTower ORDER BY id_boss ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_boss = qr.IsNULL("id_boss") ? 0 : qr.GetInteger("id_boss");
            int type = qr.IsNULL("type") ? 0 : qr.GetInteger("type");
            int id_level = qr.IsNULL("id_level") ? 0 : qr.GetInteger("id_level");
            string name_boss = qr.IsNULL("name_boss") ? "0" : qr.GetString("name_boss");
            int blood = qr.IsNULL("blood") ? 0 : qr.GetInteger("blood");
            int resist = qr.IsNULL("resist") ? 0 : qr.GetInteger("resist");
            int special = qr.IsNULL("special") ? 0 : qr.GetInteger("special");
            int move = qr.IsNULL("move") ? 0 : qr.GetInteger("move");
            int blood_special = qr.IsNULL("blood_special") ? 0 : qr.GetInteger("blood_special");
            int num_special = qr.IsNULL("num_special") ? 0 : qr.GetInteger("num_special");
            string img = qr.IsNULL("img") ? "0" : qr.GetString("img");

            string line = id_boss + DataGame.WordSeparate 
                + type + DataGame.WordSeparate 
                + id_level + DataGame.WordSeparate 
                + name_boss + DataGame.WordSeparate 
                + blood + DataGame.WordSeparate 
                + resist + DataGame.WordSeparate 
                + special + DataGame.WordSeparate 
                + move + DataGame.WordSeparate 
                + blood_special + DataGame.WordSeparate 
                + num_special + DataGame.WordSeparate 
                + img + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableBossTower: " + lines);
        return lines;
    }

    public string GetTableDraw()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Draw ORDER BY id ASC");
        string lines = "";
        while (qr.Step())
        {
            int id = qr.IsNULL("id") ? 0 : qr.GetInteger("id");
            int note = qr.IsNULL("note") ? 0 : qr.GetInteger("note");
            string food_percent = qr.IsNULL("food_percent") ? "0" : qr.GetString("food_percent");
            int food = qr.IsNULL("food") ? 0 : qr.GetInteger("food");
            string soul_percent = qr.IsNULL("soul_percent") ? "0" : qr.GetString("soul_percent");
            int soul = qr.IsNULL("soul") ? 0 : qr.GetInteger("soul");
            string cube_percent = qr.IsNULL("cube_percent") ? "0" : qr.GetString("cube_percent");
            int cube = qr.IsNULL("cube") ? 0 : qr.GetInteger("cube");
            int cube_buy = qr.IsNULL("cube_buy") ? 0 : qr.GetInteger("cube_buy");
            int tile = qr.IsNULL("tile") ? 0 : qr.GetInteger("tile");

            string line = id + DataGame.WordSeparate
                + note + DataGame.WordSeparate
                + food_percent + DataGame.WordSeparate
                + food + DataGame.WordSeparate
                + soul_percent + DataGame.WordSeparate
                + soul + DataGame.WordSeparate
                + cube_percent + DataGame.WordSeparate
                + cube + DataGame.WordSeparate
                + cube_buy + DataGame.WordSeparate
                + tile + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableDraw: " + lines);
        return lines;
    }

    public string GetTableEnergy()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Energy");
        string lines = "";
        while (qr.Step())
        {
            int num_buy = qr.IsNULL("num_buy") ? 0 : qr.GetInteger("num_buy");
            int note = qr.IsNULL("note") ? 0 : qr.GetInteger("note");
            int energy = qr.IsNULL("energy") ? 0 : qr.GetInteger("energy");
            int energy_max = qr.IsNULL("energy_max") ? 0 : qr.GetInteger("energy_max");
            int gold_full = qr.IsNULL("gold_full") ? 0 : qr.GetInteger("gold_full");
            int gold_max = qr.IsNULL("gold_max") ? 0 : qr.GetInteger("gold_max");

            string line = num_buy + DataGame.WordSeparate 
                + note + DataGame.WordSeparate
                + energy + DataGame.WordSeparate
                + energy_max + DataGame.WordSeparate
                + gold_full + DataGame.WordSeparate
                + gold_max + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableEnergy: " + lines);
        return lines;
    }

    public string GetTableHero()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Hero ORDER BY id_hero ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_hero = qr.IsNULL("id_hero") ? 0 : qr.GetInteger("id_hero");
            int chapter = qr.IsNULL("chapter") ? 0 : qr.GetInteger("chapter");
            int map_open = qr.IsNULL("map_open") ? 0 : qr.GetInteger("map_open");
            int map_gift = qr.IsNULL("map_gift") ? 0 : qr.GetInteger("map_gift");
            int type_hero = qr.IsNULL("type_hero") ? 0 : qr.GetInteger("type_hero");
            int id_skill = qr.IsNULL("id_skill") ? 0 : qr.GetInteger("id_skill");
            string name_hero = qr.IsNULL("name_hero") ? "0" : qr.GetString("name_hero");
            string des = qr.IsNULL("des") ? "0" : qr.GetString("des");
            int value = qr.IsNULL("value") ? 0 : qr.GetInteger("value");
            int draw_type = qr.IsNULL("draw_type") ? 0 : qr.GetInteger("draw_type");
            int draw_value = qr.IsNULL("draw_value") ? 0 : qr.GetInteger("draw_value");
            string draw_prent = qr.IsNULL("draw_prent") ? "0" : qr.GetString("draw_prent");

            string line = id_hero + DataGame.WordSeparate
                + chapter + DataGame.WordSeparate
                + map_open + DataGame.WordSeparate
                + map_gift + DataGame.WordSeparate
                + type_hero + DataGame.WordSeparate
                + id_skill + DataGame.WordSeparate
                + name_hero + DataGame.WordSeparate
                + des + DataGame.WordSeparate
                + value + DataGame.WordSeparate
                + draw_type + DataGame.WordSeparate
                + draw_value + DataGame.WordSeparate
                + draw_prent + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableHero: " + lines);
        return lines;
    }

    public string GetTableHeroCastle()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_HeroCastle ORDER BY stt ASC");
        string lines = "";
        while (qr.Step())
        {
            int stt = qr.IsNULL("stt") ? 0 : qr.GetInteger("stt");
            int level_door = qr.IsNULL("level_door") ? 0 : qr.GetInteger("level_door");
            int id_hero = qr.IsNULL("id_hero") ? 0 : qr.GetInteger("id_hero");
            int level = qr.IsNULL("level") ? 0 : qr.GetInteger("level");

            string line = stt + DataGame.WordSeparate
                + level_door + DataGame.WordSeparate
                + id_hero + DataGame.WordSeparate
                + level + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableHeroCastle: " + lines);
        return lines;
    }

    public string GetTableLevel()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Level ORDER BY id_level ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_level = qr.IsNULL("id_level") ? 0 : qr.GetInteger("id_level");
            int chapter = qr.IsNULL("chapter") ? 0 : qr.GetInteger("chapter");
            string name_level = qr.IsNULL("name_level") ? "0" : qr.GetString("name_level");
            string name_image = qr.IsNULL("name_image") ? "0" : qr.GetString("name_image");
            int energy = qr.IsNULL("energy") ? 0 : qr.GetInteger("energy");
            int w_crystal = qr.IsNULL("w_crystal") ? 0 : qr.GetInteger("w_crystal");
            int w_food = qr.IsNULL("w_food") ? 0 : qr.GetInteger("w_food");
            int w_soul = qr.IsNULL("w_soul") ? 0 : qr.GetInteger("w_soul");
            int w_energy = qr.IsNULL("w_energy") ? 0 : qr.GetInteger("w_energy");
            int w_ticket = qr.IsNULL("w_ticket") ? 0 : qr.GetInteger("w_ticket");
            int w_hero = qr.IsNULL("w_hero") ? 0 : qr.GetInteger("w_hero");
            int q_move = qr.IsNULL("q_move") ? 0 : qr.GetInteger("q_move");
            int q_h1 = qr.IsNULL("q_h1") ? 0 : qr.GetInteger("q_h1");
            int q_h2 = qr.IsNULL("q_h2") ? 0 : qr.GetInteger("q_h2");
            int q_h3 = qr.IsNULL("q_h3") ? 0 : qr.GetInteger("q_h3");
            int q_h4 = qr.IsNULL("q_h4") ? 0 : qr.GetInteger("q_h4");
            int q_h5 = qr.IsNULL("q_h5") ? 0 : qr.GetInteger("q_h5");
            int q_box = qr.IsNULL("q_box") ? 0 : qr.GetInteger("q_box");
            int q_boss = qr.IsNULL("q_boss") ? 0 : qr.GetInteger("q_boss");
            int q_food = qr.IsNULL("q_food") ? 0 : qr.GetInteger("q_food");
            int q_soul = qr.IsNULL("q_soul") ? 0 : qr.GetInteger("q_soul");
            int q_ticket = qr.IsNULL("q_ticket") ? 0 : qr.GetInteger("q_ticket");
            int q_crystal = qr.IsNULL("q_crystal") ? 0 : qr.GetInteger("q_crystal");
            int q_hero = qr.IsNULL("q_hero") ? 0 : qr.GetInteger("q_hero");
            int q_bom = qr.IsNULL("q_bom") ? 0 : qr.GetInteger("q_bom");
            int q_moss = qr.IsNULL("q_moss") ? 0 : qr.GetInteger("q_moss");
            string log_win = qr.IsNULL("log_win") ? "0" : qr.GetString("log_win");
            string log_lose = qr.IsNULL("log_lose") ? "0" : qr.GetString("log_lose");

            string line = id_level + DataGame.WordSeparate
                + chapter + DataGame.WordSeparate
                + name_level + DataGame.WordSeparate
                + name_image + DataGame.WordSeparate
                + energy + DataGame.WordSeparate
                + w_crystal + DataGame.WordSeparate
                + w_food + DataGame.WordSeparate
                + w_soul + DataGame.WordSeparate
                + w_energy + DataGame.WordSeparate
                + w_ticket + DataGame.WordSeparate
                + w_hero + DataGame.WordSeparate
                + q_move + DataGame.WordSeparate
                + q_h1 + DataGame.WordSeparate
                + q_h2 + DataGame.WordSeparate
                + q_h3 + DataGame.WordSeparate
                + q_h4 + DataGame.WordSeparate
                + q_h5 + DataGame.WordSeparate
                + q_box + DataGame.WordSeparate
                + q_boss + DataGame.WordSeparate
                + q_food + DataGame.WordSeparate
                + q_soul + DataGame.WordSeparate
                + q_ticket + DataGame.WordSeparate
                + q_crystal + DataGame.WordSeparate
                + q_hero + DataGame.WordSeparate
                + q_bom + DataGame.WordSeparate
                + q_moss + DataGame.WordSeparate
                + log_win + DataGame.WordSeparate
                + log_lose + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableLevel: " + lines);
        return lines;
    }

    public string GetTableLevelTower()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_LevelTower ORDER BY id_level ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_level = qr.IsNULL("id_level") ? 0 : qr.GetInteger("id_level");
            int chapter = qr.IsNULL("chapter") ? 0 : qr.GetInteger("chapter");
            string name_level = qr.IsNULL("name_level") ? "0" : qr.GetString("name_level");
            string name_image = qr.IsNULL("name_image") ? "0" : qr.GetString("name_image");
            int energy = qr.IsNULL("energy") ? 0 : qr.GetInteger("energy");
            int w_crystal = qr.IsNULL("w_crystal") ? 0 : qr.GetInteger("w_crystal");
            int w_food = qr.IsNULL("w_food") ? 0 : qr.GetInteger("w_food");
            int w_soul = qr.IsNULL("w_soul") ? 0 : qr.GetInteger("w_soul");
            int w_energy = qr.IsNULL("w_energy") ? 0 : qr.GetInteger("w_energy");
            int w_ticket = qr.IsNULL("w_ticket") ? 0 : qr.GetInteger("w_ticket");
            int w_hero = qr.IsNULL("w_hero") ? 0 : qr.GetInteger("w_hero");
            int q_move = qr.IsNULL("q_move") ? 0 : qr.GetInteger("q_move");
            int q_h1 = qr.IsNULL("q_h1") ? 0 : qr.GetInteger("q_h1");
            int q_h2 = qr.IsNULL("q_h2") ? 0 : qr.GetInteger("q_h2");
            int q_h3 = qr.IsNULL("q_h3") ? 0 : qr.GetInteger("q_h3");
            int q_h4 = qr.IsNULL("q_h4") ? 0 : qr.GetInteger("q_h4");
            int q_h5 = qr.IsNULL("q_h5") ? 0 : qr.GetInteger("q_h5");
            int q_box = qr.IsNULL("q_box") ? 0 : qr.GetInteger("q_box");
            int q_boss = qr.IsNULL("q_boss") ? 0 : qr.GetInteger("q_boss");
            int q_food = qr.IsNULL("q_food") ? 0 : qr.GetInteger("q_food");
            int q_soul = qr.IsNULL("q_soul") ? 0 : qr.GetInteger("q_soul");
            int q_ticket = qr.IsNULL("q_ticket") ? 0 : qr.GetInteger("q_ticket");
            int q_crystal = qr.IsNULL("q_crystal") ? 0 : qr.GetInteger("q_crystal");
            int q_hero = qr.IsNULL("q_hero") ? 0 : qr.GetInteger("q_hero");
            int q_bom = qr.IsNULL("q_bom") ? 0 : qr.GetInteger("q_bom");
            int q_moss = qr.IsNULL("q_moss") ? 0 : qr.GetInteger("q_moss");
            string log_win = qr.IsNULL("log_win") ? "0" : qr.GetString("log_win");
            string log_lose = qr.IsNULL("log_lose") ? "0" : qr.GetString("log_lose");

            string line = id_level + DataGame.WordSeparate
                + chapter + DataGame.WordSeparate
                + name_level + DataGame.WordSeparate
                + name_image + DataGame.WordSeparate
                + energy + DataGame.WordSeparate
                + w_crystal + DataGame.WordSeparate
                + w_food + DataGame.WordSeparate
                + w_soul + DataGame.WordSeparate
                + w_energy + DataGame.WordSeparate
                + w_ticket + DataGame.WordSeparate
                + w_hero + DataGame.WordSeparate
                + q_move + DataGame.WordSeparate
                + q_h1 + DataGame.WordSeparate
                + q_h2 + DataGame.WordSeparate
                + q_h3 + DataGame.WordSeparate
                + q_h4 + DataGame.WordSeparate
                + q_h5 + DataGame.WordSeparate
                + q_box + DataGame.WordSeparate
                + q_boss + DataGame.WordSeparate
                + q_food + DataGame.WordSeparate
                + q_soul + DataGame.WordSeparate
                + q_ticket + DataGame.WordSeparate
                + q_crystal + DataGame.WordSeparate
                + q_hero + DataGame.WordSeparate
                + q_bom + DataGame.WordSeparate
                + q_moss + DataGame.WordSeparate
                + log_win + DataGame.WordSeparate
                + log_lose + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableLevelTower: " + lines);
        return lines;
    }

    public string GetTableReward()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Reward ORDER BY id ASC");
        string lines = "";
        while (qr.Step())
        {
            int id = qr.IsNULL("id") ? 0 : qr.GetInteger("id");
            int type = qr.IsNULL("type") ? 0 : qr.GetInteger("type");
            int level_map = qr.IsNULL("level_map") ? 0 : qr.GetInteger("level_map");
            int hero = qr.IsNULL("hero") ? 0 : qr.GetInteger("hero");
            int gold = qr.IsNULL("gold") ? 0 : qr.GetInteger("gold");
            int cube = qr.IsNULL("cube") ? 0 : qr.GetInteger("cube");
            int food = qr.IsNULL("food") ? 0 : qr.GetInteger("food");
            int sould = qr.IsNULL("sould") ? 0 : qr.GetInteger("sould");

            string line = id + DataGame.WordSeparate
                + type + DataGame.WordSeparate
                + level_map + DataGame.WordSeparate
                + hero + DataGame.WordSeparate
                + gold + DataGame.WordSeparate
                + cube + DataGame.WordSeparate
                + food + DataGame.WordSeparate
                + sould + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableReward: " + lines);
        return lines;
    }

    public string GetTableSkill()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_Skill ORDER BY id_skill ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_skill = qr.IsNULL("id_skill") ? 0 : qr.GetInteger("id_skill");
            int type_skill = qr.IsNULL("type_skill") ? 0 : qr.GetInteger("type_skill");
            string name_skill = qr.IsNULL("name_skill") ? "0" : qr.GetString("name_skill");
            int level_skill = qr.IsNULL("level_skill") ? 0 : qr.GetInteger("level_skill");
            int num_gem = qr.IsNULL("num_gem") ? 0 : qr.GetInteger("num_gem");
            int dame = qr.IsNULL("dame") ? 0 : qr.GetInteger("dame");
            int range = qr.IsNULL("range") ? 0 : qr.GetInteger("range");
            string des = qr.IsNULL("des") ? "0" : qr.GetString("des");

            string line = id_skill + DataGame.WordSeparate
                + type_skill + DataGame.WordSeparate
                + name_skill + DataGame.WordSeparate
                + level_skill + DataGame.WordSeparate
                + num_gem + DataGame.WordSeparate
                + dame + DataGame.WordSeparate
                + range + DataGame.WordSeparate
                + des + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableSkill: " + lines);
        return lines;
    }

    public string GetTableUnlockHero()
    {
        LoadDatabase("game");
        SQLiteQuery qr = new SQLiteQuery(db, "Select * FROM tbl_UnlockHero ORDER BY id_unlockhero ASC");
        string lines = "";
        while (qr.Step())
        {
            int id_unlockhero = qr.IsNULL("id_unlockhero") ? 0 : qr.GetInteger("id_unlockhero");
            int id_hero = qr.IsNULL("id_hero") ? 0 : qr.GetInteger("id_hero");
            int level_hero = qr.IsNULL("level_hero") ? 0 : qr.GetInteger("level_hero");
            int attack = qr.IsNULL("attack") ? 0 : qr.GetInteger("attack");
            int soul = qr.IsNULL("soul") ? 0 : qr.GetInteger("soul");
            int food = qr.IsNULL("food") ? 0 : qr.GetInteger("food");
            int crystal = qr.IsNULL("crystal") ? 0 : qr.GetInteger("crystal");
            string img = qr.IsNULL("img") ? "0" : qr.GetString("img");

            string line = id_unlockhero + DataGame.WordSeparate
                + id_hero + DataGame.WordSeparate
                + level_hero + DataGame.WordSeparate
                + attack + DataGame.WordSeparate
                + soul + DataGame.WordSeparate
                + food + DataGame.WordSeparate
                + crystal + DataGame.WordSeparate
                + img + DataGame.LineSeparate;
            lines = lines + line;
        }
        qr.Release();
        db.Close();
        print("GetTableUnlockHero: " + lines);
        return lines;
    }
    #endregion

    #region Load Db
    private SQLiteDB db = null;

    private void LoadDatabase(String name)
    {
        db = new SQLiteDB();

        var nameDb = name == "game" ? "DataGame" : "DataUser";

        var filename = Application.persistentDataPath + "/" + nameDb;
        //print("Local: " + filename);

        // check if database already exists.
        if (!File.Exists(filename))
        {
            UnityEngine.Debug.Log("file does not exist");
            // ok , this is first time application start!
            // so lets copy prebuild dtabase from StreamingAssets and load store to persistancePath with Test2
            byte[] bytes = null;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            string dbpath = "file://" + Application.streamingAssetsPath + "/" + nameDb;
            WWW www = new WWW(dbpath);
            StartCoroutine(Download(www));
            bytes = www.bytes;
#elif UNITY_WEBPLAYER
				            string dbpath = "StreamingAssets/" + nameDb;
				            WWW www = new WWW(dbpath);
				            StartCoroutine(Download(www));
				            bytes = www.bytes;
#elif UNITY_IPHONE
				            string dbpath = Application.dataPath + "/Raw/" + nameDb;			
				            try{	
					            using ( FileStream fs = new FileStream(dbpath, FileMode.Open, FileAccess.Read, FileShare.Read) ){
						            bytes = new byte[fs.Length];
						            fs.Read(bytes,0,(int)fs.Length);
					            }			
				            } catch (Exception e){
					
				            }
#elif UNITY_ANDROID
           
				            UnityEngine.Debug.Log("UNITY_ANDROID");	
				            string dbpath = Application.streamingAssetsPath + "/" + nameDb;	 
				            UnityEngine.Debug.Log(dbpath);	
				            WWW www = new WWW(dbpath);
				            StartCoroutine(Download(www));
				            while(!www.isDone){}
				            bytes = www.bytes;
#endif

            if (bytes != null)
            {
                try
                {
                    // copy database to real file into cache folder
                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    // initialize database
                    db.Open(filename);
                }
                catch (Exception e)
                {
                    Debug.Log("ERROR: " + e);
                }
            }
        }
        else
        {
            // it mean we already download prebuild data base and store into persistantPath
            // lest update, I will call Test

            try
            {
                // initialize database
                db.Open(filename);
            }
            catch (Exception e)
            {
                Debug.Log("ERROR: " + e);
            }

        }
    }

    IEnumerator Download(WWW www)
    {
        yield return www;
    }
    #endregion
}
