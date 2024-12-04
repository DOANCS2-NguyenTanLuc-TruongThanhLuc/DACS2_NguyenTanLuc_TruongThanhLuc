using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float TocDoXe = 80f; // Tốc độ di chuyển
    [SerializeField]
    private float LucReXe = 120f; // Lực quay
    [SerializeField]
    private float LucPhanh = 100f; // Lực phanh
    private float DauVaoDiChuyen; // Di chuyển lên/xuống (Tiến/Lùi)
    private float DauVaoRe; // Quay xe trái/phải
    private Rigidbody rb;
    bool isAlive = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -1)
        {
            Die();
        }

        // Điều khiển trên máy tính (bàn phím)
        DauVaoDiChuyen = Input.GetAxis("Vertical"); // Lên/xuống (Tiến/Lùi)
        DauVaoRe = Input.GetAxis("Horizontal"); // Trái/phải (Quay)

        // Phanh xe khi nhấn phím Shift trái
        if (DauVaoDiChuyen > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            PhanhXe();
        }

        // Điều khiển trên thiết bị di động (Cảm ứng)

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Điều khiển tiến/lùi (Bên phải màn hình)
            if (touch.position.x > Screen.width / 2) // Chạm ở bên phải màn hình
            {
                if (touch.position.y > Screen.height / 2) // Chạm vào phần trên bên phải
                {
                    DauVaoDiChuyen = 1f; // Di chuyển tiến
                }
                else // Chạm vào phần dưới bên phải
                {
                    DauVaoDiChuyen = -1f; // Di chuyển lùi
                }
            }
            else
            {
                DauVaoDiChuyen = 0f; // Không có chạm trên nửa phải màn hình
            }
        }

        // Điều khiển quay xe trái/phải (Bên trái màn hình)
        if (Input.touchCount > 1)
        {
            Touch touch = Input.GetTouch(1);
            if (touch.position.x < Screen.width / 2) // Chạm ở bên trái màn hình
            {
                if (touch.position.y > Screen.height / 2) // Chạm vào phần trên bên trái
                {
                    DauVaoRe = 1f; // Quay phải
                }
                else // Chạm vào phần dưới bên trái
                {
                    DauVaoRe = -1f; // Quay trái
                }
            }
            else
            {
                DauVaoRe = 0f; // Không có chạm ở nửa trái màn hình
            }
        }

    }

    private void FixedUpdate()
    {
        if (isAlive == false) return;

        DiChuyenXe();
        ReXe();
    }

    public void DiChuyenXe()
    {
        rb.AddRelativeForce(Vector3.forward * DauVaoDiChuyen * TocDoXe);
    }

    public void ReXe()
    {
        Quaternion Re = Quaternion.Euler(Vector3.up * DauVaoRe * LucReXe * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Re);
    }

    public void PhanhXe()
    {
        if (rb.velocity.z != 0)
        {
            rb.AddRelativeForce(-Vector3.forward * LucPhanh);
        }
    }

    public void Die()
    {
        isAlive = false;
        GameManager.Instance.GameOverObject.SetActive(true); // Hiển thị Game Over
        GameManager.Instance.KetThucGame = true; // Kết thúc game
    }

    void GameOver()
    {
        SceneManager.LoadScene("Game");
    }
}
