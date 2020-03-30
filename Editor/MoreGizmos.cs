
using UnityEditor;
using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantNameQualifier

namespace thelebaron.MoreGizmos
{
    public static class MoreGizmos
    {
        public static Color color { get; set; }
        private const string UnlitMaterialPath = "Packages/com.thelebaron.moregizmos/Materials/Unlit.mat";
        private static Material _unlit;
        private static Material Unlit()
        {
            if (_unlit == null)
            {
                _unlit = AssetDatabase.LoadAssetAtPath<Material>(UnlitMaterialPath);
                _unlit.shader = Shader.Find("Unlit/Color"); //unsure if constantly setting this means perf issues in editor
            }
            
            _unlit.color = color;
            return _unlit;
        }


        private const string DiamondMeshPath = "Packages/com.thelebaron.moregizmos/Meshes/Diamond.mesh";
        private static Mesh _diamondMesh;
        
        private static Mesh DiamondMesh()
        {
            if(_diamondMesh==null)
                _diamondMesh = AssetDatabase.LoadAssetAtPath<Mesh>(DiamondMeshPath);
            
            return _diamondMesh;
        }
        
        #region DiamondUnlit
        
        public static void DrawUnlitDiamond(Vector3 position)
        {
            UnityEngine.Gizmos.DrawWireMesh(DiamondMesh(), position);
            
            // This seems very hacky? but its what the docs call for..
            // https://docs.unity3d.com/ScriptReference/Graphics.DrawMeshNow.html
            // set first shader pass of the material(what does this mean?)
            Unlit().SetPass(0);
            Graphics.DrawMeshNow(DiamondMesh(), position, Quaternion.identity);
            
        }
        #endregion
        
        #region Diamond

        public static void DrawDiamond(Vector3 position)
        {
            UnityEngine.Gizmos.DrawMesh(DiamondMesh(), position);
        }
        
        public static void DrawDiamond(Vector3 position, Quaternion rotation)
        {
            UnityEngine.Gizmos.DrawMesh(DiamondMesh(), position, rotation);
        }
        
        public static void DrawDiamond(Vector3 position, Quaternion rotation, Color color)
        {
            UnityEngine.Gizmos.color = color;
            UnityEngine.Gizmos.DrawMesh(DiamondMesh(), position, rotation);
        }

        #endregion

        #region WireDiamond
        
        public static void DrawWireDiamond(Vector3 position)
        {
            UnityEngine.Gizmos.DrawWireMesh(DiamondMesh(), position);
        }
        
        public static void DrawWireDiamond(Vector3 position, Quaternion rotation)
        {
            UnityEngine.Gizmos.DrawWireMesh(DiamondMesh(), position, rotation);
        }
        
        public static void DrawWireDiamond(Vector3 position, Quaternion rotation, Color color)
        {
            UnityEngine.Gizmos.color = color;
            UnityEngine.Gizmos.DrawWireMesh(DiamondMesh(), position, rotation);
        }

        #endregion
        
    }
}
//#if UNITY_EDITOR
//#endif