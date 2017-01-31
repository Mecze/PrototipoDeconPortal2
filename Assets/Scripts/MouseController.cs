using UnityEngine;
using System.Collections;
using System.Linq;

public class MouseController : Singleton<MouseController> {
    #region Event Click
    public delegate void MouseClickEventHandler(GameObject obj);
    MouseClickEventHandler _OnClick;
    public event MouseClickEventHandler OnClick
    {
        add
        {
            if (_OnClick == null || !_OnClick.GetInvocationList().Contains(value))
            {
                _OnClick += value;
            }

        }
        remove
        {
            _OnClick -= value;
        }
    }
    #endregion

    [SerializeField]
    LayerMask OnClickLayer;


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit, OnClickLayer)){
                if (_OnClick != null) _OnClick(hit.collider.gameObject);
            }

        }
    }
	
}
