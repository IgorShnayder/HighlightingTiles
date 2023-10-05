using UnityEditor.UIElements;
using UnityEngine;

public class Highlighting : MonoBehaviour
{
    [SerializeField] private Material _basicMaterial;
    [SerializeField] private Material _highlightingMaterial;
    [SerializeField] private string _exclusiveTag;
    
    private GameObject _currentlyHighlightedObject;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var hitInfo))
        {
            var hitObject = hitInfo.collider.gameObject;
            
            if (hitObject.tag == _exclusiveTag) return;
            
            HighlightingObject(hitObject);
        }
        else
        {
            if (_currentlyHighlightedObject != null)
            {
                _currentlyHighlightedObject.GetComponent<Renderer>().material = _basicMaterial;
                _currentlyHighlightedObject = null;
            }
        }
    }

    private void HighlightingObject(GameObject gameObject)
    {
        if (gameObject == _currentlyHighlightedObject) return;
        
        if (_currentlyHighlightedObject != null)
        {
            _currentlyHighlightedObject.GetComponent<Renderer>().material = _basicMaterial;
        }
                
        gameObject.GetComponent<Renderer>().material = _highlightingMaterial;
                
        _currentlyHighlightedObject = gameObject;
    }
}
