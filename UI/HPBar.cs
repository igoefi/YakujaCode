using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Player player;
    private void Update()
    {
        if(player.HP >= 0)
        {
            GetComponent<Image>().fillAmount = 100/player.maxHP*player.HP/100;
        }
    }
}
