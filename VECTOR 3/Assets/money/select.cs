using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class select : MonoBehaviour
{
    private float money = 0;

    public Text MoneyText;

    public AudioSource CherrySound;

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.tag == "money")

        {

            money++;

            MoneyText.text = money.ToString();

            Destroy(collision.gameObject);

            

           

        }

    }

   

}
