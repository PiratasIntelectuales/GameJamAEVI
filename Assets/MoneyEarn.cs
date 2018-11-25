using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEarn : MonoBehaviour
{
    public int CDs_Price;
    public int Movies_Price;

    public int CDs_Quantity = 0;
    public int Movies_Quantity = 0;

    public Text CDs_Total;
    public Text Movies_Total;

    public Text CDs_Quantity_Text;
    public Text Movies_Quantity_Text;

    public GameObject player;
    PlayerManager pManager;

    void Start()
    {
        pManager = player.GetComponent<PlayerManager>();
    }

    void Update()
    {
        SetText();
    }

    void SetText()
    {
        CDs_Total.text = (CDs_Price * CDs_Quantity).ToString();
        Movies_Total.text = (Movies_Price * Movies_Quantity).ToString();

        CDs_Quantity_Text.text = CDs_Quantity.ToString();
        Movies_Quantity_Text.text = Movies_Quantity.ToString();
    }

    public void AddMoneyToBank()
    {
        pManager.AddCash((CDs_Price * CDs_Quantity)+ (Movies_Price * Movies_Quantity));
    }



}
