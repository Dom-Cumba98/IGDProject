using System.Collections;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject player;
    private float followSpeed;
    public float targetDistance;
    public float allowedDistance;
    public RaycastHit shot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = 0.04f;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
            }
        }
    }
}
