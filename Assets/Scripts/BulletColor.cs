using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class BulletColor : MonoBehaviour {
    #region Renderer Reference
    Renderer _myRenderer;
    Renderer myRenderer
    {
        get
        {
            if (_myRenderer == null)
            {
                _myRenderer = GetComponent<Renderer>();
            }
            if (_myRenderer == null) Debug.LogError("Renderer Component not found");
            return _myRenderer;
        }
    }
    #endregion


    void Update()
    {
        Material mat = myRenderer.material;
        float emission = Mathf.PingPong(Time.time, 1.0f) +1.9f;
        Color baseColor = Color.white;
        Color finalCOlor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalCOlor);

    }


}
