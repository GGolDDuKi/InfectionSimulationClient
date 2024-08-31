using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //path에 해당하는 주소의 오브젝트를 불러온다
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    //path에 해당하는 오브젝트를 생성
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    public GameObject Instantiate(GameObject original, Transform parent = null)
    {
        if (original == null)
        {
            Debug.Log($"Failed to load prefab");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    public GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if (original == null)
        {
            Debug.Log($"Failed to load prefab");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, position, rotation, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }

    //Pool이 가능한 오브젝트를 Pool에 보관, 그 외 파괴
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }

    public void Destroy(GameObject go, float delay)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable, delay);
            return;
        }

        Object.Destroy(go, delay);
    }

    public GameObject FindObject(string name)
    {
        GameObject go = GameObject.Find(name);
        
        if (go == null)
            Debug.LogError($"There is no object with name : {name}");

        return go;
    }
}
