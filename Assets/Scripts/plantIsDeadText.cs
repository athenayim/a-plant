using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plantIsDeadText : MonoBehaviour
{
    TextMeshProUGUI tmptext;

    void Start()
    {
        tmptext = GetComponent<TextMeshProUGUI>();
    }

    public void PlantDied()
    {
        tmptext.text = "plant is dead :(";
    }
}
