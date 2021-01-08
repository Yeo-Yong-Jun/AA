﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Match3
{
    public class M3LevelSelect : MonoBehaviour
    {
        public Sprite levelSleep;
        public Sprite levelNutrition1;
        public Sprite levelNutrition2;
        public Sprite levelImmunisation;
        public Sprite levelExercise;
        public Sprite levelHealthy1;
        public Sprite levelHealthy2;
        public Sprite levelHealthy3;
        public Sprite levelHealthy4;
        public Sprite levelHealthy5;
        public Sprite levelLocked;

        public Font gameFont;
        public int fontSize = 65;

        public GameObject LevelSelectUI;
        public GameObject LevelSelectMenu;
        public GameObject StartUI;

        Button[] totalLevels;

        public int playableLevels;                                                         //number of levels unlocked
        public int playingLevel;                                                           //level currently playing

        HealthManager hm;
        NotificationManager nm;

        public int notification;

        // Start is called before the first frame update
        void Start()
        {
            totalLevels = new Button[transform.childCount];                                    //get total number of levels based on number of buttons

            hm = FindObjectOfType<HealthManager>();
            nm = FindObjectOfType<NotificationManager>();

            if(StartUI.activeSelf == true)
            {
                LevelSelectMenu.SetActive(false);
            }

            playableLevels = Player.m3unlockedlevels;
        }

        // Update is called once per frame
        void Update()
        {
            currentLevels();
            if (EventSystem.current.currentSelectedGameObject.name.Contains("Lvl"))             //check if selected object name contains "Lvl" (for level buttons)
            {
                playingLevel = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text); //set playing level to button text
            }
        }

        void currentLevels()                                                                    //display levels
        {
            for (int i = 0; i < totalLevels.Length; i++)                                        //go through each button
            {
                totalLevels[i] = transform.GetChild(i).GetComponent<Button>();                  //get button

                if (i < playableLevels)                                                         //when level is unlocked
                {
                    if (i < 5)                                                                  //at levels 1-5
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelSleep;               //set button as given image
                    }
                    else if (i < 8)                                                             //at levels 6-8
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelNutrition1;          //set button as given image
                    }
                    else if (i < 10)                                                            //at levels 9-10
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelNutrition2;          //set button as given image
                    }
                    else if (i < 15)                                                            //at levels 11-15
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelImmunisation;        //set button as given image
                    }
                    else if (i < 20)                                                            //at levels 16-20
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelExercise;            //set button as given image
                    }
                    else if (i < 21)                                                            //at level 21
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelHealthy1;            //set button as given image
                    }
                    else if (i < 22)                                                            //at level 22
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelHealthy2;            //set button as given image
                    }
                    else if (i < 23)                                                            //at level 23
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelHealthy3;            //set button as given image
                    }
                    else if (i < 24)                                                            //at level 24
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelHealthy4;            //set button as given image
                    }
                    else if (i < 25)                                                            //at level 24
                    {
                        totalLevels[i].GetComponent<Image>().sprite = levelHealthy5;            //set button as given image
                    }

                    totalLevels[i].interactable = true;                                         //make button interactable
                    totalLevels[i].GetComponentInChildren<Text>().text = (i + 1).ToString();    //change button text to level number
                    totalLevels[i].GetComponentInChildren<Text>().fontSize = fontSize;
                    totalLevels[i].GetComponentInChildren<Text>().font = gameFont;
                }
                else
                {                                                                               //when level is not unlocked
                    totalLevels[i].GetComponent<Image>().sprite = levelLocked;                  //change button image to locked
                    totalLevels[i].interactable = false;                                        //make button not interactable
                    totalLevels[i].GetComponentInChildren<Text>().text = null;                  //change button text to nothing
                }
            }
        }

        public void easyLevel()
        {
            LevelSelectUI.SetActive(false);

            hm.currentHealth = hm.min_healthyHealth;

            Time.timeScale = 1f;
        }

        public void mediumLevel()
        {
            LevelSelectUI.SetActive(false);

            hm.currentHealth = hm.min_betterHealth;

            Time.timeScale = 1f;
        }

        public void difficultLevel()
        {
            LevelSelectUI.SetActive(false);

            hm.currentHealth = hm.min_neutralHealth;

            Time.timeScale = 1f;
        }

        public void restLevel()
        {
            hm.bonusTag = "Sleeping";
            notification = 0;
            nm.isSwitching = false;
        }

        public void foodLevel()
        {
            hm.bonusTag = "Fruit";
            hm.bonusTag1 = "Vegetable";
            notification = 1;
            nm.isSwitching = false;
        }

        public void immunisationLevel()
        {
            hm.bonusTag = "Water";
            notification = 2;
            nm.isSwitching = false;
        }

        public void runningLevel()
        {
            hm.bonusTag = "Running";
            notification = 3;
            nm.isSwitching = false;
        }

        public void healthyLevel()
        {
            hm.bonusTag = "None";
            notification = 4;
            nm.isSwitching = false;
        }
    }
}