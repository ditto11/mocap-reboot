using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SwapInterface
{
   public List<GameObject> ReturnChoices();

   public void SetChoice(int choiceIndex);
}
