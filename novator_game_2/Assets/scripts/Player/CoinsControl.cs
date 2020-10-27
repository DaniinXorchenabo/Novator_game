using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsControl : MonoBehaviour
{
    private int coins = 0;
    private Text outCoins;

    void Awake()
    {
        outCoins = GameObject.FindWithTag("UIMainCanvas").transform.Find("MainUIWindow/coins/CoinText").gameObject.GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins(int addCoins)
    {
        coins += addCoins;
        outCoins.text = coins.ToString();
    }
}
