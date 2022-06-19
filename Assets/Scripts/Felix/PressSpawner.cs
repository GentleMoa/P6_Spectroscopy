using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PressSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "PressParent"), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "Blue_Panel"), new Vector3(1.0f, 1.92f, 14f), Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "Purple_Panel"), new Vector3(1.1f, 1.92f, 15f), Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "Orange_Panel"), new Vector3(1.2f, 1.92f, 16f), Quaternion.identity);
    }

}
