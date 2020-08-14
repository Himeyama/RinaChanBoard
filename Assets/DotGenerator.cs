using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGenerator : MonoBehaviour{
    public GameObject dot;
    List<GameObject> dots = new List<GameObject>();
    List<List<int>> faces = new List<List<int>>();
    float time = 0;
    int bt = -1;

    bool flag = true;

    void Start(){
        // 顔登録
        
        // faces.Add(new List<int>{});
        
        // 目のみ
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,0,0,0,0,0,0});
        // 目と口閉じ
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,0,65664,33024,32256,0,0});
        // 目と口A
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,65280,33024,33024,16896,15360,0});
        // 目と口B
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,15360,16896,16896,9216,6144,0});
        // 目と口C
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,0,6144,9216,9216,6144,0});
        // 目と口D
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,0,65280,33024,32256,0,0});
        // 目と口E
        faces.Add(new List<int>{0,0,0,393312,393312,393312,393312,0,0,0,0,130944,65664,65280,0,0});
        // ＞＜照・口閉じ
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,1310760,2687124,33024,32256,0,0});
        // ＞＜照れ・口A
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1376040,33024,33024,16896,15360,0});
        // ＞＜照れ・口B 10
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1326120,16896,16896,9216,6144,0});
        // ＞＜照れ・口C
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1310760,6144,9216,9216,6144,0});
        // ＞＜照れ・口D
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1310760,130944,65664,65280,0,0});
        // ＞＜照れ・口E
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1376040,33024,16896,9216,6144,0});
        // ＞＜照れ・口F
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,655440,1360680,81024,65664,65664,81024,49920});
        // ＞＜・口閉じ
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,0,0,65664,33024,32256,0});
        // ＞＜・口A
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,65280,33024,33024,16896,15360,0});
        // ＞＜・口B
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,15360,16896,16896,9216,6144,0});
        // ＞＜・口C
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,0,6144,9216,9216,6144,0});
        // ＞＜・口D
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,0,130944,65664,65280,0,0});
        // ＞＜・口G 20
        faces.Add(new List<int>{0,0,0,1572888,393312,65664,393312,1572888,0,0,0,0,26112,39168,0,0});
        // 目閉じ・口閉じ
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,0,65664,33024,32256,0,0});
        // 目閉じ・口A
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,65280,33024,33024,16896,15360,0});
        // 目閉じ・口B
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,15360,16896,16896,9216,6144,0});
        // 目閉じ・口C
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,0,6144,9216,9216,6144,0});
        // 目閉じ・口D
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,0,65280,33024,32256,0,0});
        // 目閉じ・口E
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,0,0,0,130944,65664,65280,0,0});
        // 目閉じ・照れ・口なし
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,655440,1310760,0,0,0,0,0,0});
        // 目閉じ・照れ・口閉じ
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,655440,1310760,0,65664,33024,32256,0,0});
        // 目閉じ・照れ・口A
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,655440,1310760,65280,33024,33024,16896,15360,0});
        // 目閉じ・照れ・口B 30
        faces.Add(new List<int>{0,0,0,0,1048584,983280,0,0,655440,1310760,15360,16896,16896,9216,6144,0});
        // 目閉じ・照れ・口C
        faces.Add(new List<int>{});
        faces.Add(new List<int>{});
        faces.Add(new List<int>{});
        faces.Add(new List<int>{});
        faces.Add(new List<int>{});

        // faces.Add(new List<int>{0,0,0,393240,393312,393344,393312,24,0,1310760,65280,33024,16896,9216,6144,0});
    }

    void Update(){
        time += Time.deltaTime;
        if(bt != (int)time){
            faceDisplay((int)time % 30);
        }
        bt = (int)time;
    }

    List<int[]> decode(List<int> font){
        // 顔座標取得
        List<int[]> d = new List<int[]>{};
        for(int i = 0; i < 16; i++){
            int row = font[i];
            for(int j = 0; j < 24; j++){
                if((row & 1) == 1){
                    int[] xy = new int[2]{j, i};
                    d.Add(xy);
                }
                row >>= 1;
            }
        }
        return d;
    }

    void reset(){
        // 表示リセット
        for(int i = 0; i < dots.Count; i++)
            Destroy(dots[i]);
        dots.RemoveAll(e => true);
    }

    void faceDisplay(int faceNumber){
        reset();
        List<int> face = faces[faceNumber];
        List<int[]> faced = decode(face);
        for(int i = 0; i < faced.Count; i++){
            GameObject go = Instantiate(dot) as GameObject;
            go.transform.position = new Vector3(
                8.45f - 0.7355f * faced[i][0],
                6f - 0.7355f * faced[i][1],
                0
            );
            dots.Add(go);
        }
    }
}
