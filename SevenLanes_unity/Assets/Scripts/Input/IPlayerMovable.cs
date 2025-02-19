using System.Collections;

interface IPlayerMovable
{
    /// <summary>
    /// 方向によってLerpで移動する
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    IEnumerator ChangeLane(float direction);
}
