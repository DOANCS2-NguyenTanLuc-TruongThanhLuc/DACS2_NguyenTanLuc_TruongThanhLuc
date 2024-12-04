using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Update()
    {
        HienThiThoiGianGame();
    }
    public void HienThiThoiGianGame()
    {
        timeText.SetText(Mathf.FloorToInt(GameManager.Instance.ThoiGianChoPhepVeDich).ToString());
    }
    public void ChoiLai()
    {
        SceneManager.LoadScene("Game"); // Tải lại scene
        GameManager.Instance.GameOverObject.SetActive(false); // Ẩn bảng Game Over
    }
    public void TroLaiMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
