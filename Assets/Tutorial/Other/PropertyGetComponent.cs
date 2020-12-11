using UnityEngine;
using UnityEngine.UI;

namespace NinjaCode
{
    [RequireComponent(typeof(Button))]
    public class PropertyGetComponent : MonoBehaviour
    {
        private Button button;
        public Button Button => button ? button : button = GetComponent<Button>();
    }
}
