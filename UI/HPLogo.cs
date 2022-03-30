using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPLogo : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] Sprite[] HPvariable;
    private void Update()
    {
        if (player.HP <= 0)
        {
            gameObject.GetComponent<Image>().sprite = HPvariable[0];
        }
        else
        {
            if(player.HP <= player.maxHP / 4)
            {
                gameObject.GetComponent<Image>().sprite = HPvariable[1];
            }
            else if (player.HP <= player.maxHP/2)
            {
                gameObject.GetComponent<Image>().sprite = HPvariable[2];
            }
            else if (player.HP <= player.maxHP/4*3)
            {
                gameObject.GetComponent<Image>().sprite = HPvariable[3];
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = HPvariable[4];
            }
        }
    }
}
