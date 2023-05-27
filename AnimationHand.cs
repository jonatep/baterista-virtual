using UnityEngine;
    public class AnimationHand :  MonoBehaviour
    {
    private GameObject target;

    private float normDist;

    private Transform parteCuerpo;

    private float tiltAroundX = -60.0f;

    private float smooth = 20.0f;

    public Transform LookTarget;
    public Transform RotationTarget;


    public void setTargets(GameObject gameTarget, Transform parteCuerpoRecibida)
    {
        parteCuerpo = parteCuerpoRecibida;
        target = gameTarget; 
    }


    public void moveHand(GameObject gameTarget, Transform parteCuerpoRecibida, string directionLook)
    {
        float lookPositionX = 0;

        if (directionLook == "LEFT")
        {
            lookPositionX = (float) -0.211;
        }
        else
        {
            lookPositionX = (float) 0.25;
        }
        Vector3 target_position = gameTarget.transform.position;
        parteCuerpoRecibida.position = target_position;
        Quaternion target_angle = Quaternion.Euler(tiltAroundX, 0, 0);

        Vector3 lookAtPosition = LookTarget.position;
        lookAtPosition.x = lookPositionX;
        LookTarget.position = lookAtPosition;
        lookAtPosition.y = RotationTarget.position.y;
        RotationTarget.position = lookAtPosition;

        parteCuerpoRecibida.rotation = target_angle;
        target = gameTarget;
        parteCuerpo = parteCuerpoRecibida;
    }
    public void LateUpdate()
    {
        normDist = Mathf.Clamp((Vector3.Distance(parteCuerpo.position, target.transform.position) - 0.3f) / 1f, 0, 1);
        parteCuerpo.position = Vector3.Lerp(parteCuerpo.position, target.transform.position, normDist);
        Quaternion target_angle = Quaternion.Euler(0, 0, 0);
        parteCuerpo.rotation = Quaternion.Slerp(parteCuerpo.rotation, target_angle,  Time.deltaTime * smooth);
    }

}
