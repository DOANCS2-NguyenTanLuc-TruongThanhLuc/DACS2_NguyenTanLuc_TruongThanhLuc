using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaoChan : MonoBehaviour
{
    Car Car;

    private void Awake()
    {
        Car=GameObject.FindObjectOfType<Car>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Car.Die(); // Gọi phương thức Die() của đối tượng Car
        }
    }
}
