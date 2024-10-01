using UnityEngine;

public class StairSpawner : MonoBehaviour
{
    public GameObject stairPrefab;  // 階段のPrefab
    public Transform player;        // プレイヤーの位置
    public float spawnDistance = 5.0f;  // 生成される距離
    public int stairsPerGroup = 3;  // 1グループに含まれる階段の数

    private Vector3 nextSpawnPosition; // 次の階段を生成する位置
    private bool canSpawnNextStair = true; // 次の階段を生成できるかどうかのフラグ

    void Start()
    {
        // 初期位置設定
        nextSpawnPosition = new Vector3(0.1f, 1f, -8f);
        SpawnNextStair(); // 最初の階段を生成
    }

    void Update()
    {
        // プレイヤーのY座標が0.3以下になり、かつ次の階段を生成できる状態なら新しい階段を生成
        if (player.position.y <= 0.3f && canSpawnNextStair)
        {
            SpawnNextStair();
            canSpawnNextStair = false; // フラグをfalseに設定して連続生成を防ぐ
        }
        // プレイヤーが前の階段から十分に離れたら、次の階段を生成できるようにする
        else if (player.position.y > 0.5f)
        {
            canSpawnNextStair = true;
        }
    }

    void SpawnNextStair()
    {
        // プレハブを生成し、位置と回転を指定
        Vector3 spawnPosition = nextSpawnPosition;
        Quaternion spawnRotation = Quaternion.Euler(0, 45, 0);
        Instantiate(stairPrefab, spawnPosition, spawnRotation);

        // 次に生成する階段の位置を更新
        nextSpawnPosition += new Vector3(0, -0.5f, 1.0f);
    }
}
