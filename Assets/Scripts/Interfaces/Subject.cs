using UnityEngine;
using System.Collections;

public interface Subject 
{
    void UpdateListeners(Object pass);

    void AddListener(Listener list);
}
