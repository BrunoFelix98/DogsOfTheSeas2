using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps
{
    /// <summary>
    /// Animated Tiles are tiles which run through and display a list of sprites in sequence.
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "New Animated Tile", menuName = "Tiles/Animated Tile")]
    public class AnimatedTile : TileBase
    {
        /// <summary>
        /// The List of Sprites set for the Animated Tile.
        /// This will be played in sequence.
        /// </summary>
        public Sprite[] m_AnimatedSprites;
        /// <summary>
        /// The minimum possible speed at which the Animation of the Tile will be played.
        /// A speed value will be randomly chosen between the minimum and maximum speed.
        /// </summary>
        public float m_MinSpeed = 1f;
        /// <summary>
        /// The maximum possible speed at which the Animation of the Tile will be played.
        /// A speed value will be randomly chosen between the minimum and maximum speed.
        /// </summary>
        public float m_MaxSpeed = 1f;
        /// <summary>
        /// The starting time of this Animated Tile.
        /// This allows you to start the Animation from a particular Sprite in the list of Animated Sprites.
        /// </summary>
        public float m_AnimationStartTime;
        /// <summary>
        /// The Collider Shape generated by the Tile.
        /// </summary>
        public Tile.ColliderType m_TileColliderType;

        /// <summary>
        /// Retrieves any tile rendering data from the scripted tile.
        /// </summary>
        /// <param name="position">Position of the Tile on the Tilemap.</param>
        /// <param name="tilemap">The Tilemap the tile is present on.</param>
        /// <param name="tileData">Data to render the tile.</param>
        public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
        {
            tileData.transform = Matrix4x4.identity;
            tileData.color = Color.white;
            if (m_AnimatedSprites != null && m_AnimatedSprites.Length > 0)
            {
                tileData.sprite = m_AnimatedSprites[m_AnimatedSprites.Length - 1];
                tileData.colliderType = m_TileColliderType;
            }
        }

        /// <summary>
        /// Retrieves any tile animation data from the scripted tile.
        /// </summary>
        /// <param name="position">Position of the Tile on the Tilemap.</param>
        /// <param name="tilemap">The Tilemap the tile is present on.</param>
        /// <param name="tileAnimationData">Data to run an animation on the tile.</param>
        /// <returns>Whether the call was successful.</returns>
        public override bool GetTileAnimationData(Vector3Int location, ITilemap tileMap, ref TileAnimationData tileAnimationData)
        {
            if (m_AnimatedSprites.Length > 0)
            {
                tileAnimationData.animatedSprites = m_AnimatedSprites;
                tileAnimationData.animationSpeed = Random.Range(m_MinSpeed, m_MaxSpeed);
                tileAnimationData.animationStartTime = m_AnimationStartTime;
                return true;
            }
            return false;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AnimatedTile))]
    public class AnimatedTileEditor : Editor
    {
        private AnimatedTile tile { get { return (target as AnimatedTile); } }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            int count = EditorGUILayout.DelayedIntField("Number of Animated Sprites", tile.m_AnimatedSprites != null ? tile.m_AnimatedSprites.Length : 0);
            if (count < 0)
                count = 0;

            if (tile.m_AnimatedSprites == null || tile.m_AnimatedSprites.Length != count)
            {
                Array.Resize<Sprite>(ref tile.m_AnimatedSprites, count);
            }

            if (count == 0)
                return;

            EditorGUILayout.LabelField("Place sprites shown based on the order of animation.");
            EditorGUILayout.Space();

            for (int i = 0; i < count; i++)
            {
                tile.m_AnimatedSprites[i] = (Sprite)EditorGUILayout.ObjectField("Sprite " + (i + 1), tile.m_AnimatedSprites[i], typeof(Sprite), false, null);
            }

            float minSpeed = EditorGUILayout.FloatField("Minimum Speed", tile.m_MinSpeed);
            float maxSpeed = EditorGUILayout.FloatField("Maximum Speed", tile.m_MaxSpeed);
            if (minSpeed < 0.0f)
                minSpeed = 0.0f;

            if (maxSpeed < 0.0f)
                maxSpeed = 0.0f;

            if (maxSpeed < minSpeed)
                maxSpeed = minSpeed;

            tile.m_MinSpeed = minSpeed;
            tile.m_MaxSpeed = maxSpeed;

            tile.m_AnimationStartTime = EditorGUILayout.FloatField("Start Time", tile.m_AnimationStartTime);
            tile.m_TileColliderType = (Tile.ColliderType)EditorGUILayout.EnumPopup("Collider Type", tile.m_TileColliderType);
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(tile);
        }
    }
#endif
}
