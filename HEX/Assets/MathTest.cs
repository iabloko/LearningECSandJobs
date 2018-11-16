using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour {
    public string zero_eight;
    public string two_six;
    public bool zero_eight_First;
    public int count = 10000;

    private int int_zero_eight_First = 0;
    private int int_two_six = 0;
    private int score_zero_eight = 0;
    private int score_two_six = 0;

    private int player_one_health = 15; //
    private int player_two_health = 15;

    private WaitForSeconds _waitForseconds;

    void Start () {
        int_zero_eight_First = UnityEngine.Random.Range (0, 8);
        int_two_six = UnityEngine.Random.Range (2, 6);

        _waitForseconds = new WaitForSeconds (0.01f);
        score_zero_eight = 0;
        score_two_six = 0;

        Debug.Log (zero_eight + "                                " + two_six);
        Debug.Log ("WIN" + "                               " + "WIN");
        StartCoroutine (DamageTest ());
    }
    private IEnumerator DamageTest () {
        for (int i = 0; i < count; i++) {
            while (player_one_health > 0 || player_two_health > 0) {

                int_zero_eight_First = UnityEngine.Random.Range (0, 8);

                player_two_health -= int_zero_eight_First;

                int_two_six = UnityEngine.Random.Range (2, 6);
                player_one_health -= int_two_six;

                if (player_two_health <= 0) {
                    score_zero_eight++;
                    player_one_health = player_two_health = 15;
                    int_zero_eight_First = int_two_six = 0;
                    Debug.Log ("   " + score_zero_eight + "                                         " + "i=  " + i);
                    break;
                } else if (player_one_health <= 0) {
                    score_two_six++;
                    player_one_health = player_two_health = 15;
                    int_zero_eight_First = int_two_six = 0;
                    Debug.Log ("                                  " + score_two_six + "          " + "i=  " + i);
                    break;
                }
                yield return _waitForseconds;
            }
        }
    }

    private IEnumerator DamageTest2 () {
        for (int i = 0; i < count; i++) {
            while (player_one_health > 0 || player_two_health > 0) {
                int_two_six = UnityEngine.Random.Range (2, 6);
                player_one_health -= int_two_six;

                int_zero_eight_First = UnityEngine.Random.Range (0, 8);
                player_two_health -= int_zero_eight_First;

                if (player_two_health <= 0) {
                    score_zero_eight++;
                    player_one_health = player_two_health = 15;
                    int_zero_eight_First = int_two_six = 0;
                    Debug.Log ("   " + score_zero_eight + "                                         " + "i=  " + i);
                    break;
                } else if (player_one_health <= 0) {
                    score_two_six++;
                    player_one_health = player_two_health = 15;
                    int_zero_eight_First = int_two_six = 0;
                    Debug.Log ("                                  " + score_two_six + "          " + "i=  " + i);
                    break;
                }
                yield return _waitForseconds;
            }
        }
    }
}