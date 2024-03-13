using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openanimationscript : MonoBehaviour
{
    [SerializeField] private GameObject canvse;
    [SerializeField] private GameObject playerCanvse;
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private GameObject Dummy_player;
    void openanimationStarts()
    {
        canvse.SetActive(false);
        playerCanvse.SetActive(false);
        playerMesh.SetActive(false);

    }
    void openanimationClose()
    {
        canvse.SetActive(true);
        playerCanvse.SetActive(true);
        Dummy_player.SetActive(false);
        playerMesh.SetActive(true);

    }
}
