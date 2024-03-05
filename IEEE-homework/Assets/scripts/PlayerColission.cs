using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerMovement playermovement;
    public CameraMovement cameramovement;
    [SerializeField] private GameObject TimerScreen;

    [SerializeField] private GameObject Winscreen;
    [SerializeField] TMP_Text WinText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish"))
        {
            WinText.SetText("TEBRÝKLER KAZANDINIZ");
            Winscreen.SetActive(true);
            TimerScreen.SetActive(false);

            if (playermovement != null)
            {
                playermovement.hareketidurdur();
            }



            if (cameramovement != null)
            {
                cameramovement.kamerayýdurdur();
            }
            
            if(playermovement != null)
            {
                playermovement.joystickkapa();
            }

        }
    }
}
