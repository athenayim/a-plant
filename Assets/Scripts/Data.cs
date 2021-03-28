using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class WaterEvent
{
    public string name;
    public DateTime time;

    public WaterEvent(string name, DateTime time)
    {
        this.name = name;
        this.time = time;
    }
}

public class GardenData
{
    public List<PlantData> allPlants;
}

public class GameData
{
    public string code;
    public bool started;

    public int points = 500;
    public bool currentlyGrowingAPlant;
    // Per person
    public int secondsBetweenWatering = 2;
}

public class PlantData
{
    public bool isWithered = false;
    public int waterCount;
    public List<WaterEvent> waterHistory = new List<WaterEvent>();
    public string name = "Sprout";

    // In seconds
    //public double maxTimeBetweenWatering = 4 * 60 * 60;
    public double maxTimeBetweenWatering = 5.0;

    public PlantData(int waterCount, double deltaTime, List<WaterEvent> waterHistory)
    {
        this.waterCount = waterCount;
        this.maxTimeBetweenWatering = deltaTime;
        this.waterHistory = waterHistory;
    }

    public PlantData(double deltaTime)
    {
        this.waterCount = 0;
        this.maxTimeBetweenWatering = deltaTime;
        this.waterHistory = new List<WaterEvent>();
    }

    public PlantData()
    {
        this.waterCount = 0;
        this.waterHistory = new List<WaterEvent>();
    }

    public DateTime getLastWatered()
    {
        if(waterHistory.Count > 0)
        {
            return waterHistory[waterHistory.Count - 1].time;
        } else
        {
            return DateTime.MinValue;
        }
    }

}

public class Data : MonoBehaviour
{
    public GameData gameData;
    public PlantData plantData;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        // INITIALISE GAME DATA
        gameData = new GameData();
        plantData = new PlantData();
    }
    

    private void WriteFile(string path, string text)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(text);
        }
    }

    public void Save(string code)
    {
        string saveGameDataPath = Application.persistentDataPath + $"\\{code}\\gameData.json";
        string savePlantDataPath = Application.persistentDataPath + $"\\{code}\\plantData.json";

        string jsonGameData = JsonUtility.ToJson(gameData);
        string jsonPlantData = JsonUtility.ToJson(plantData);

        Directory.CreateDirectory(Application.persistentDataPath + $"\\{code}");

        WriteFile(saveGameDataPath, jsonGameData);
        WriteFile(savePlantDataPath, jsonPlantData);
    }

    public void Load(string code)
    {
        string saveGameDataPath = Application.persistentDataPath + $"\\{code}\\gameData.json";
        string savePlantDataPath = Application.persistentDataPath + $"\\{code}\\plantData.json";

        GameData loadedGameData = JsonUtility.FromJson<GameData>(File.ReadAllText(saveGameDataPath));
        PlantData loadedPlantData = JsonUtility.FromJson<PlantData>(File.ReadAllText(savePlantDataPath));

        gameData = loadedGameData;
        plantData = loadedPlantData;
    }

    public bool DirExists(string code)
    {
        string path = Application.persistentDataPath + $"\\{code}";
        return Directory.Exists(path) ? true : false;
    }

    public void RestartGame()
    {
        plantData.isWithered = false;
        plantData.waterCount = 0;
        plantData.waterHistory = new List<WaterEvent>();
        gameData.currentlyGrowingAPlant = true;
    }

}

