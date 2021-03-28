using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
    public GameObject score;
    public GameObject waterWarningPrefab;
    public GameObject waterDropPrefab;
    public GameObject history;
    public GameObject historyList;
    public GameObject title;

    private TextMeshProUGUI uGUI;

    private Data data;

    private float roundNumber(float number)
    {
        return Mathf.Round(number * 100) / 100;
    }

    public void ShowWaterWarning(double waitTime)
    {
        GameObject waterWarning = Instantiate(waterWarningPrefab, transform);
        TextMeshProUGUI warningText = waterWarning.GetComponent<TextMeshProUGUI>();

        warningText.text = "You need to wait " + roundNumber((float) waitTime) + " seconds before watering";
    }

    public void ShowMessage(string message)
    {
        GameObject waterWarning = Instantiate(waterWarningPrefab, transform);
        TextMeshProUGUI warningText = waterWarning.GetComponent<TextMeshProUGUI>();

        warningText.text = message;
    }

    public void ShowWaterdrop() {
        GameObject waterDrop = Instantiate(waterDropPrefab, transform);
        SpriteRenderer waterSprite = waterDrop.GetComponent<SpriteRenderer>();

        Destroy(waterDrop, 1.0f);
    }

    private void UpdateHistoryText()
    {
        List<WaterEvent> history = data.plantData.waterHistory;

        int minIndex = Mathf.Max(0, history.Count - 5);

        for(int i = 0; i < 5; i++)
        {
            GameObject textObject = historyList.transform.GetChild(i).gameObject;
            TextMeshProUGUI uGUI = textObject.GetComponent<TextMeshProUGUI>();

            int currIndex = minIndex + i;

            if(currIndex >= history.Count)
            {
                uGUI.text = "";
            } else
            {
                string wateredTime = history[minIndex + i].time.ToString();
                uGUI.text = "Last watered at: " + wateredTime;
            }
        }
    }

    public void ShowHistory()
    {
        history.SetActive(true);
        UpdateHistoryText();
    }

    public void HideHistory()
    {
        history.SetActive(false);
    }

    public void RestartGame()
    {
        data.RestartGame();
    }

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        uGUI = score.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        uGUI.text = data.plantData.waterCount.ToString();

        TextMeshProUGUI titleText = title.GetComponent<TextMeshProUGUI>();
        titleText.text = "Now growing:\n" + data.plantData.name;

    }
}
