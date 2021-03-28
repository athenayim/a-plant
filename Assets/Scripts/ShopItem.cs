using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public int Price;
    public string Name;
    public Sprite sprite;

    public GameObject imageObject;
    public GameObject nameText;
    public GameObject goldText;

    void Start()
    {
        Image img = imageObject.GetComponent<Image>();
        img.sprite = sprite;

        TextMeshProUGUI name = nameText.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI gold = goldText.GetComponent<TextMeshProUGUI>();

        name.text = Name;
        gold.text = Price.ToString() + "fp";
    }
}
