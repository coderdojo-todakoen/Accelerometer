using System;
using UnityEngine;

public class Main : MonoBehaviour
{
#if !UNITY_EDITOR && UNITY_WSA
    BLEPlugin.BLEGATTClient plugin = new BLEPlugin.BLEGATTClient();
#else
    BLEGATTClient plugin = new BLEGATTClient();
#endif

    public ParticleSystem buttonA;
    public ParticleSystem buttonB;

    private byte prevButtonAState = 0;
    private byte prevButtonBState = 0;

    // Start is called before the first frame update
    void Start()
    {
        // micro:bitと接続します
        plugin.Start(1);
    }

    // Update is called once per frame
    void Update()
    {
        // 加速度センサの値を取得します
        Int16 ax = plugin.accelerometerDataX;
        Int16 ay = plugin.accelerometerDataY;
        Int16 az = plugin.accelerometerDataZ;

        // x軸、z軸方向の傾きを求めます
        float roll = -Mathf.Atan2(ay, az) * Mathf.Rad2Deg;
        float pitch = Mathf.Atan2(ax, az) * Mathf.Rad2Deg;

        // 求めた傾きを設定します
        transform.rotation = Quaternion.Euler(roll, 180, pitch);

        // Aボタンの状態(0:押されていない、1:押されている)を取得します
        byte buttonAState = plugin.buttonAState;
        if ((prevButtonAState == 0) && (buttonAState == 1)) {
            // Aボタンが押されたら、ParticleSystemを実行します
            buttonA.Play();
        }
        prevButtonAState = buttonAState;

        // Bボタンの状態(0:押されていない、1:押されている)を取得します
        byte buttonBState = plugin.buttonBState;
        if ((prevButtonBState == 0) && (buttonBState == 1)) {
            // Bボタンが押されたら、ParticleSystemを実行します
            buttonB.Play();
        }
        prevButtonBState = buttonBState;
    }
}
