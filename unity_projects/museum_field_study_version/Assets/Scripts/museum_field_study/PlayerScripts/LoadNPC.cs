using UnityEngine;

public class LoadNPC : MonoBehaviour
{
    public GameObject[] maleNPC;
    public GameObject[] femaleNPC;

    public GameObject femaleAvatarMayor;
    public GameObject maleAvatarMayor;
    public GameObject femaleAvatarCitizen;
    public GameObject maleAvatarCitizen;

    // panels thta have to be active depending on mayor/citizen only
    public GameObject[] mayorPanels;
    public GameObject[] citizenPanels;

    // panels thta have to be active depending on mayor/citizen and gender
    public GameObject[] femalePanelsMayor;
    public GameObject[] malePanelsMayor;
    public GameObject[] femalePanelsCitizen;
    public GameObject[] malePanelsCitizen;

    // panels thta have to be active depending on mayor/citizen and npc gender and gender
    public GameObject Panel_femaleMayor_femaleNPC;
    public GameObject Panel_femaleMayor_maleNPC;
    public GameObject Panel_maleMayor_femaleNPC;
    public GameObject Panel_maleMayor_maleNPC;
    public GameObject Panel_femaleCitizen_femaleNPC;
    public GameObject Panel_femaleCitizen_maleNPC;
    public GameObject Panel_maleCitizen_femaleNPC;
    public GameObject Panel_maleCitizen_maleNPC;



    void Awake()
    {
        ActivateNPCGender();
        ActivateAvatarAndPanels();

    }

    private void ActivateNPCGender()
    {
        bool isMale = GameManager.npc_gender == "male";

        foreach (GameObject npc in maleNPC)
        {
            npc.gameObject.SetActive(isMale);
        }
        foreach (GameObject npc in femaleNPC)
        {
            npc.gameObject.SetActive(!isMale);
        }
    }
        
    private void ActivateAvatarAndPanels()
    {
        bool isMale = GameManager.gender == "male";
        bool isMayor = GameManager.condition == "mayor";
        bool npcIsMale = GameManager.npc_gender == "male";

        SetAvatars(isMale, isMayor);
        //SetPanels(isMayor, npcIsMale);
        DestroyUnusedPanels(isMale, isMayor, npcIsMale);
    }

    private void SetAvatars(bool isMale, bool isMayor)
    {
        maleAvatarMayor.SetActive(isMale && isMayor);
        maleAvatarCitizen.SetActive(isMale && !isMayor);
        femaleAvatarMayor.SetActive(!isMale && isMayor);
        femaleAvatarCitizen.SetActive(!isMale && !isMayor);
    }

