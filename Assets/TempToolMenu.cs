using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TempToolMenu : PaginatedDisplay
{
    public Image ImageDisplay;
    public List<Sprite> ToolImages;
    
    private List<HelpText> text;

	void Start ()
    {
        text = new List<HelpText>();
        this.Initilize(ref text);
        if (ToolImages != null)
        {
            if(ToolImages.Count > 0)
            {
                foreach(Sprite s in ToolImages)
                {
                    text.Add(new HelpText());
                }
                ImageDisplay.sprite = ToolImages[currentIndex];
            }
        }
        SetPaginationButtonsState(ref text);
    }

    public void NextImage()
    {
        currentIndex++;
    }

    public void PreviousImage()
    {
        currentIndex--;
    }

    public void UpdateImage()
    {
        SetPaginationButtonsState(ref text);
        ImageDisplay.sprite = ToolImages[currentIndex];
    }
}
