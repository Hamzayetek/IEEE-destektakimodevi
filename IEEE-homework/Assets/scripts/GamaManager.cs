using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamaManager : MonoBehaviour
{
    public PlayerMovement playermovement;
    public CameraMovement cameramovement;
    private bool oyunDevamEdiyor = true;

    [SerializeField] private float finishTime;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text LoseText;
    [SerializeField] private TMP_Text ReplayText;
    [SerializeField] private GameObject TimerScreen;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject ReplayScreen;

    private void Update()
    {
        if (oyunDevamEdiyor == true)
        {
            finishTime -= Time.deltaTime;

            if (finishTime > 0)
            {
                float tam_k�s�m = Mathf.Floor(finishTime);

                timer.SetText("ZAMAN :" + tam_k�s�m);
            }
            if (finishTime < 0)
            {
                oyunDevamEdiyor = false;
            }
           
        }

        if (oyunDevamEdiyor == false)
        {
            LoseScreen.SetActive(true);
            ReplayScreen.SetActive(true);
            TimerScreen.SetActive(false);

            LoseText.SetText("OYUNU KAYBETT�N�Z");
            ReplayText.SetText("TEKRAR DENEY�N");

            if (playermovement != null)
            {
                playermovement.hareketidurdur();
            }



            if (cameramovement != null)
            {
                cameramovement.kameray�durdur();
            }

            if (playermovement != null)
            {
                playermovement.joystickkapa();
            }
        }
    }
}
