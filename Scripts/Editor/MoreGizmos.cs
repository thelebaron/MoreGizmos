
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

        private const string ConeMeshPath = "Packages/com.thelebaron.moregizmos/Meshes/Cone.mesh";
        private static Mesh _coneMesh;
        
        private static Mesh ConeMesh()
        {
            if(_coneMesh==null)
                _coneMesh = AssetDatabase.LoadAssetAtPath<Mesh>(ConeMeshPath);
            
            return _coneMesh;
        }
        
        private const string DiamondMeshPath = "Packages/com.thelebaron.moregizmos/Meshes/Diamond.mesh";
        private static Mesh _diamondMesh;
        
        private static Mesh DiamondMesh()
        {
            if(_diamondMesh==null)
                _diamondMesh = AssetDatabase.LoadAssetAtPath<Mesh>(DiamondMeshPath);
            
            return _diamondMesh;
        }
        
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
        
        public static void DrawUnlitDiamond(Vector3 position, Quaternion rotation)
        {
            //UnityEngine.Gizmos.DrawWireMesh(DiamondMesh(), position);
            // This seems very hacky? but its what the docs call for..
            // https://docs.unity3d.com/ScriptReference/Graphics.DrawMeshNow.html
            // set first shader pass of the material(what does this mean?)
            Unlit().SetPass(0);
            Graphics.DrawMeshNow(DiamondMesh(), position, rotation);
        }
        
        #endregion
        
        #region Cone
        
        /// <summary>
        /// Draws a wire cone
        /// </summary>
        public static void DrawWireCone(Vector3 position)
        {
            UnityEngine.Gizmos.DrawWireMesh(ConeMesh(), position);
        }
        
        public static void DrawWireCone(Vector3 position, Quaternion rotation)
        {
            UnityEngine.Gizmos.DrawWireMesh(ConeMesh(), position, rotation);
        }
        
        public static void DrawWireCone(Vector3 position, Quaternion rotation, Color color)
        {
            UnityEngine.Gizmos.color = color;
            UnityEngine.Gizmos.DrawWireMesh(ConeMesh(), position, rotation);
        }
        
        /// <summary>
        /// Draws a solid cone
        /// </summary>
        public static void DrawCone(Vector3 position)
        {
            UnityEngine.Gizmos.DrawMesh(ConeMesh(), position);
        }
        
        public static void DrawCone(Vector3 position, Quaternion rotation)
        {
            UnityEngine.Gizmos.DrawMesh(ConeMesh(), position, rotation);
        }
        
        public static void DrawCone(Vector3 position, Quaternion rotation, Color color)
        {
            UnityEngine.Gizmos.color = color;
            UnityEngine.Gizmos.DrawMesh(ConeMesh(), position, rotation);
        }

        public static void DrawUnlitCone(Vector3 position, Quaternion rotation)
        {
            //UnityEngine.Gizmos.DrawWireMesh(ConeMesh(), position);
            Unlit().SetPass(0);
            Graphics.DrawMeshNow(ConeMesh(), position, rotation);
        }

        #endregion
        
    }
}
//#if UNITY_EDITOR
//#endif