using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image currentEnergy;
    private GameObject player;
    private float energy = 200;
    private float maxEnergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;
    public Text time;
    [SerializeField] GameObject pauseMenu;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = player.GetComponent<playermovement>().speed_lari;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<playermovement>().kecepatan;

        input_x = player.GetComponent<playermovement>().x;

        input_z = player.GetComponent<playermovement>().z;

        EnergyDrain();
        UpdateEnergy();
        UpdateTime();
        ShowPauseMenu();
    }

    private void EnergyDrain()
    {
        if(kecepatan == kecepatanLari)
        {
            if(input_x > 0 || input_z > 0)
            {
                if(energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }                
            }
            else
            {
                if(energy < maxEnergy)
                {
                    energy += 15 * Time.deltaTime;
                }                
            }
        }

    }

    private void UpdateEnergy()
    {
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateTime()
    {
        int hours = EnviroSky.instance.GameTime.Hours;

        int minutes = EnviroSky.instance.GameTime.Minutes;

        string gameHours;
        string gameMinutes;

        if(hours >= 0 && hours <10)
        {
            gameHours = "0" + hours.ToString();
        }
        else
        {
            gameHours = hours.ToString();            
        }

        if(minutes >= 0 && minutes < 10)
        {
            gameMinutes = "0" + minutes.ToString();            
        }
        else
        {
            gameMinutes = minutes.ToString();
        }

        time.text = gameHours + " : " + gameMinutes;
    }

    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameIsPaused = false;

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
