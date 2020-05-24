using UnityEngine;

public class Explode : MonoBehaviour
{
    //prefab of an obstacle
    public Rigidbody rb;
    //obstacle moving speed
    float speed;
    //material after the explosion
    public Material material;
    //small piece dimension
    float pieceSize = 0.1f;
    //number of cubes the obstacle will break in
    int cubesAmount = 5;
    //radius of explosion
    public float radius = 0.4f;
    //min power value for explosion
    public float explosionMin = 30f;
    //max power value for explosion
    public float explosionMax = 300f;

    private void Start()
    {
        //setting speed value selected from the user
        speed = FirstGameMenu.tempSpeed;
    }
    /// <summary>
    /// Moving the obstacles towards the player
    /// </summary>
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = speed * (transform.forward * -1);   
    }
    /// <summary>
    /// Detecting the collision between a hand and an obstacle
    /// Summing up the score separately for both hands
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Obstacle"))
        {
            Debug.Log("hit");
            if(other.gameObject.tag.Contains("Left"))
            {
                FindObjectOfType<Score>().ScoreRight();
            }
            else
            {
                FindObjectOfType<Score>().ScoreLeft();
            }
            Explosion();
            Physics.IgnoreLayerCollision(0, 9);
        }
    }
    /// <summary>
    /// Creating explosion effect to the small pieces by adding force
    /// </summary>
    void Explosion()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < cubesAmount; x++)
        {
            for (int y = 0; y < cubesAmount; y++)
            {
                for (int z = 0; z < cubesAmount; z++)
                    createPieces(x, y, z);
            }
        }
        Vector3 explPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(explosionMin, explosionMax), transform.position, radius);
            }
        }
        //destroying small pieces after some time
        if (gameObject.name.Contains("piece"))
        {
            Destroy(gameObject, 2f);
        }
    }
    /// <summary>
    /// Creating small cubes on 3 axes
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    void createPieces(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // setting pieces position to the obstacle's place
        piece.transform.position = transform.position + new Vector3(pieceSize * x, pieceSize * y, pieceSize * z); 
        //setting scale of the object
        piece.transform.localScale = new Vector3(pieceSize, pieceSize, pieceSize); 
        piece.layer = 9;
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().useGravity = true;
        piece.GetComponent<Rigidbody>().mass = pieceSize;
        piece.GetComponent<Renderer>().material = material;
        piece.name = "piece";
    }
}

