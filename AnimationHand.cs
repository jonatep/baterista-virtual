using UnityEngine;
    public class AnimationHand :  MonoBehaviour
    {

        private bool raised;

        private GameObject target;

        private float normDist;

        private Transform parteCuerpo;

        private float tiltAroundX = -60.0f;

        private float smooth = 20.0f;

        public void moveHand(GameObject gameTarget, Transform parteCuerpoRecibida)
        {
                Vector3 target_position = gameTarget.transform.position;

                // double firstPosition_y = (double) target_position.y;
                // Vector3 firstPosition = target_position;
                // firstPosition_y += 0.5;
                // firstPosition.y = (float) firstPosition_y;
                parteCuerpoRecibida.position = target_position;
                Quaternion target_angle = Quaternion.Euler(tiltAroundX, 0, 0);
                parteCuerpoRecibida.rotation = target_angle;

                target = gameTarget;
                parteCuerpo = parteCuerpoRecibida;
        }
        public void LateUpdate()
        {
            // if(raised)
            // {

                normDist = Mathf.Clamp((Vector3.Distance(parteCuerpo.position, target.transform.position) - 0.3f) / 1f, 0, 1);
                parteCuerpo.position = Vector3.Lerp(parteCuerpo.position, target.transform.position, normDist);
                Quaternion target_angle = Quaternion.Euler(0, 0, 0);
                parteCuerpo.rotation = Quaternion.Slerp(parteCuerpo.rotation, target_angle,  Time.deltaTime * smooth);
                // print(parteCuerpo.rotation);
                // if(normDist == 1)
                // {
                //     raised = false;
                //     normDist = 0;
                // }
            // }
            // //move step & attraction
            // Step.Translate(Vector3.forward * Time.deltaTime * 0.7f);
            // if (Step.position.z > 1f)
            //     Step.position = Step.position + Vector3.forward * -2f;
            // Attraction.Translate(Vector3.forward * Time.deltaTime * 0.5f);
            // if (Attraction.position.z > 1f)
            //     Attraction.position = Attraction.position + Vector3.forward * -2f;

            // //footsteps
            // for(int i = 0; i < FootTarget.Length; i++)
            // {
            //     var foot = FootTarget[i];
            //     var ray = new Ray(foot.transform.position + Vector3.up * 0.5f, Vector3.down);
            //     var hitInfo = new RaycastHit();
            //     if(Physics.SphereCast(ray, 0.05f, out hitInfo, 0.50f))
            //         foot.position = hitInfo.point + Vector3.up * 0.05f;
            // }

            // //hand and look
            // var normDist = Mathf.Clamp((Vector3.Distance(LookTarget.position, Attraction.position) - 0.3f) / 1f, 0, 1);
            // HandTarget.rotation = Quaternion.Lerp(Quaternion.Euler(90, 0, 0), HandTarget.rotation, normDist);
            // HandTarget.position = Vector3.Lerp(Attraction.position, HandTarget.position, normDist);
            // HandPole.position = Vector3.Lerp(HandTarget.position + Vector3.down * 2, HandTarget.position + Vector3.forward * 2f, normDist);
            // LookTarget.position = Vector3.Lerp(Attraction.position, LookTarget.position, normDist);
            // RightHandTarget.position = Vector3.Lerp(LeftHandTarget.position, RightHandTarget.position, 10);


        }

    }
