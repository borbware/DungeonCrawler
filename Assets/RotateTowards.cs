using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject startPoint;
    void Start()
    {
        startPoint.transform.right = transform.right;
        //startPoint.transform.right = 
        //    target.transform.position - transform.position;
    }

    void Update()
    {

        transform.rotation = 
            Quaternion.RotateTowards(
                startPoint.transform.rotation,
                target.transform.rotation,
                60 * Time.deltaTime);
    }
}
