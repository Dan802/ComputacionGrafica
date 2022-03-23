using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Doblehelice1 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    [SerializeField] private float travelSpeed = 2.0f;
    [SerializeField] private Axis planeNormal = Axis.Y;
    [SerializeField] private float startAngle = 0;
    [SerializeField] private float radio = 2;
    [SerializeField] private float height = 0.7f;
    private float angulo = 0;
    
    private TrailRenderer target1_tail;
    private TrailRenderer target2_tail;
    [SerializeField] private float tail_Lifetime = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        //contorno = Mathf.Deg2Rad * startAngle;
        angulo = Mathf.Rad2Deg * startAngle;

        target1_tail = target.GetComponent<TrailRenderer>();
        target2_tail = target.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Doblehelice();
        tailRender();
    }

    void Doblehelice()
    {
        Vector3 targetLocalVector = target.localPosition;
        targetLocalVector.CartesianToPolarPlanar(planeNormal);

        switch (planeNormal)
        {
            case Axis.X:
                targetLocalVector.x = targetLocalVector.x + Time.deltaTime * height;
                targetLocalVector.Set(targetLocalVector.x, radio, angulo);
                break;
            case Axis.Y:
                targetLocalVector.y = targetLocalVector.y + Time.deltaTime * height;
                targetLocalVector.Set(radio, targetLocalVector.y, angulo);
                break;
            case Axis.Z:
                targetLocalVector.z = targetLocalVector.z + Time.deltaTime * height;
                targetLocalVector.Set(radio, angulo, targetLocalVector.z);
                break;
        }
        targetLocalVector.PolarToCartesianPlanar(planeNormal);
        target.localPosition = targetLocalVector;
        angulo += Time.deltaTime * travelSpeed;

        //Target 2
        Vector3 target2LocalVector = target2.localPosition;
        target2LocalVector.CartesianToPolarPlanar(planeNormal);

        switch (planeNormal)
        {
            case Axis.X:
                target2LocalVector.Set(targetLocalVector.x, -radio, angulo);
                break;
            case Axis.Y:
                target2LocalVector.Set(-radio, targetLocalVector.y, angulo);
                break;
            case Axis.Z:
                target2LocalVector.Set(-radio, angulo, targetLocalVector.z);
                break;
        }
        target2LocalVector.PolarToCartesianPlanar(planeNormal);
        target2.localPosition = target2LocalVector;
        angulo += Time.deltaTime * travelSpeed;
    }

    void tailRender ()
    {
        target1_tail.time = tail_Lifetime;
        target2_tail.time = tail_Lifetime;
    }
}