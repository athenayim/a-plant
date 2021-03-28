using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToShop : MonoBehaviour
{
    Data data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
    }

    public void OnClickGoShop()
    {
        data.Save(data.gameData.code);
        SceneManager.LoadScene("Plant Shop");
    }
}
