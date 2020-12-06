using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBarRenderer : MonoBehaviour
{
    public TextMeshProUGUI gemLabel;

    public Image weaponA_renderer;

    private void Update()
    {
        gemLabel.text = SaveGameDataSingleton.instance.inventory.gems.ToString("D3");
        weaponA_renderer.gameObject.SetActive(SaveGameDataSingleton.instance.inventory.shield);
    }
}
