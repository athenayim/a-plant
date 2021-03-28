using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GetCodeButton : MonoBehaviour
{
    public Button button;
    public GameObject dataObject;
    TextMeshProUGUI textMeshPro;

    private Data data;
        
    System.Random rand = new System.Random();

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        textMeshPro = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        data = dataObject.GetComponent<Data>();
        if(data.gameData.code != null)
        {
            textMeshPro.text = "Continue";
        } 
    }

    public void TaskOnClick()
    {
        if (data.gameData.started)
        {
            return;
        }
        // Generate code
        string code = GenerateCode();
        data.gameData.code = code;

        // Change scenes
        SceneManager.LoadScene("Game");
        data.gameData.started = true;
    }

    string GenerateCode()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string code = new string(Enumerable.Repeat(chars, 6).Select(s => s[rand.Next(s.Length)]).ToArray());
        return code;
    }
}
