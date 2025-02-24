using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransParentImage
{
    public IEnumerator HideImage(Image img)
    {
        while (img.color.a > 0)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
