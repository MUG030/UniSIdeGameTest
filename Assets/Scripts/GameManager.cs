using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;       // UI���g�p����

public class GameManager : MonoBehaviour
{
    /// <summary> �摜�I�u�W�F�N�g </summary>
    public GameObject mainImage;
    /// <summary> �Q�[���I�[�o�[�p�摜 </summary>
    public Sprite gameOverSpr;
    /// <summary> �N���A�摜 </summary>
    public Sprite gameClearSpr;
    /// <summary> �p�l�� </summary>
    public GameObject panel;
    /// <summary> restart�{�^�� </summary>
    public GameObject restartButton;
    /// <summary> �N���A�摜 </summary>
    public GameObject nextButton;

    /// <summary> �摜��\�����邽�߂̃C���[�W�R���|�[�l���g </summary>
    Image titleImage;

    // +++���Ԑ����̒ǉ�+++
    /// <summary> ���ԕ\���C���[�W </summary>
    public GameObject timeBar;
    /// <summary> ���ԃe�L�X�g </summary>
    public GameObject timeText;
    /// <summary> �^�C���R���g���[���[ </summary>
    TimeController timeCnt;

    // Start is called before the first frame update
    void Start()
    {
        // �摜���\���ɂ���
        Invoke("InactiveImage", 1.0f);
        // �{�^��(�p�l��)���\���ɂ���
        panel.SetActive(false);

        // +++���Ԑ����ǉ�+++
        /// <summary> TimeController�̎擾 </summary>
        timeCnt = GetComponent<TimeController>();
        if(timeCnt != null)
        {
            if(timeCnt._gameTime == 0.0f)
            {
                // ���Ԑ����Ȃ��Ȃ�B��
                timeBar.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController._gameState == "gameclear")
        {
            // �Q�[���N���A���
            mainImage.SetActive(true);      // �摜��\������
            panel.SetActive(true);          // �{�^����\������
            // restart�{�^���𖳌���
            Button button = restartButton.GetComponent<Button>();
            button.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSpr;      // �摜��ݒ肷��
            PlayerController._gameState = "gameend";
            // +++���Ԑ����̒ǉ�+++
            if (timeCnt != null)
            {
                // ���ԃJ�E���g��~
                timeCnt._isTimeOver = true;
            }
        }
        else if (PlayerController._gameState == "gameover")
        {
            // �Q�[���I�[�o�[
            mainImage.SetActive(true);
            panel.SetActive(true);
            Button button = nextButton.GetComponent<Button>();
            button.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSpr;       // �摜��ݒ�
            PlayerController._gameState = "gameend";
            // +++���Ԑ����̒ǉ�+++
            if (timeCnt != null)
            {
                // ���ԃJ�E���g��~
                timeCnt._isTimeOver = true;
            }
        }
        else if (PlayerController._gameState == "playing")
        {
            // �Q�[����
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // �v���C���[�R���g���[���̎擾
            PlayerController playerCnt = player.GetComponent<PlayerController>();
            // +++���Ԑ����̒ǉ�+++
            // �^�C�����X�V����
            if (timeCnt != null)
            {
                if (timeCnt._gameTime > 0.0f)
                {
                    // �����ɑ�����邱�Ƃŏ�����؂�̂Ă�
                    int _time = (int)timeCnt._displayTime;
                    // �^�C���X�V
                    timeText.GetComponent<TextMeshProUGUI>().text = _time.ToString();
                    // �^�C���I�[�o�[
                    if(_time == 0)
                    {
                        // ����0�ŃQ�[���I�[�o�[�ɂȂ�
                        playerCnt.GameOver();
                    }
                }
            }
        }
    }

    /// <summary>
    /// �摜���\���ɂ���
    /// </summary>
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
