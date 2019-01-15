﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BeatSaberTweaks
{
    [Serializable]
    public class Settings
    {
        static Settings instance = null;

        // Note Hit/Miss and Menu BG Volume
        [SerializeField]
        float noteHitVolume = 1.0f;
        public static float NoteHitVolume { get => instance.noteHitVolume; set => instance.noteHitVolume = value; }

        [SerializeField]
        float noteMissVolume = 1.0f;
        public static float NoteMissVolume { get => instance.noteMissVolume; set => instance.noteMissVolume = value; }

        [SerializeField]
        float menuBGVolume = 1.0f;
        public static float MenuBGVolume { get => instance.menuBGVolume; set => instance.menuBGVolume = value; }

        // In Game Clock
        [SerializeField]
        bool showclock = false;
        public static bool ShowClock { get => instance.showclock; set => instance.showclock = value; }

        [SerializeField]
        bool use24hrClock = false;
        public static bool Use24hrClock { get => instance.use24hrClock; set => instance.use24hrClock = value; }

        [SerializeField]
        float clockFontSize = 4.0f;
        public static float ClockFontSize { get => instance.clockFontSize; set => instance.clockFontSize = value; }

        [SerializeField]
        Vector3 clockPosition = new Vector3(0, 2.4f, 2.4f);
        public static Vector3 ClockPosition { get => instance.clockPosition; set => instance.clockPosition = value; }

        [SerializeField]
        Vector3 clockRotation = new Vector3(0, 0, 0);
        public static Quaternion ClockRotation { get => Quaternion.Euler(instance.clockRotation); set => instance.clockPosition = value.eulerAngles; }

        // Time Spent Clock
        [SerializeField]
        bool showTimeSpentClock = false;
        public static bool ShowTimeSpentClock { get => instance.showTimeSpentClock; set => instance.showTimeSpentClock = value; }

        [SerializeField]
        bool hideTimeSpentClockIngame = true;
        public static bool HideTimeSpentClockIngame { get => instance.hideTimeSpentClockIngame; set => instance.hideTimeSpentClockIngame = value; }

        [SerializeField]
        String timeSpentClockMessageTemplate = "You've spent %TIME% in this session.";
        public static String TimeSpentClockMessageTemplate { get => instance.timeSpentClockMessageTemplate; set => instance.timeSpentClockMessageTemplate = value; }

        [SerializeField]
        float timeSpentClockFontSize = 4.0f;
        public static float TimeSpentClockFontSize { get => instance.timeSpentClockFontSize; set => instance.timeSpentClockFontSize = value; }

        [SerializeField]
        Vector3 timeSpentClockPosition = new Vector3(0, 0.35f, 2.4f);
        public static Vector3 TimeSpentClockPosition { get => instance.timeSpentClockPosition; set => instance.timeSpentClockPosition = value; }

        [SerializeField]
        Vector3 timeSpentClockRotation = new Vector3(0, 0, 0);
        public static Quaternion TimeSpentClockRotation { get => Quaternion.Euler(instance.timeSpentClockRotation); set => instance.timeSpentClockRotation = value.eulerAngles; }

        // Ingame Time Spent Clock
        [SerializeField]
        bool showIngameTimeSpentClock = false;
        public static bool ShowIngameTimeSpentClock { get => instance.showIngameTimeSpentClock; set => instance.showIngameTimeSpentClock = value; }

        [SerializeField]
        bool hideIngameTimeSpentClockIngame = true;
        public static bool HideIngameTimeSpentClockIngame { get => instance.hideIngameTimeSpentClockIngame; set => instance.hideIngameTimeSpentClockIngame = value; }

        [SerializeField]
        float ingameTimeSpentClockFontSize = 4.0f;
        public static float IngameTimeSpentClockFontSize { get => instance.ingameTimeSpentClockFontSize; set => instance.ingameTimeSpentClockFontSize = value; }

        [SerializeField]
        Vector3 ingameTimeSpentClockPosition = new Vector3(0, 0.25f, 2.4f);
        public static Vector3 IngameTimeSpentClockPosition { get => instance.ingameTimeSpentClockPosition; set => instance.ingameTimeSpentClockPosition = value; }

        [SerializeField]
        Vector3 ingameTimeSpentClockRotation = new Vector3(0, 0, 0);
        public static Quaternion IngameTimeSpentClockRotation { get => Quaternion.Euler(instance.ingameTimeSpentClockRotation); set => instance.ingameTimeSpentClockRotation = value.eulerAngles; }

        [SerializeField]
        String ingameTimeSpentClockMessageTemplate = "You've played %TIME% this session.";
        public static String IngameTimeSpentClockMessageTemplate { get => instance.ingameTimeSpentClockMessageTemplate; set => instance.ingameTimeSpentClockMessageTemplate = value; }

        // Move Energy Bar
        [SerializeField]
        bool moveEnergyBar = false;
        public static bool MoveEnergyBar { get => instance.moveEnergyBar; set => instance.moveEnergyBar = value; }

        [SerializeField]
        float energyBarHeight = 3.0f;
        public static float EnergyBarHeight { get => instance.energyBarHeight; set => instance.energyBarHeight = value; }

        // Move Score
        [SerializeField]
        bool moveScore = false;
        public static bool MoveScore { get => instance.moveScore; set => instance.moveScore = value; }

        [SerializeField]
        float scoreSize = 2.0f;
        public static float ScoreSize { get => instance.scoreSize; set => instance.scoreSize = value; }

        [SerializeField]
        Vector3 scorePosition = new Vector3(3.25f, 3.25f, 7.0f);
        public static Vector3 ScorePosition { get => instance.scorePosition; set => instance.scorePosition = value; }

        [SerializeField]
        bool noArrows = false;
        public static bool NoArrows { get => instance.noArrows; set => instance.noArrows = value; }

        [SerializeField]
        bool oneColour = false;
        public static bool OneColour { get => instance.oneColour; set => instance.oneColour = value; }

        [SerializeField]
        bool removeBombs = false;
        public static bool RemoveBombs { get => instance.removeBombs; set => instance.removeBombs = value; }

        [SerializeField]
        bool overrideJumpSpeed = false;
        public static bool OverrideJumpSpeed { get => instance.overrideJumpSpeed; set => instance.overrideJumpSpeed = value; }

        [SerializeField]
        float noteJumpSpeed = 10.0f;
        public static float NoteJumpSpeed { get => instance.noteJumpSpeed; set => instance.noteJumpSpeed = value; }

        public Settings()
        {
            
        }

        public static string SettingsPath()
        {
            return Path.Combine(Environment.CurrentDirectory, "Tweaks.cfg");
        }

        public static void Load()
        {
            instance = new Settings();

            string filePath = SettingsPath();
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                JsonUtility.FromJsonOverwrite(dataAsJson, instance);
            }
        }

        public static void Save()
        {
            string dataAsJson = JsonUtility.ToJson(instance, true);
            File.WriteAllText(SettingsPath(), dataAsJson);
        }
    }
}
