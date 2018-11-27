using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

    private PlayerControllerPlat playerController;

	void Start () {
        playerController = FindObjectOfType<PlayerControllerPlat>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sol"))
        {
            playerController.Grounded();
        }
    }
}
