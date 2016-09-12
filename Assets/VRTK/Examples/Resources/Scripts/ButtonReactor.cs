namespace VRTK.Examples
{
    using UnityEngine;

    public class ButtonReactor : MonoBehaviour
    {
        public GameObject go;
        public Transform dispenseLocation;
		public ScoreCounter scoreCounter;

		private int incrementAmount;

        private void Start()
        {
            GetComponent<VRTK_Button>().events.OnPush.AddListener(handlePush);
			incrementAmount = 1;
        }

		public void UpdateIncrememntAmount (int newIncrememntAmount) {
			incrementAmount = newIncrememntAmount;
		}

		public void SetButtonSizeMultiplier (int buttonSizeMultiplier) {
			this.gameObject.transform.localScale *= buttonSizeMultiplier;
		}

        private void handlePush()
        {
			scoreCounter.AddMoney (incrementAmount);
//            Debug.Log("Pushed");

  //          GameObject newGo = (GameObject)Instantiate(go, dispenseLocation.position, Quaternion.identity);
    //        Destroy(newGo, 10f);
        }
    }
}