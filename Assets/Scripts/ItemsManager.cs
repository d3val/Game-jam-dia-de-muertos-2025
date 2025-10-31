using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] List<Collider> items;

    [SerializeField] GameObject flowerCrownUI;
    private TextMeshProUGUI flowerCrownText;
    private int flowerCrownCount;
    [SerializeField] GameObject candlesUI;
    private TextMeshProUGUI candlesText;
    private int candlesCount;
    [SerializeField] GameObject breadUI;
    private TextMeshProUGUI breadText;
    private int breadCount;
    [SerializeField] GameObject flowersUI;
    private TextMeshProUGUI flowersText;
    private int flowersCount;

    private void Start()
    {
        flowerCrownText = flowerCrownUI.GetComponentInChildren<TextMeshProUGUI>();
        candlesText = candlesUI.GetComponentInChildren<TextMeshProUGUI>();
        breadText = breadUI.GetComponentInChildren<TextMeshProUGUI>();
        flowersText = flowersUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void EnableIneractables()
    {
        foreach (var item in items)
        {
            item.enabled = true;
        }
    }

    public void EnableItemsUI()
    {
        flowersUI.SetActive(true);
        flowerCrownUI.SetActive(true);
        candlesUI.SetActive(true);
        breadUI.SetActive(true);
    }

    public void AddCandle()
    {
        if (candlesCount >= 3) return;
        candlesCount++;
        candlesText.SetText(candlesCount + "/3");
        if (candlesCount == 3) candlesText.color = Color.green;
    }

    public void AddFlower()
    {
        if (flowersCount >= 5) return;
        flowersCount++;
        flowersText.SetText(flowersCount + "/5");
        if (flowersCount == 5) flowersText.color = Color.green;
    }
}
