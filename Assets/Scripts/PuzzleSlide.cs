using UnityEngine;
using Random = UnityEngine.Random;

public class PuzzleSlide : MonoBehaviour
{

    [SerializeField] private Transform emptySpace;
    public Camera _camera;
    [SerializeField] private TileScript[] tiles;


    private void Start()
    {
        // _camera = Camera.main;
        Shuffle();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3f)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                }
            }
        }

        int correctTiles = 0;
        foreach (TileScript item in tiles)
        {
            if (item != null)
            {
                if (item.inRightPlace)
                {
                    correctTiles++;
                }
            }
        }

        // print("correctTiles : " + correctTiles);

        if (correctTiles == tiles.Length - 1)
        {
            gameObject.SetActive(false);
            GameController.instance.NextScene(1);
            print("YouWin");
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i <= 8; i++)
        {
            if (tiles[i] != null)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 7);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;

            }
        }
    }
}
