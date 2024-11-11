using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Camerafollow cameraFollow;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private movimiento Jugador;
    public float MirarlejosMult = .5f;

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    private void Awake()
    {
        cameraFollow.Setup(GetCameraFollowPosition);
    }

    private Vector3 GetCameraFollowPosition()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 playerToMouseDir = mousePosition - Jugador.GetPosition();
        return Jugador.GetPosition() + playerToMouseDir * MirarlejosMult;
    }

}