    private void DestroyUnusedPanels(bool isMale, bool isMayor, bool npcIsMale)
    {
            // Determine the active panel groups
        GameObject[] activeGenderPanels = isMale
            ? (isMayor ? malePanelsMayor : malePanelsCitizen)
            : (isMayor ? femalePanelsMayor : femalePanelsCitizen);

        GameObject[] activeRolePanels = isMayor ? mayorPanels : citizenPanels;

        GameObject activeNpcGenderPanel;

        if (isMayor)
        {
            if (isMale)
            {
                activeNpcGenderPanel = npcIsMale ? Panel_maleMayor_maleNPC : Panel_maleMayor_femaleNPC;
            }
            else
            {
                activeNpcGenderPanel = npcIsMale ? Panel_femaleMayor_maleNPC : Panel_femaleMayor_femaleNPC;
            }
        }
        else // Citizen
        {
            if (isMale)
            {
                activeNpcGenderPanel = npcIsMale ? Panel_maleCitizen_maleNPC : Panel_maleCitizen_femaleNPC;
            }
            else
            {
                activeNpcGenderPanel = npcIsMale ? Panel_femaleCitizen_maleNPC : Panel_femaleCitizen_femaleNPC;
            }
        }

        // List all panel groups
        GameObject[][] allGenderPanels = new GameObject[][]
        {
            malePanelsMayor,
            malePanelsCitizen,
            femalePanelsMayor,
            femalePanelsCitizen
        };

        GameObject[][] allRolePanels = new GameObject[][]
        {
            mayorPanels,
            citizenPanels
        };

        GameObject[] allNpcGenderPanels = new GameObject[]
        {
            Panel_femaleMayor_femaleNPC,
            Panel_femaleMayor_maleNPC,
            Panel_maleMayor_femaleNPC,
            Panel_maleMayor_maleNPC,
            Panel_femaleCitizen_femaleNPC,
            Panel_femaleCitizen_maleNPC,
            Panel_maleCitizen_femaleNPC,
            Panel_maleCitizen_maleNPC
        };

        // Destroy all gender-based panels except the active ones
        foreach (GameObject[] panelGroup in allGenderPanels)
        {
            if (panelGroup != activeGenderPanels)
            {
                foreach (GameObject panel in panelGroup)
                {
                    Destroy(panel);
                }
            }
        }

        // Destroy all role-based panels except the active ones
        foreach (GameObject[] panelGroup in allRolePanels)
        {
            if (panelGroup != activeRolePanels)
            {
                foreach (GameObject panel in panelGroup)
                {
                    Destroy(panel);
                }
            }
        }

        // Destroy all NPC gender-sensitive panels except the active one
        foreach (GameObject panel in allNpcGenderPanels)
        {
            if (panel != activeNpcGenderPanel)
            {
                Destroy(panel);
            }
        }
    }

    
}

        // // activate the given avatar with condition (random mayor/citizen) and gender (participant's gender)
        // if (GameManager.gender == "male")
        // {
        //     if (GameManager.condition == "mayor")
        //     {
        //         maleAvatarMayor.gameObject.SetActive(true);
        //         maleAvatarCitizen.gameObject.SetActive(false);
        //         femaleAvatarMayor.gameObject.SetActive(false);
        //         femaleAvatarCitizen.gameObject.SetActive(false);

        //         if (GameManager.npc_gender == "male")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(true);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }
        //         else if (GameManager.npc_gender == "female")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(true);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }

        //         foreach (GameObject panel in malePanelsCitizen)
        //         {
        //             panel.gameObject.SetActive(true);
        //         }
        //         foreach (GameObject panel in malePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }

        //     }
        //     if (GameManager.condition == "citizen")
        //     {
        //         maleAvatarMayor.gameObject.SetActive(false);
        //         maleAvatarCitizen.gameObject.SetActive(true);
        //         femaleAvatarMayor.gameObject.SetActive(false);
        //         femaleAvatarCitizen.gameObject.SetActive(false);

        //         if (GameManager.npc_gender == "male")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(true);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }
        //         else if (GameManager.npc_gender == "female")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(true);
        //         }
                

        //         foreach (GameObject panel in malePanelsCitizen)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in malePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(true);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //     }

        // }
        // else if (GameManager.gender == "female")
        // {
        //     if (GameManager.condition == "mayor")
        //     {
        //         maleAvatarMayor.gameObject.SetActive(false);
        //         maleAvatarCitizen.gameObject.SetActive(false);
        //         femaleAvatarMayor.gameObject.SetActive(true);
        //         femaleAvatarCitizen.gameObject.SetActive(false);
                
        //         if (GameManager.npc_gender == "male")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(true);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }
        //         else if (GameManager.npc_gender == "female")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(true);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }
                

        //         foreach (GameObject panel in malePanelsCitizen)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in malePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(true);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }

        //     }
        //     if (GameManager.condition == "citizen")
        //     {
        //         maleAvatarMayor.gameObject.SetActive(false);
        //         maleAvatarCitizen.gameObject.SetActive(false);
        //         femaleAvatarMayor.gameObject.SetActive(false);
        //         femaleAvatarCitizen.gameObject.SetActive(true);

        //         if (GameManager.npc_gender == "male")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(true);
        //             panelCitizen_femaleNPC.gameObject.SetActive(false);
        //         }
        //         else if (GameManager.npc_gender == "female")
        //         {
        //             panelMayor_maleNPC.gameObject.SetActive(false);
        //             panelMayor_femaleNPC.gameObject.SetActive(false);
        //             panelCitizen_maleNPC.gameObject.SetActive(false);
        //             panelCitizen_femaleNPC.gameObject.SetActive(true);
        //         }
                
        //         foreach (GameObject panel in malePanelsCitizen)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in malePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(false);
        //             Destroy(panel);
        //         }
        //         foreach (GameObject panel in femalePanelsMayor)
        //         {
        //             panel.gameObject.SetActive(true);
        //         }

        //     }
        // }

//     }
// }