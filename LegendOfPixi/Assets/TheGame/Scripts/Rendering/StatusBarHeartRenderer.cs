using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarHeartRenderer : MonoBehaviour
{
    private Image image;

    public int heartNumber = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (SaveGameDataSingleton.instance.health.Current < heartNumber)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
