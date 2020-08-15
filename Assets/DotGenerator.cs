using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DotGenerator : MonoBehaviour{
    public GameObject dot;
    List<GameObject> dots = new List<GameObject>();
    List<List<int>> faces = new List<List<int>>();
    public float time = 0;
    int state = -1;
    float speed = 1.5f;
    float mabataki = 10;
    bool flag = true;

    void Start(){
        readFace();
    }

    void Update(){
        time += Time.deltaTime;
        if(mabataki < time){
            faceDisplay(20);
            if(mabataki < time - 0.08f){
                time = 0;
                mabataki = Random.Range(10, 13);
            }
        }else
            faceDisplay(1);
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
        if(faceNumber != state){
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
            state = faceNumber;
        }
    }
}
