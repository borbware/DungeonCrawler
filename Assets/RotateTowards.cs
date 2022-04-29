using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject endPoint;
    float startTime = 0f;
    void Start()
    {
        startPoint.transform.right = transform.right;
        endPoint.transform.right = target.transform.position - transform.position;
    }


    void RotateInstantlyWithTransformRight()
    {
        transform.right =
           target.transform.position - transform.position;
    }
    void RotateSlowlyButBad()
    {
        if (startPoint.transform.rotation != transform.rotation)
            startTime = Time.time;

        transform.rotation = 
            Quaternion.Slerp(
                startPoint.transform.rotation,
                endPoint.transform.rotation,
            (Time.time - startTime) / 10);
    }
    void RotateInstantly()
    {
        Vector3 difference = target.transform.position - transform.position;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void Update()
    {
        Vector3 difference = target.transform.position - transform.position;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        endPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        
    }
}
