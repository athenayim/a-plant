using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopItem : MonoBehaviour
{
    public int Price;
    public string Name;
    public Sprite sprite;

    public GameObject imageObject;
    public GameObject nameText;
    public GameObject goldText;
    public GameObject ShopObject;
    private plantShop shop;

    private Data data;

    void Start()
    {
        Image img = imageObject.GetComponent<Image>();
        img.sprite = sprite;

        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();

        TextMeshProUGUI name = nameText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI gold = goldText.GetComponent<TextMeshProUGUI>();
        shop = ShopObject.GetComponent<plantShop>();

        name.text = Name;
        gold.text = Price.ToString() + "fp";
    }

    public void Onclick()
    {
        if(data.gameData.currentlyGrowingAPlant) { return; }
        shop.Buy(Price, Name);
        data.RestartGame();
        SceneManager.LoadScene("Game");
    }
}
