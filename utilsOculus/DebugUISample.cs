// import Oculus Integration from Asset Store first
// Add CanvasWithDebug prefab to the hierarchy
// if you use imagePrefab, make sure DebugUIBuilder has AddImage method
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class utilsOculus : MonoBehaviour
{
    private bool inMenu;
    private Text sliderText;
    private Image image;
    [SerializeField]
    private Texture2D texture1;
    private Sprite texture1_sprite;
    [SerializeField]
    private Texture2D texture2;
    private Sprite texture2_sprite;
    private int texture_index = 0;
    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        //-- ボタン --//
        //DebugUIBuilder.instance.AddButton("小倉唯", myfunction);
        //-- ラベル --//
        DebugUIBuilder.instance.AddLabel("小倉唯");
        //-- スライダー --//
        // スライダー：最小値・最大値を設定
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("好感度", 1.0f, 815f, SliderPressed, true);
        var textElementInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        //sliderLabel.text = "好感度";
        // スライダーの中身：通常ここを update で変更する
        sliderText = textElementInSlider[1];
        // スライダーの中身，初期値
        sliderText.text = 1.ToString();// sliderPrefab.GetComponentInChildren<Slider>().value.ToString();
        //-- 水平線 --//
        DebugUIBuilder.instance.AddDivider();
        //-- トグル --//
        var togglePrefab = DebugUIBuilder.instance.AddToggle("天使降臨", TogglePressed);
        //-- 画像表示 --//
        // 画像読み込み
        texture1_sprite = Sprite.Create(texture1, new Rect(0, 0, texture1.width, texture1.height), Vector2.zero);
        texture2_sprite = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), Vector2.zero);
        var imagePrefab = DebugUIBuilder.instance.AddImage();
        image = imagePrefab.GetComponentInChildren<Image>();
        //var imageElementInImage = imagePrefab.GetComponentInChildren<Image>();
        image.sprite = texture2_sprite;
        //imageElementInImage.sprite = Sprite.Create(texture1, new Rect(0, 0, texture1.width, texture1.height), Vector2.zero);
        //-- ラジオボタン --//
        DebugUIBuilder.instance.AddRadio("石原夏織", "group", delegate(Toggle t){RadioPressed("石原夏織", "group", t); }, DebugUIBuilder.DEBUG_PANE_CENTER);
        DebugUIBuilder.instance.AddRadio("日高里菜", "group", delegate(Toggle t){RadioPressed("日高里菜", "group", t); }, DebugUIBuilder.DEBUG_PANE_CENTER);
        // 描画
        DebugUIBuilder.instance.Show();
        // UIを表示するかどうか 初期値
        inMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        // UIの表示・非表示切り替え
       if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
       {
           if(inMenu) DebugUIBuilder.instance.Hide();
           else DebugUIBuilder.instance.Show();
           // 状態切り替え
           inMenu = !inMenu;
       } 
    }
    public void TogglePressed(Toggle toggle){
        if(toggle.isOn){
            image.sprite = texture1_sprite;
        }else if(!toggle.isOn){
            image.sprite = texture2_sprite;
        }
    }
    public void RadioPressed(string radioLabel, string group, Toggle t){
         
    }
    public void SliderPressed(float f){
        sliderText.text = f.ToString();
    }
    void myfunction(){
        Debug.Log("hello world");
    }


}
