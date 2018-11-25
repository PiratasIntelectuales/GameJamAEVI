using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEarn : MonoBehaviour
{
    public int basicprice;

    public int CDs_Price;
    public int Movies_Price;
    public int Games_Price;

    public int CDs_Quantity = 0;
    public int Movies_Quantity = 0;
    public int Games_Quantity = 0;

    public float multiplier = 1;

    public Text CDs_Total;
    public Text Movies_Total;
    public Text Games_Total;

    public Text CDs_Quantity_Text;
    public Text Movies_Quantity_Text;
    public Text Games_Quantity_Text;

    public GameObject player;
    PlayerManager pManager;
    
    void Start()
    {
        pManager = player.GetComponent<PlayerManager>();
       
    }
   
    void OnEnable()
    {
        Getnumbers();
    }

    void Update()
    {
        SetText();
    }

    void SetText()
    {
        CDs_Total.text = (CDs_Price * CDs_Quantity * multiplier).ToString();//0
        Movies_Total.text = (Movies_Price* Movies_Quantity* multiplier).ToString();//2
        Games_Total.text = (Games_Price* Games_Quantity * multiplier).ToString();//1

        CDs_Quantity_Text.text = CDs_Quantity.ToString();
        Movies_Quantity_Text.text = Movies_Quantity.ToString();
        Games_Quantity_Text.text = Games_Quantity.ToString();
    }

    public void AddMoneyToBank()
    {
        pManager.AddCash((int)((CDs_Price * CDs_Quantity * multiplier)+ (Movies_Price * Movies_Quantity * multiplier)+ (Games_Price * Games_Quantity * multiplier)));
    }

    void Getnumbers()
    {

        GameObject[] GOs1 = GameObject.FindGameObjectsWithTag("MaxMovies");
        GameObject[] GOs2 = GameObject.FindGameObjectsWithTag("MaxMusic");
        GameObject[] GOs3 = GameObject.FindGameObjectsWithTag("MaxGames");

        Movies_Quantity = GOs1.Length;
       CDs_Quantity = GOs2.Length;
       Games_Quantity = GOs3.Length;

        if(Movies_Quantity>0)
        {
            foreach(GameObject i in GOs1)
            {
                Destroy(i);
            }
        }
        if (CDs_Quantity > 0)
        {
            foreach (GameObject i in GOs2)
            {
                Destroy(i);
            }
        }
        if (Games_Quantity > 0)
        {
            foreach (GameObject i in GOs3)
            {
                Destroy(i);
            }
        }

    }
}
