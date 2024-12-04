using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float ThoiGianChoPhepVeDich = 12f;
    public bool KetThucGame = false;
    public bool WinGame = false;
    public static GameManager instance;
    public GameObject GameOverObject;
    public GameObject TimeGameObject;
    public GameObject WinGameObject;
    [SerializeField]
    private float ThoiGianHoiKhiQuaCheckPoint = 13;
   

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject GameManager = new GameObject("GameManager");
                    instance = GameManager.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Update()
    {
        if (!KetThucGame)
        {
            ThoiGianChoPhepVeDich -= Time.deltaTime;
            Debug.Log(ThoiGianChoPhepVeDich);
            if (ThoiGianChoPhepVeDich <= 0)
            {
                TimeGameObject.SetActive(false);
                GameOverObject.SetActive(true); // Hiển thị Game Over khi hết thời gian
                ketThucGame();
            }
        }
        if (WinGame)
        {
            TimeGameObject.SetActive(false);
            WinGameObject.SetActive(true);
        }
        
    }
    public void ketThucGame()
    {
        KetThucGame = true;
        GameOverObject.SetActive(true); // Hiển thị bảng Game Over khi game kết thúc
    }
    public void QuaCheckPoint()
    {
        if (!KetThucGame)
        {
            ThoiGianChoPhepVeDich = ThoiGianHoiKhiQuaCheckPoint;
        }
    }
    public void QuaWinPoint()
    {
        if (!KetThucGame)
        {
            WinGame = true;
        }
    }


}
