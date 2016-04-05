using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointOfInterest : MonoBehaviour
{
    public string POIName;

    private GameObject ui;
    private Image _image;
    private Text _title;
    private Text _rating;
    private Text _description;
    private string url;
    private bool init;
    private Sprite sprite;

    private string title;
    private float rating;
    private string description;

    public void toggleImage(bool flag)
    {
        if(flag == true)
        {
            _image.sprite = sprite;
            _title.text = title;
            _rating.text = "Rating: " + rating + " stars";
            _description.text = description;
        }

        ui.SetActive(flag);
    }

    public void Start()
    {
        ui = GameObject.Find("PoIUI");
        _image = ui.transform.Find("Image").GetComponent<Image>();
        _title = ui.transform.Find("Title").GetComponent<Text>();
        _rating = ui.transform.Find("Rating").GetComponent<Text>();
        _description = ui.transform.Find("Description").GetComponent<Text>();
        
        //url = "https://jschooten.com/projects/cle3/?place=" + POIName; //-- Live
        url = "http://localhost:63342/school/AR-Rotterdam/backend/?place=" + POIName; //-- Debug

        StartCoroutine(LoadAPIData());
    }

    private IEnumerator LoadAPIData()
    {
        WWW www = new WWW(url);
        yield return www;

        Debug.Log(www.text);
        APIObject result = APIObject.FromJSON(www.text);

        this.title = result.name;
        this.rating = result.rating;
        this.description = result.wikipedia;

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
