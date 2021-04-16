using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PrimaryButton : MonoBehaviour, IPointerDownHandler
{
    public Sprite onClickSprite;

    private Image sourceImage;
    private Sprite originalSprite;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        sourceImage = GetComponent<Image>();
        originalSprite = sourceImage.sprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnPointerDown(PointerEventData data)
    {
        sourceImage.sprite = onClickSprite;
    }

    private void OnClick()
    {
        sourceImage.sprite = originalSprite;
    }
}
