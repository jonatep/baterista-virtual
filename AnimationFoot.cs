using UnityEngine;
    public class AnimationFoot :  MonoBehaviour
    {
    private GameObject target;

    private float normDist;

    private Transform parteCuerpo;

    private float tiltAroundX = -60.0f;

    private float smooth = 20.0f;
    public void setTargets(GameObject gameTarget, Transform parteCuerpoRecibida)
    {
        parteCuerpo = parteCuerpoRecibida;
        target = gameTarget; 
    }
    public void moveFoot(GameObject gameTarget, Transform parteCuerpoRecibida)
    {
        Vector3 target_position = gameTarget.transform.position;
        parteCuerpoRecibida.position = target_position;
        Quaternion target_angle = Quaternion.Euler(tiltAroundX, 0, 0);
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
