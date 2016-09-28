using UnityEngine;
using System.Collections;
using TestFairyUnity;

/// <summary>
/// For the TestFairy site, which helps track analytics and records video for debugging
/// </summary>
public class TestFairySetupScript : MonoBehaviour
{
	void Start () {
        TestFairy.begin("3605499da10758d7a07f0cf6bd71b298267f2a96");
    }
}
