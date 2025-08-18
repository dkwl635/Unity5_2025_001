using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 풀링을 관리하는 매니저 클래스입니다.
/// 게임 오브젝트의 재사용을 통해 성능을 최적화합니다.
/// </summary>
public class PoolManager : MonoBehaviour
{

    public GameObject[] prefabs;

    List<GameObject>[] pools;

    /// <summary>
    /// 풀 배열을 초기화합니다.
    /// </summary>
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0 ; index < prefabs.Length; ++index)
        {
            pools[index] = new List<GameObject>();
        }
    }

    /// <summary>
    /// 지정된 인덱스의 비활성화된 오브젝트를 반환하거나 새로 생성합니다.
    /// </summary>
    /// <param name="index">프리팹 배열의 인덱스</param>
    /// <returns>활성화된 게임 오브젝트</returns>
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
