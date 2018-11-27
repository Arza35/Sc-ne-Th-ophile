using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantome : MonoBehaviour {

    private float timestamps;
    public AnimationCurve curve;
    public float end;
    private Vector2 origin;
    public float duration;
    public Vector2 pos;

	void Start () {
        origin = transform.position;
        timestamps = Time.time;
        float offset = origin.y - curve.Evaluate(0f);
        for (int i = 0; i < curve.length; i++) {
            curve.MoveKey(i, new Keyframe(curve.keys[i].time, curve.keys[i].value + offset));
        }
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        pos.x = Mathf.Lerp(origin.x, origin.x+end, Mathf.InverseLerp(timestamps, timestamps+duration, Time.time));
        pos.y = curve.Evaluate(Mathf.Lerp(0f, 1f, Mathf.InverseLerp(timestamps, timestamps+duration, Time.time)));
        transform.position = pos;
        Debug.Log(pos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector2(transform.position.x+end, transform.position.y), 0.1f);
    }
}
