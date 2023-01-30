using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, 
        NetworkVariableWritePermission.Owner);

    private void Update()
    {
        Debug.Log(OwnerClientId + ", randomNo: " + randomNumber);
        if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }

        if (IsOwner)
        {
            Vector3 moveDir = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.UpArrow)) moveDir.z = +1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveDir.z = -1f;
            if (Input.GetKey(KeyCode.LeftArrow)) moveDir.x = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveDir.x = +1f;

            float moveSpeed = 3f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }



    [ServerRpc]
    public void TestServerRpc(int a)
    {

    }

    [ClientRpc]
    public void TestClientRpc()
    {

    }
}
