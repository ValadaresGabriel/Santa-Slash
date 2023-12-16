using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem.UI;
using TranscendenceStudio;

namespace ClothGravity.UI
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI titleText;
        [SerializeField] TextMeshProUGUI descriptionText;
        [SerializeField] TextMeshProUGUI priceText;
        [SerializeField] LayoutElement layoutElement;
        [SerializeField] int descriptionCharacterWrapLimit;
        [SerializeField] RectTransform rectTransform;
        [SerializeField] InputSystemUIInputModule inputModule;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            layoutElement.enabled = NeedsToBeWrapped();
        }

        private void Update()
        {
            Vector2 mousePosition = PlayerInputManager.Instance.GetMousePositionValue();

            // Calculating the horizontal/vertical proportion of the pivot point
            // in relation to the screen width/height
            float pivotX = mousePosition.x / Screen.width;
            float pivotY = mousePosition.y / Screen.height;

            if (pivotX >= 0.75)
            {
                pivotX = 1;
            }
            else
            {
                pivotX = 0;
            }

            if (pivotY >= .4f)
            {
                pivotY = 1;
            }
            else
            {
                pivotY = 0;
            }

            rectTransform.pivot = new Vector2(pivotX, pivotY);
            transform.position = mousePosition;
        }

        public void SetTitleAndDescriptionText(string title, string description, string price)
        {
            titleText.SetText(title);
            descriptionText.SetText(description);

            if (string.IsNullOrEmpty(price))
            {
                priceText.gameObject.SetActive(false);
            }
            else
            {
                priceText.gameObject.SetActive(true);
                priceText.SetText($"Cost: {price}g");
            }
        }

        private bool NeedsToBeWrapped()
        {
            int titleLength = titleText.text.Length;
            int descriptionLength = descriptionText.text.Length;

            if (titleLength > descriptionCharacterWrapLimit || descriptionLength > descriptionCharacterWrapLimit)
            {
                return true;
            }

            return false;
        }
    }
}
