using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool showMenu = false;


    public void ShowOrHideMenu()
    {
        showMenu = !showMenu;
        animator.SetBool("ShowMenu", showMenu);
    }
}
