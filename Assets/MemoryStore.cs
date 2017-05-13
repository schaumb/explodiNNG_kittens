using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MemoryStore : MonoBehaviour
{

    public GameObject[] Boxes;
    public Material[] Colors;
    public Text winText;
    public Text scoreText;

    public Dictionary<KittyBox, KittyBox> MemoryPairs = new Dictionary<KittyBox, KittyBox>();

    private KittyBox SelectedBox = null;
    private int pairNumber;
    private int foundPairs;

    private Boolean waitingActive = false;

    // Use this for initialization
    void Start()
    {
        GameObject[] RandomizedBoxes = Boxes.OrderBy(box => UnityEngine.Random.Range(0, Boxes.Length)).ToArray();
        pairNumber = RandomizedBoxes.Length / 2;

        for (var i = 0; i < pairNumber; ++i)
        {
            var pairOne = RandomizedBoxes[i].GetComponent<KittyBox>();
            var pairTwo = RandomizedBoxes[i + 8].GetComponent<KittyBox>();

            var insideSpherePairOne = RandomizedBoxes[i].transform.Find("Sphere").gameObject.GetComponent<Renderer>();
            insideSpherePairOne.material = Colors[i];
            var insideSpherePairTwo = RandomizedBoxes[i + 8].transform.Find("Sphere").gameObject.GetComponent<Renderer>();
            insideSpherePairTwo.material = Colors[i];

            MemoryPairs.Add(pairOne, pairTwo);
            MemoryPairs.Add(pairTwo, pairOne);
        }

        winText.gameObject.SetActive(false);
        foundPairs = 0;
        setScoreText();
    }

    internal void OnSelect(KittyBox kittyBox)
    {
        if (!waitingActive)
        {
            kittyBox.select();
            if (SelectedBox == null)
            {
                SelectedBox = kittyBox;
            }
            else
            {
                var pair = this.MemoryPairs[kittyBox];
                if (pair.gameObject.name.Equals(SelectedBox.gameObject.name))
                {
                    // pair
                    StartCoroutine(OnPairFound(kittyBox));
                }
                else
                {
                    // not pair
                    StartCoroutine(DeselectBoxes(kittyBox));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator DeselectBoxes(KittyBox kittyBox)
    {
        waitingActive = true;
        yield return new WaitForSeconds(2);
        waitingActive = false;
        kittyBox.deselect();
        SelectedBox.deselect();
        SelectedBox = null;
    }

    private IEnumerator OnPairFound(KittyBox kittyBox)
    {
        waitingActive = true;
        yield return new WaitForSeconds(1);
        waitingActive = false;
        kittyBox.hide();
        SelectedBox.hide();
        SelectedBox = null;
        foundPairs++;
        setScoreText();
        checkEndOfGame();
    }

    private void setScoreText() {
        scoreText.text = "Pairs found: " + foundPairs.ToString() + "/" + pairNumber.ToString();
    }

    private void checkEndOfGame()
    {
        if (foundPairs == pairNumber)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
