using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CardioideScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float travelSpeed = 2;
    [SerializeField] private Axis planeNormal = Axis.Y;
    [SerializeField] private float startAngle = 0;
    [SerializeField] private float escala = 1;
    private float r;
    private float contorno = 0;

    // Start is called before the first frame update
    void Start()
    {
        contorno = Mathf.Deg2Rad * startAngle;
        //contorno = Mathf.Rad2Deg * startAngle;
    }

    // Update is called once per frame
    void Update()
    {
        cardioide();
    }

    /// <summary>
    /// r = a(1 + cos(t))
    /// a = "escala" del cardioide 
    /// t = contorno
    /// </summary>
    void cardioide()
    {
        Vector3 targetLocalVector = target.localPosition;
        targetLocalVector.CartesianToPolarPlanar(planeNormal);
        r = escala * (1 + Mathf.Sin(contorno));

        switch (planeNormal)
        {
            case Axis.X:
                targetLocalVector.Set(targetLocalVector.x, r, contorno);
                break;
            case Axis.Y:
                targetLocalVector.Set(r, targetLocalVector.y, contorno);
                break;
            case Axis.Z:
                targetLocalVector.Set(r, contorno, targetLocalVector.z);
                break;
        }
        targetLocalVector.PolarToCartesianPlanar(planeNormal);
        target.localPosition = targetLocalVector;
        contorno += Time.deltaTime * travelSpeed;
    }
}