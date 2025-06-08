using System;
using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class JoinStatesdSubscriber : UnitySubscriber<MessageTypes.Sensor.JointState>
    {
        private bool isMessageReceived = false;
        public GameObject elbow_joint;
        public GameObject shoulder_lift_joint;
        public GameObject shoulder_pan_joint;
        public GameObject wrist_1_joint;
        public GameObject wrist_2_joint;
        public GameObject wrist_3_joint;

        public float elbow_joint_desiredAngle;
        public float shoulder_lift_joint_desiredAngle;
        public float shoulder_pan_joint_desiredAngle;
        public float wrist_1_joint_desiredAngle;
        public float wrist_2_joint_desiredAngle;
        public float wrist_3_joint_desiredAngle;

        protected override void Start()
        {
            base.Start();

        }

        public void Update()
        {

        shoulder_pan_joint.transform.localRotation = Quaternion.Euler(0, -shoulder_pan_joint_desiredAngle, 0);


        shoulder_lift_joint.transform.localRotation = Quaternion.Euler(-shoulder_lift_joint_desiredAngle, 0, -90);


        elbow_joint.transform.localRotation = Quaternion.Euler(0, -elbow_joint_desiredAngle, 0);



        wrist_1_joint.transform.localRotation = Quaternion.Euler(0, -wrist_1_joint_desiredAngle, 0);
        wrist_2_joint.transform.localRotation = Quaternion.Euler(-wrist_2_joint_desiredAngle, 0, -90);
        wrist_3_joint.transform.localRotation = Quaternion.Euler(wrist_3_joint_desiredAngle, 0, 90);


        }

        protected override void ReceiveMessage(JointState jointMessage)
        {

        elbow_joint_desiredAngle = (float)jointMessage.position[0];
        shoulder_lift_joint_desiredAngle = (float)jointMessage.position[1];
        shoulder_pan_joint_desiredAngle = (float)jointMessage.position[2];
        wrist_1_joint_desiredAngle = (float)jointMessage.position[3];
        wrist_2_joint_desiredAngle = (float)jointMessage.position[4];
        wrist_3_joint_desiredAngle = (float)jointMessage.position[5];

        // Convert radians to degrees if necessary (assuming the angle is in radians)
        elbow_joint_desiredAngle *= Mathf.Rad2Deg;
        shoulder_lift_joint_desiredAngle *= Mathf.Rad2Deg;
        shoulder_pan_joint_desiredAngle *= Mathf.Rad2Deg;
        wrist_1_joint_desiredAngle *= Mathf.Rad2Deg;
        wrist_2_joint_desiredAngle *= Mathf.Rad2Deg;
        wrist_3_joint_desiredAngle *= Mathf.Rad2Deg;
        isMessageReceived = true;
        }


    }
}
