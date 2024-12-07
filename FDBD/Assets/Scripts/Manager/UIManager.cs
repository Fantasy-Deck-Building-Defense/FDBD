using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

// bgi - back ground image
// btn - button
// txt - text

public class UIManager : MonoBehaviour
{
    [Header("game init ui")]
    [SerializeField] private Image lobby_bgi;   

    [Header("round ui")]
    [SerializeField] private TextMeshProUGUI timer_txt;
    [SerializeField] private TextMeshProUGUI emenyCount_txt;
    [SerializeField] private TextMeshProUGUI gameProcess_txt;

    [Header("game over ui")]
    [SerializeField] private Image Fade_bgi;
    [SerializeField] private Button Restart_btn;

    private void Awake()
    {
        
    }

    public void ProgramInit()
    { 
        
    }

    public void GameInit()
    {
        Fade_bgi.gameObject.SetActive(false);
        Restart_btn.gameObject.SetActive(false);
    }
    public void RoundInit()
    {
        timer_txt.gameObject.SetActive(true);
        emenyCount_txt.gameObject.SetActive(true);
        gameProcess_txt.gameObject.SetActive(true);
    }

    public void UpdateEnemyCount(int count)
    {
        emenyCount_txt.text = count.ToString();
    }

    public void UpdateTimer(float time)
    {
        timer_txt.text = string.Format("{0:N0}", time);
    }

    public void RoundEnd()
    {
        
    }

    public void GameEnd()
    {
        Fade_bgi.gameObject.SetActive(true);
        Restart_btn.gameObject.SetActive(true);
    }
    
}
