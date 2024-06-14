using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpikesnadCoin : MonoBehaviour
{
    public int Mau = 5;
    public int Coin = 0;
    public int Enemy = 0;
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI EnemyText;

    // Start is called before the first frame update
    void Start()
    {
        heartText.SetText(Mau.ToString());
        CoinText.SetText(Coin.ToString());
        heartText.SetText(Enemy.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coin++;
            CoinText.SetText(Coin.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Spikes"))
        {
            Mau--;
            heartText.SetText(Mau.ToString());
        }
        if (collision.CompareTag("Enemy"))
        {
            Mau--;
            heartText.SetText(Mau.ToString());
        }
        
    }
}
