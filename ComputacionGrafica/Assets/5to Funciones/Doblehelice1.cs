using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CardioideScript1 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float travelSpeed = 2;
    [SerializeField] private Axis planeNormal = Axis.Y;
    [SerializeField] private float startAngle = 0;
    [SerializeField] private float radio = 2;
    [SerializeField] private float altura = 0.1f;
    private float contorno = 0;

    // Start is called before the first frame update
    void Start()
    {
        //contorno = Mathf.Deg2Rad * startAngle;
        contorno = Mathf.Rad2Deg * startAngle;
    }

    // Update is called once per frame
    void Update()
    {
        Doblehelice();
    }

    void Doblehelice()
    {
        Vector3 targetLocalVector = target.localPosition;
        targetLocalVector.CartesianToPolarPlanar(planeNormal);

        switch (planeNormal)
        {
            case Axis.X:
                targetLocalVector.x = targetLocalVector.x + Time.deltaTime * altura;
                targetLocalVector.Set(targetLocalVector.x, radio, contorno);
                break;
            case Axis.Y:
                targetLocalVector.y = targetLocalVector.y + Time.deltaTime * altura;
                targetLocalVector.Set(radio, targetLocalVector.y, contorno);
                break;
            case Axis.Z:
                targetLocalVector.z = targetLocalVector.z + Time.deltaTime * altura;
                targetLocalVector.Set(radio, contorno, targetLocalVector.z);
                break;
        }
        targetLocalVector.PolarToCartesianPlanar(planeNormal);
        target.localPosition = targetLocalVector;
        contorno += Time.deltaTime * travelSpeed;
    }
}