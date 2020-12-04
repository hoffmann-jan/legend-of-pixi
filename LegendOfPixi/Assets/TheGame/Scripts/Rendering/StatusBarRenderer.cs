using UnityEngine;
using TMPro;

public class StatusBarRenderer : MonoBehaviour
{
    public TextMeshProUGUI gemLabel;

    private void Update()
    {
        gemLabel.text = SaveGameDataSingleton.instance.inventory.gems.ToString("D3");
    }
}
