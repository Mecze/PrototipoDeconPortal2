using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	void Awake()
    {
        MouseController.instance.OnClick += IHAVEBEENCLICKED;
    }

    void IHAVEBEENCLICKED(GameObject obj)
    {
        if (gameObject == obj) SendMessage("OnClick");
    }
}
