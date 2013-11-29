using UnityEngine;
using System.Collections;

public interface ICloudGenerator
{
	void AddCloud(float z);
}

public class CloudGenerator : MonoBehaviour, ICloudGenerator {

	public int MinSize = 2;
	public int MaxSize = 20;
	public float Roughness = 1.0f;
	public float Threshold = 0.5f;
	public Transform CloudBlockType;
	public Transform CloudType;
	public float CloudSpacing = 50f;
	public float MinX = -100f;
	public float MaxX = 80f;
	public float MinZ = -100f;
	public float MaxZ = 10f;

	// Use this for initialization
	void Start () {
		for (float x = MinX ; x < MaxX ; x+= CloudSpacing) {
			for (float z = MinZ ; z < MaxZ ; z+= CloudSpacing) {
				x += Random.Range(-CloudSpacing / 2, CloudSpacing / 2);
				z += Random.Range(-CloudSpacing / 2, CloudSpacing / 2);
				AddCloud(x,z);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void AddCloud(float z)
	{
		AddCloud (MaxX, z);
	}

	public void AddCloud(float baseX, float baseZ)
	{
		int width = (int) Random.Range(MinSize, MaxSize);
		int depth = (int) Random.Range(MinSize, MaxSize);
		float[,] cloudStrength = Generate (width, depth, Roughness);
		float multX;
		float multZ;

		Vector3 position = new Vector3(
			this.transform.position.x + baseX,
			this.transform.position.y,
			this.transform.position.z + baseZ);
		Transform newCloud = (Transform) Instantiate(CloudType, position, this.transform.rotation);
		//((Cloud) newCloud.gameObject).Generator = this;
		newCloud.gameObject.GetComponent<Cloud>().Generator = this;

		for (int x = 0 ; x < width ; x++) {
			multX = (width - (Mathf.Abs ((width / 2f) - x))) / (width * .8f);
			for (int z = 0 ; z < depth ; z++) {
				multZ = (depth - (Mathf.Abs ((depth / 2f) - z))) / (depth * .8f);
				float strength = cloudStrength[x,z];
				strength *= multX;
				strength *= multZ;
				if (strength  > Threshold) {
					Vector3 cubePosition = new Vector3(x, 0, z);
					Transform cube = (Transform) Instantiate(CloudBlockType, position, Quaternion.identity);
					cube.transform.parent = newCloud.transform;
					cube.transform.localPosition = cubePosition;
				}
			}
		}
	}

	private float gRoughness;
	private int gBigSize;

	public float[,] Generate(int iWidth, int iHeight, float iRoughness)  
	{  
		float c1, c2, c3, c4;  
		float[,] points = new float[iWidth+1, iHeight+1];  
		
		//Assign the four corners of the intial grid random color values  
		//These will end up being the colors of the four corners          
		c1 = Random.value;  
		c2 = Random.value;  
		c3 = Random.value;  
		c4 = Random.value;  
		gRoughness = iRoughness;  
		gBigSize = iWidth + iHeight;  
		DivideGrid(ref points, 0, 0, iWidth, iHeight, c1, c2, c3, c4);  
		return points;  
	}

	public void DivideGrid(ref float[,] points, float x, float y, float width, float height, float c1, float c2, float c3, float c4)  
	{  
		float Edge1, Edge2, Edge3, Edge4, Middle;  
		
		float newWidth = Mathf.Floor((float)width / 2.0f);  
		float newHeight = Mathf.Floor((float)height / 2.0f);  
		
		if (width > 1 || height > 1)  
		{  
			Middle = ((c1 + c2 + c3 + c4) / 4)+Displace(newWidth + newHeight);  //Randomly displace the midpoint!  
			Edge1 = ((c1 + c2) / 2);    //Calculate the edges by averaging the two corners of each edge.  
			Edge2 = ((c2 + c3) / 2);  
			Edge3 = ((c3 + c4) / 2);  
			Edge4 = ((c4 + c1) / 2);//  
			//Make sure that the midpoint doesn't accidentally "randomly displaced" past the boundaries!  
			Middle= Rectify(Middle);  
			Edge1 = Rectify(Edge1);  
			Edge2 = Rectify(Edge2);  
			Edge3 = Rectify(Edge3);  
			Edge4 = Rectify(Edge4);  
			//Do the operation over again for each of the four new grids.             
			DivideGrid(ref points, x, y, newWidth, newHeight, c1, Edge1, Middle, Edge4);  
			DivideGrid(ref points, x + newWidth, y, width - newWidth, newHeight, Edge1, c2, Edge2, Middle);  
			DivideGrid(ref points, x + newWidth, y + newHeight, width - newWidth, height - newHeight, Middle, Edge2, c3, Edge3);  
			DivideGrid(ref points, x, y + newHeight, newWidth, height - newHeight, Edge4, Middle, Edge3, c4);  
		}  
		else    //This is the "base case," where each grid piece is less than the size of a pixel.  
		{  
			//The four corners of the grid piece will be averaged and drawn as a single pixel.  
			float c = (c1 + c2 + c3 + c4) / 4;  
			
			points[(int)(x), (int)(y)] = c;  
			if (width == 2)  
			{  
				points[(int)(x+1), (int)(y)] = c;  
			}  
			if (height == 2)  
			{  
				points[(int)(x), (int)(y+1)] = c;  
			}  
			if ((width == 2) && (height == 2))   
			{  
				points[(int)(x + 1), (int)(y+1)] = c;  
			}  
		}  
	} 

	private float Rectify(float iNum)  
	{  
		if (iNum < 0)  
		{  
			return 0;  
		}  
		else if (iNum > 1.0f)  
		{  
			return 1.0f;  
		}  
		return iNum;  
	}  
	
	private float Displace(float SmallSize)  
	{  
		float Max = SmallSize/ gBigSize * gRoughness;  
		return (Random.value - 0.5f) * Max;  
	}
}
