// === Construction VR Project ===
// ===   READ FROM TEXT FILE   ===


using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.IO;
using Unity.Labs.SuperScience;


public class ObjectManipulation : MonoBehaviour
{
    // An XRNode refers to the input device ie., HMD, controllers, right/left hands, etc.
    [SerializeField] XRNode xrNodeInstance1 = XRNode.Head;
    [SerializeField] CharacterController characterController;
    [SerializeField] GameObject leftHand, rightHand;
    [SerializeField] Transform xrNodeInstance2; // This is an updated way to use XRNode. The newer code in this file uses this variable, the older code uses XRNode.

    Vector3 acceleration;
    Vector3 currentDirection;
    Vector3 gravity = new Vector3(0, -9.8f, 0);
    Vector3 m_LastPosition;

    PhysicsTracker motionData = new PhysicsTracker();
    

    private void Start()
    {   
        // This is everything that is defined at the first frame and never again
        
        // These 3 lines set up the physics tracker (remove them):
        var position = xrNodeInstance2.position;
        motionData.Reset(position, xrNodeInstance2.rotation, Vector3.zero, Vector3.zero);
        m_LastPosition = position;
    }
    
    private void Update()
    {
        // This method runs every frame (so 60fps means this method runs 60 times each second)
        // Debug.Log(forward);
        LogToTextFile(isHMDTiltingForward());
    }



    private float getPitch()
    {
        return getEulerAngles(xrNodeInstance1)[0];
    }

    private float getRoll()
    {
        return getEulerAngles(xrNodeInstance1)[2];
    }

    private void LogToTextFile2d(Vector3 objectToLog)
    {
        File.AppendAllText("C:\\Users\\tova\\Desktop\\output\\output.txt", (startVal).ToString() + ", " + objectToLog[1].ToString() + "\n");
    }

    
    private void LogToTextFile3d(Vector3 objectToLog)
    {
        File.AppendAllText("C:\\Users\\tova\\Desktop\\output\\output.txt", objectToLog[0].ToString() + "," + objectToLog[1].ToString() + "\n");
    }
}
