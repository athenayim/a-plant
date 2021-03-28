using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plant : MonoBehaviour
{
    private GUIController gui;

    private Data data;
    //Alias
    private PlantData plantData;

    //List of images
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite[] witherSprites;

    private int[] wateringThresholds = { 0, 5, 10, 15};

    public GameObject tmpObject;
    private TextMeshProUGUI text;
    public GameObject restartButton;

    private void UpdateSprite(int waterCount)
    {
        for (int i = 0; i < wateringThresholds.Length; i++)
        {
            if (waterCount >= wateringThresholds[i])
            {
                if (plantData.isWithered)
                {
                    tmpObject.SetActive(true);
                    text.text = "plant is dead :(";
                    spriteRenderer.sprite = witherSprites[i];
                    restartButton.SetActive(true);
                }
                else
                {
                    spriteRenderer.sprite = sprites[i];
                }
            }
        }
    }

    public void Water()
    {
        if (plantData.isWithered) {
            gui.ShowMessage("buy a new plant in the shop.");
            return;
        }
        if (plantData.waterCount >= 15)
        {
            gui.ShowMessage("check out the shop :)");
            data.gameData.currentlyGrowingAPlant = false;
            return;
        }
        DateTime timeNow = DateTime.Now;

        double deltaTime = timeNow.Subtract(plantData.getLastWatered()).TotalSeconds;
        
        if(deltaTime > plantData.maxTimeBetweenWatering && plantData.waterHistory.Count > 1)
        {
            data.gameData.currentlyGrowingAPlant = false;
            plantData.isWithered = true;
            tmpObject.SetActive(true);
            text.text = "plant is dead :(";
            UpdateSprite(plantData.waterCount);
            restartButton.SetActive(true);
        }
        else if (deltaTime > data.gameData.secondsBetweenWatering)
        {
            plantData.waterCount++;
            plantData.waterHistory.Add(new WaterEvent("name:D", timeNow));

            data.gameData.points++;

            Debug.Log("Water count: " + plantData.waterCount);

            gui.ShowWaterdrop();

            UpdateSprite(plantData.waterCount);

            if (plantData.waterCount >= wateringThresholds[wateringThresholds.Length - 1]) // last threshold
            {
                data.gameData.points += 500;
            }
            else
            {
                data.gameData.currentlyGrowingAPlant = true;
            }

        } else
        {
            double waitTime = data.gameData.secondsBetweenWatering - deltaTime;
            Debug.Log("You need to wait " + waitTime + " seconds before watering");

            gui.ShowWaterWarning(waitTime);
        }
    }
    

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        plantData = data.plantData;
        UpdateSprite(plantData.waterCount);

        gui = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GUIController>();
        text = tmpObject.GetComponentInChildren<TextMeshProUGUI>();

        restartButton.SetActive(false);

        Debug.Log("Max time between waters: " + data.plantData.maxTimeBetweenWatering);
    }
}
