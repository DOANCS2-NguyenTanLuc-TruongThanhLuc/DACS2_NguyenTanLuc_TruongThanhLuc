using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLyVaChamCuaXe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            GameManager.Instance.QuaCheckPoint();
        }
        if (other.gameObject.tag == "WinPoint")
        {
            GameManager.Instance.QuaWinPoint();
        }
    }
}
