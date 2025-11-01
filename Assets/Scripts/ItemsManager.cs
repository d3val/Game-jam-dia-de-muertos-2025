using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance;
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
    [SerializeField] GameObject keyUI;
    private Image keyIcon;
    public bool holdingKey = false;

    private int itemsCollected = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        flowerCrownText = flowerCrownUI.GetComponentInChildren<TextMeshProUGUI>();
        candlesText = candlesUI.GetComponentInChildren<TextMeshProUGUI>();
        breadText = breadUI.GetComponentInChildren<TextMeshProUGUI>();
        flowersText = flowersUI.GetComponentInChildren<TextMeshProUGUI>();
        keyIcon = keyUI.GetComponentInChildren<Image>();
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
        keyUI.SetActive(true);
    }

    public void AddCandle()
    {
        if (candlesCount >= 3) return;
        candlesCount++;
        candlesText.SetText(candlesCount + "/3");
        if (candlesCount == 3)
        {
            itemsCollected++;
            candlesText.color = Color.green;
        }
    }

    public void AddFlower()
    {
        if (flowersCount >= 5) return;
        flowersCount++;
        flowersText.SetText(flowersCount + "/5");
        if (flowersCount == 5)
        {
            itemsCollected++;
            flowersText.color = Color.green;
        }
    }

    public void AddBread()
    {
        if (breadCount >= 4) return;
        breadCount++;
        breadText.SetText(breadCount + "/4");
        if (breadCount == 4)
        {
            itemsCollected++;
            breadText.color = Color.green;
        }
    }

    public void AddCrown()
    {
        if (flowerCrownCount >= 1) return;
        flowerCrownCount++;
        flowerCrownText.SetText(flowerCrownCount + "/1");
        if (flowerCrownCount == 1)
        {
            itemsCollected++;
            flowerCrownText.color = Color.green;
        }
    }

    public void GetKey()
    {
        keyIcon.color = Color.white;
        holdingKey = true;
    }

    public bool CheckItems() => itemsCollected == 4 ? true : false;
}
