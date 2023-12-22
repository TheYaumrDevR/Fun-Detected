using Org.Ethasia.Fundetected.Ioadapters;

using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemyRenderSkeleton
    {
        private GameObject enemy;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        public EnemyRenderSkeleton()
        {
            InitComponents();
        }

        public void SetupDataForRendering(EnemyRenderData renderData)
        {
            enemy.transform.position = new Vector3(renderData.PositionX, renderData.PositionY, 0);
            enemy.transform.localScale = new Vector3(renderData.ScaleX, renderData.ScaleY, 1);
            LoadSprite(renderData.SpriteIdleImageName);
        }   

        public void SetRootTransform(Transform rootTransform)
        {
            enemy.transform.SetParent(rootTransform);
        }          

        private void InitComponents()
        {
            enemy = new GameObject();
            spriteRenderer = enemy.AddComponent<SpriteRenderer>();
            animator = enemy.AddComponent<Animator>();           
        }        

        private void LoadSprite(string spriteIdleImageName)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(spriteIdleImageName);
            spriteRenderer.sprite = sprites[0];
        }
    }
}