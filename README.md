# README.md

# Unity–ROS Real-Time Interface for NDT Inspection

This project implements a real-time, bidirectional interface between Unity and ROS, designed to visualize and control non-destructive testing (NDT) procedures in an immersive, interactive environment. Built around robotic platforms like the **UR3** and sensors such as **Infrared Thermography (IRT)** and **Ultrasonic Surface Waves (USW)**, this system enables intuitive operation, annotation, and data collection in both simulation and live deployments.

---

## 🎯 Features

- 🔧 Robotic Control: UR3 joint actuation with `FollowJointTrajectoryAction`
- 🧠 Sensor Integration: Live visualization from IRT, GPR, IE, and USW
- 🕶️ VR Interaction: Oculus-based point-and-click via raycast
- ⚙️ Dynamic UI: In-VR sliders and buttons for NDT parameters
- 📡 ROS Bridge: Real-time message flow using ROS#
- 📌 Annotation Tools: Place and publish 3D markers (Vector3/Pose) to ROS

---

## 📼 Demonstration

<div align="center">
<video src="https://github.com/user-attachments/assets/68fa1c74-797d-4ddb-8cf0-2a986e52d123" width="352" height="720"></video>
</div>

---

## 🧭 Repository Structure

unity-ros-ndt-inspection-interface/
├── Assets/                  # Main Unity project
├── Packages/                # ROS# and Unity packages
├── ProjectSettings/         # Unity configuration
├── Demo/                    # Videos and demonstrations
├── Docs/                    # Images, guides, architecture diagrams
├── README.md
└── .gitignore

---

## 🔄 ROS Communication Overview

- `/joint_states` (sub): UR3 joint feedback  
- `/circle_positions` (pub): Selected surface points from user clicks  
- `/camera/image_raw` (sub): NDT visual streams (e.g., IRT or thermal)

Message Types:
- `geometry_msgs/Pose`
- `sensor_msgs/JointState`
- `std_msgs/String`

---

## 🧰 Requirements

- Unity: 2022.3.x LTS  
- ROS: Noetic / Melodic  
- Oculus SDK: via Unity XR Integration  
- ROS#: Modified fork, configured for UR3 and sensor messages

---

## 🚀 Getting Started

1. Clone this repository:
   git clone https://github.com/yourusername/unity-ros-ndt-inspection-interface.git

2. Open in Unity Hub.

3. Launch your ROS master:
   roscore

4. Start the UR3 driver and any sensors:
   roslaunch ur3_bringup.launch

5. Play the Unity scene:
   Assets/Scenes/Main.unity


## 🙌 Acknowledgments

This work was developed as part of a research effort on immersive robotic NDT systems. Special thanks to contributors from Drexel University and collaborators on the ROS–Unity integration framework.
