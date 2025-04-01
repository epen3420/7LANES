using UnityEngine;

public class PointerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    public void SideInput(bool isRightSide)
    {
        var iPlayerMovable = player.GetComponent<IPlayerMovable>();
        if (isRightSide)
        {
            StartCoroutine(iPlayerMovable.ChangeLane(1));
        }
        else
        {
            StartCoroutine(iPlayerMovable.ChangeLane(-1));
        }
    }

    public void DrawStartArrow()
    {
        player.GetComponent<PlayerAnimationScript>().StartDrawing();
    }

    public void ShootArrow()
    {
        player.GetComponent<PlayerAnimationScript>().StopDrawing();
        player.GetComponent<EssenceGetScript>().ReleaseRainbowArrow();
    }
}
