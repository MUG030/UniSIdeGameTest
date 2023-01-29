using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        // �摜���\���ɂ���
        Invoke("InactiveImage", 1.0f);
        // �{�^��(�p�l��)���\���ɂ���
        panel.SetActive(false);
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
        }
        else if (PlayerController._gameState == "playing")
        {
            // �Q�[����
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
