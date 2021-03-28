using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plantShop : MonoBehaviour
{
    public GameObject Gold;
    private TextMeshProUGUI goldText;

    Data data;

    int currentpoints;

    void Start()
    {
        goldText = Gold.GetComponent<TextMeshProUGUI>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();

        currentpoints = data.gameData.points;
        goldText.text = currentpoints.ToString() + "fp";
    }

    private void UpdatePoints(int points)
    {
        currentpoints = points;
        data.gameData.points = currentpoints;
        goldText.text = currentpoints.ToString() + "fp";
    }

    public void Buy(int price, string name)
    {
        if(currentpoints < price)
        {
            Debug.Log("you dont have enough money...");
            return;
        }
        
        UpdatePoints(currentpoints - price);
        data.plantData.name = name;
    }
}
