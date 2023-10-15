using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private Arrow currentArrow;

    private bool isReloading;

    public bool IsReady
    {
        get { return !isReloading && currentArrow != null; }
    }

    private void Start()
    {
        SetArrow();
    }

    public void SetArrow()
    {
        isReloading = false;
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
    }

    public void Fire(float firePower)
    {
        //if (isReloading || currentArrow == null) return;
        currentArrow.Fly(spawnPoint.TransformDirection(Vector3.forward * firePower));
        currentArrow = null;
        Reload();
    }

    public void Reload()
    {
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        SetArrow();
    }
}