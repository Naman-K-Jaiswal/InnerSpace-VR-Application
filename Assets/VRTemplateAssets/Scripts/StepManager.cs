using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;
        public GameObject dropdownGameObject;
        private TMP_Dropdown myDropdown;

        public AudioSource AudioSourceOverwhelmedPravachan;
        public AudioSource AudioSourceRestlessPravachan;
        public AudioSource AudioSourceTensedPravachan;
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();

        int m_CurrentStepIndex = 0;

        void Start()
        {
            myDropdown = dropdownGameObject.GetComponent<TMP_Dropdown>();

            if (myDropdown == null)
            {
                Debug.LogError("No Dropdown component found on the provided GameObject.");
                return;
            }
            timerText.gameObject.SetActive(false);
        }
        void Update()
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
            if (remainingTime < 0) {
                timerText.gameObject.SetActive(false);
                AudioSourceOverwhelmedPravachan.Pause();
                AudioSourceRestlessPravachan.Pause();
                AudioSourceTensedPravachan.Pause();
            }
            else {
                remainingTime -= Time.deltaTime;
            }
        }
        
        public void Next()
        {
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;

            if (m_CurrentStepIndex == 0) {
                AudioSourceOverwhelmedPravachan.Pause();
                AudioSourceRestlessPravachan.Pause();
                AudioSourceTensedPravachan.Pause();
                timerText.gameObject.SetActive(false);
            }

            if (m_CurrentStepIndex == 2) {
                int selectedIndex = myDropdown.value;
                timerText.gameObject.SetActive(true);
                remainingTime = 391;
                if (selectedIndex == 0)
                {
                    AudioSourceOverwhelmedPravachan.Play();
                    Debug.Log("HI");
                }
                if (selectedIndex == 1)
                {
                    AudioSourceRestlessPravachan.Play();
                }
                if (selectedIndex == 2)
                {
                    AudioSourceTensedPravachan.Play();
                }
            }
        }
    }
}
