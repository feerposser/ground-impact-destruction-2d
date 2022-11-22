using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using GroundImpactDestruction;

public class ClickAndDrop : MonoBehaviour
{
    [SerializeField] GameObject square;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            Instantiate(square, point, Quaternion.identity);
        }
    }
}
