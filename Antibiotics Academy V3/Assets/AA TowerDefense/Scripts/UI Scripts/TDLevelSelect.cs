﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TDLevelSelect : MonoBehaviour
    {
        public Sprite PastelLevelAntibiotic;
        public Sprite PastelLevelAb1;
        public Sprite PastelLevelAb2;

        public Sprite ClassicLevelAntibiotic;
        public Sprite ClassicLevelAb1;
        public Sprite ClassicLevelAb2;

        public Sprite BoldLevelAntibiotic;
        public Sprite BoldLevelAb1;
        public Sprite BoldLevelAb2;

        public Sprite levelLocked;

        public Font gameFont;
        public int fontSize = 65;

        public GameObject LevelSelectUI;
        public GameObject tutorialUI;

        public GameObject heart;
        private AudioSource src;

        Button[] totalLevels;

        GameManagerBehavior gMB;

        public GameObject StartUI;
        public GameObject LevelSelectMenu;

        public int playableLevels;                                                             //number of levels unlocked
        public static int levelDifficulty;                                                               //level currently playing

        // Start is called before the first frame update
        void Start()
        {
            gMB = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

            totalLevels = new Button[transform.childCount];                                    //get total number of levels based on number of buttons

            if (StartUI.activeSelf == true)
            {
                LevelSelectMenu.SetActive(false);
            }

            if (Player.tdunlockedlevels < 1)                                                    //set starting level to 1
            {
                Player.tdunlockedlevels = 1;
            }

            playableLevels = Player.tdunlockedlevels;
        }

        // Update is called once per frame
        void Update()
        {
            currentLevels();
        }

        void currentLevels()                                                                   //display levels
        {
            for (int i = 0; i < totalLevels.Length; i++)                                       //go through each button
            {
                totalLevels[i] = transform.GetChild(i).GetComponent<Button>();                 //get button

                if (i < playableLevels)                                                        //when level is unlocked
                {
                    if (i < 4)                                                                 //at levels 1-4
                    {
                        if (PlayerPrefs.GetString("Theme") == "Pastel")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = PastelLevelAntibiotic;      //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Classic")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = ClassicLevelAntibiotic;     //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Bold")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = BoldLevelAntibiotic;        //set button as given image
                        }
                    }
                    else if (i < 7)                                                            //at levels 5-7
                    {
                        if (PlayerPrefs.GetString("Theme") == "Pastel")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = PastelLevelAb1;             //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Classic")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = ClassicLevelAb1;            //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Bold")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = BoldLevelAb1;               //set button as given image
                        }
                    }
                    else if (i < 10)                                                            //at levels 8-10
                    {
                        if (PlayerPrefs.GetString("Theme") == "Pastel")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = PastelLevelAb2;             //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Classic")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = ClassicLevelAb2;            //set button as given image
                        }
                        else if (PlayerPrefs.GetString("Theme") == "Bold")
                        {
                            totalLevels[i].GetComponent<Image>().sprite = BoldLevelAb2;               //set button as given image
                        }
                    }

                    totalLevels[i].interactable = true;                                         //make button interactable
                    totalLevels[i].GetComponentInChildren<Text>().text = (i + 1).ToString();    //change button text to level number
                    totalLevels[i].GetComponentInChildren<Text>().fontSize = fontSize;
                    totalLevels[i].GetComponentInChildren<Text>().font = gameFont;
                }
                else                                                                            //when level is not unlocked
                {
                    totalLevels[i].GetComponent<Image>().sprite = levelLocked;                  //change button image to locked
                    totalLevels[i].interactable = false;                                        //make button not interactable
                    totalLevels[i].GetComponentInChildren<Text>().text = null;                  //change button text to nothing
                }
            }
        }

        public void differentLevel()
        {
            levelDifficulty = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text) - 1; //get level difficulty according to button text(level number)
            gMB.Wave = levelDifficulty; //set difficulty

            LevelSelectUI.SetActive(false);
            tutorialUI.SetActive(false);

            Time.timeScale = 1f;

            src = heart.GetComponent<AudioSource>();
            if (!src.isPlaying)
            {
                src.Play();
            }
        }
    }
}
