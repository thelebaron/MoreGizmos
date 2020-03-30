
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace thelebaron.MoreGizmos
{

    [CustomEditor(typeof(CreateMeshAssetFromSelection))]
    public class CreateMeshAssetFromSelectionInspector : UnityEditor.Editor
    {
        
        public override void OnInspectorGUI()
        {
            if(target==null) return;
            
            var c = target as CreateMeshAssetFromSelection;
            
            if(c==null) return;
            
            if (GUILayout.Button("Create Mesh Asset"))
            {
                AssetDatabase.CreateAsset(CreateTemporaryMesh(c.mesh), "Assets/" + c.meshName + ".mesh" );
            }
            DrawDefaultInspector();

        }

        private Mesh CreateTemporaryMesh(Mesh originalMesh)
        {
            Mesh tempMesh = (Mesh)UnityEngine.Object.Instantiate(originalMesh);
            return tempMesh;
        }
    }
}

#endif