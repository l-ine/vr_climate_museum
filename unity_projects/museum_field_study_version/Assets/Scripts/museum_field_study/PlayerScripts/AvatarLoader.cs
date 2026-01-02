using UnityEngine;

public class AvatarLoader : MonoBehaviour
{
    
    public GameObject femaleAvatarMayor;
    public GameObject maleAvatarMayor;
    public GameObject femaleAvatarCitizen;
    public GameObject maleAvatarCitizen;

    public void SetAvatars()
    {
        bool isMale = GameManager.gender == "male";
        bool isMayor = GameManager.condition == "mayor";

        maleAvatarMayor.SetActive(isMale && isMayor);
        maleAvatarCitizen.SetActive(isMale && !isMayor);
        femaleAvatarMayor.SetActive(!isMale && isMayor);
        femaleAvatarCitizen.SetActive(!isMale && !isMayor);
    }
}