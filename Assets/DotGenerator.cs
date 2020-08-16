using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DotGenerator : MonoBehaviour{
    public GameObject dot;
    List<GameObject> dots = new List<GameObject>();
    List<List<int>> faces = new List<List<int>>();
    public float time = 0;
    int[] faceState = new int[]{0, 0, 0};
    // float speed = 1.5f;
    float mabataki = 10;
    bool bgMode = true;
    float bgTime = 0;
    bool bgFlag = true;

    void Start(){
    }

    void Update(){
        time += Time.deltaTime;
        if(Input.GetMouseButton(0)){
            bgTime += Time.deltaTime;
            if(bgTime > 3 && bgFlag){
                Camera.main.backgroundColor = bgMode ? Color.black : Color.white;
                bgMode = !bgMode;
                bgFlag = false;
            }
        }else{
            bgFlag = true;
            bgTime = 0;
        }
        
        normalMode();
        // randomFace();
    }

    // void randomFace(){
    //     int e = (int)Random.Range(0, 9);
    //     int m = (int)Random.Range(0, 10);
    //     int c = (int)Random.Range(0, 3);
    //     faceDisplay(new int[]{e, m, c});
    // }

    void normalMode(){
        if(mabataki < time){
            faceDisplay(new int[]{3, 1, 0});
            if(mabataki < time - 0.08f){
                time = 0;
                mabataki = Random.Range(10, 13);
            }
        }else
            faceDisplay(new int[]{1, 1, 0});
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

    void faceDisplay(int[] face){
        // 顔表示
        if(!(face[0] == faceState[0] && face[1] == faceState[1] && face[2] == faceState[2])){
            reset();
            List<int> f = new List<int>{};
            for(int i = 0; i < 16; i++)
                f.Add(
                    DotGenerator.eyes[face[0], i] | 
                    DotGenerator.mouse[face[1], i] | 
                    DotGenerator.mouse[face[2], i]
                );
            List<int[]> faced = decode(f);
            for(int i = 0; i < faced.Count; i++){
                GameObject go = Instantiate(dot) as GameObject;
                go.transform.position = new Vector3(
                    8.45f - 0.7355f * faced[i][0],
                    6f - 0.7355f * faced[i][1],
                    0
                );
                dots.Add(go);
            }
            faceState = face;
        }
    }
}
