using UnityEngine;

public class PrintChildren : MonoBehaviour
{
    void Start()
    {
        PrintImmediateChildren(gameObject);
    }

    void PrintImmediateChildren(GameObject parent)
    {
        int childCount = parent.transform.childCount;
        string childrenNames = "Immediate Children: ";

        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.transform.GetChild(i);
            childrenNames += child.name;

            if (i < childCount - 1)
            {
                childrenNames += ", ";
            }
        }

        Debug.Log(childrenNames);
    }
}
