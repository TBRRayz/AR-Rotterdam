using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointOfInterest : MonoBehaviour
{
    public string POIName;

    private Image image;
    private string url;
    private bool init;
    private Sprite sprite;

    public void toggleImage(bool flag)
    {
        if(flag == true)
        {
            image.sprite = sprite;
        }

        image.enabled = flag;
    }

    public void Start()
    {
        image = GameObject.Find("Image").GetComponent<Image>();
        url = "http://localhost:63342/school/CLE3/backend/?place=" + POIName;

        StartCoroutine(LoadAPIData());
    }

    private IEnumerator LoadAPIData()
    {
        WWW www = new WWW(url);
        yield return www;

        Debug.Log(www.text);
        APIObject result = APIObject.FromJSON(www.text);

        WWW img = new WWW(result.image);
        yield return img;

        if(img.texture != null)
        {
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(img.texture, new Rect(0, 0, img.texture.width, img.texture.height), Vector2.zero);
            this.sprite = sprite;
        }

        yield return null;
    }
}
