using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    Data data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
    }

    public void OnClickReturnMenu()
    {
        data.Save(data.gameData.code);
        SceneManager.LoadScene("Menu");
    }
}
