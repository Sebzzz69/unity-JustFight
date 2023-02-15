using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public void RespawnPlayer()
    {
        this.gameObject.SetActive(true);
    }
}
