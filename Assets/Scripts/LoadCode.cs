using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class LoadCode : MonoBehaviour
{
    public GameObject dataObject;
    private Data data;

    TMP_InputField inputField;
    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        data = dataObject.GetComponent<Data>();
    }

    public void Load()
    {
        if (data.DirExists(inputField.text))
        {
            data.gameData.code = inputField.text;
            SceneManager.LoadScene("Game");
        }
        else
        {
            inputField.text = "DOES NOT EXIST!";
        }
    }
}
