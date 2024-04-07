using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;

    Stack<GameObject> lineStack;

    public bool isActive = true;

    void Start()
    {
        lineStack = new Stack<GameObject>();
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (!isActive) return; // don't start a new line when clicking on UI elements

            GameObject newLine = Instantiate(linePrefab);
            lineStack.Push(newLine);

            activeLine = newLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePosition);
        }
    }

    public void UndoLine()
    {
        if (lineStack.Count > 0)
        {
            Destroy(lineStack.Pop());
        }else {
            Debug.Log("Cannot pop from empty stack");
        }
    }
}
