using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetDataCode : MonoBehaviour
{
    TextMeshProUGUI tmptext;
    Data data;

    void Start()
    {
        tmptext = this.GetComponent<TextMeshProUGUI>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();

        tmptext.text = data.gameData.code;
    }

}
