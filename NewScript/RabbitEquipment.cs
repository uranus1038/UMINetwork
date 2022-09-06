using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitEquipment : MonoBehaviour
{
	private GameObject gameObject_0;
	public GameObject weapon_0;
	public GameObject helm_0;
	SkinnedMeshRenderer skinnedMeshRenderer;
	private void Start()
	{
		this.EquipAll();
	}
	private void Awake()
	{
	}
	private void EquipAll()
	{
		this.EquipWeapon("w_rab1");
		this.EquipArmor("a_all1");
	}
	private void EquipArmor(string nArmor)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)transform.GetComponent(typeof(SkinnedMeshRenderer));
		skinnedMeshRenderer.sharedMesh = RabbitEquipment.getEquipArmorMash(nArmor);
		skinnedMeshRenderer.material = RabbitEquipment.getEquipArmorMaterial(nArmor);


	}
	public void EquipWeapon(string nWeapon)
	{
		GameObject weapon_1 = getEquipWeapon(nWeapon);
		this.gameObject_0 = (GameObject)UnityEngine.Object.Instantiate(weapon_1, Vector3.zero, Quaternion.identity);
		this.gameObject_0.transform.parent = weapon_0.transform;
		this.gameObject_0.transform.localPosition = Vector3.zero;
		this.gameObject_0.transform.localRotation = Quaternion.identity;

	}
	private void EquipHelm()
	{




	}
	private static Material getEquipArmorMaterial(string nArmorMaterial)
	{
		Texture2D texture2D2;
		Texture2D texture2D = (Texture2D)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Armors/Overlay/Rabbit1", typeof(Texture2D));
		Color[] pixels = texture2D.GetPixels(0);
		switch (nArmorMaterial)
		{
			case "a_all1":
				texture2D2 = (Texture2D)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Armors/Materials/Rabbit_scout1", typeof(Texture2D));
				break;
			default:
				texture2D2 = (Texture2D)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Armors/Materials/Rabbit_nude1", typeof(Texture2D));
				break;
		}
		Color[] pixels2 = texture2D2.GetPixels(0, 256, 256, 256, 0);
		for (int i = 0; i < pixels2.Length; i++)
		{
			float a = pixels[i].a;
			pixels2[i] = a * pixels[i] + (1f - a) * pixels2[i];
		}
		Texture2D texture2D3 = new Texture2D(512, 512, TextureFormat.RGB24, true);
		texture2D3.SetPixels(0, 256, 256, 256, pixels2, 0);
		texture2D3.SetPixels(256, 256, 256, 256, texture2D2.GetPixels(256, 256, 256, 256, 0), 0);
		texture2D3.SetPixels(0, 0, 512, 256, texture2D2.GetPixels(0, 0, 512, 256, 0), 0);
		texture2D3.Apply();
		texture2D3.Compress(true);
		return new Material(Shader.Find("Supyrb/Unlit/Texture")) //"Diffuse"
		{
			color = new Color(0.86f, 0.86f, 0.86f, 1f),
			mainTexture = texture2D3
		};
	}
	private static Mesh getEquipArmorMash(string nArmorMash)
	{
		GameObject nArmor_0;
		switch (nArmorMash)
		{
			case "a_all1":
				nArmor_0 = (GameObject)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Armors/Rabbit_scout", typeof(GameObject));
				break;
			default:
				nArmor_0 = (GameObject)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Armors/Rabbit_nude", typeof(GameObject));
				break;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)nArmor_0.GetComponent(typeof(SkinnedMeshRenderer));
		return skinnedMeshRenderer.sharedMesh;

	}
	private static GameObject getEquipWeapon(string nWeapon)
	{
		GameObject result;
		switch (nWeapon)
		{
			case "w_rab1":
				result = (GameObject)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Weapons/noviceGun", typeof(GameObject));
				break;
			default:
				result = (GameObject)Resources.Load("GameAssets/Characters/Heroes/Rabbit/Weapons/standardGun", typeof(GameObject));
				break;
		}
		return result;
	}
	private static void getEquipHat()
	{

	}
}
