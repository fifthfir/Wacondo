using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCatController : MonoBehaviour
{
    public Transform player; // 玩家对象的Transform组件
    private SpriteRenderer spriteRenderer; // 物体的SpriteRenderer组件

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 检测玩家的移动方向
        float playerDirection = player.position.x - transform.position.x;

        // 根据玩家移动方向设置物体的scale.x
        if (playerDirection > 0)
        {
            // 玩家在物体的右边，保持正常scale.x
            spriteRenderer.flipX = false;
        }
        else if (playerDirection < 0)
        {
            // 玩家在物体的左边，翻转scale.x
            spriteRenderer.flipX = true;
        }
        // 如果playerDirection等于0则保持原来的方向
    }
}
