using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Sprites;
using UnityEngine.Scripting;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using UnityEngine.Assertions.Comparers;
using System.Collections;
using System.Collections.Generic;

namespace SplineCurve
{
    public struct Point
    {
        public float[] axis;
        public PointType type { get; private set; }
        public Point(PointType type)
        {
            this.type = type;
            axis = new float[(int)type];
        }
        public Point(System.Type type)
        {
            if(type == typeof(float))
            {
                this.type = PointType.Float;
            }
            else if(type == typeof(Vector2))
            {
                this.type = PointType.Vector2;
            }
            else if (type == typeof(Vector3))
            {
                this.type = PointType.Vector3;
            }
            else if (type == typeof(Vector4))
            {
                this.type = PointType.Vector4;
            }
            else
            {
                this.type = PointType.Float;
            }
            axis = new float[(int)this.type];
        }

        public Point(float value)
        {
            this.type = PointType.Float;
            axis = new float[1];
            axis[0] = value;
        }
        public Point(Vector2 value)
        {
            this.type = PointType.Vector2;
            axis = new float[2];
            axis[0] = value.x;
            axis[1] = value.y;
        }
        public Point(Vector3 value)
        {
            this.type = PointType.Vector3;
            axis = new float[3];
            axis[0] = value.x;
            axis[1] = value.y;
            axis[2] = value.z;
        }
        public Point(Vector4 value)
        {
            this.type = PointType.Vector4;
            axis = new float[4];
            axis[0] = value.x;
            axis[1] = value.y;
            axis[2] = value.z;
            axis[4] = value.w;
        }

        public float FloatValue
        {
            get { if (axis == null || axis.Length < 1) return 0; return axis[0]; }
        }
        public Vector2 Vector2Value
        {
            get { if (axis == null || axis.Length < 2) return Vector2.zero; return new Vector2(axis[0], axis[1]); }
        }
        public Vector3 Vector3Value
        {
            get { if (axis == null || axis.Length < 3) return Vector3.zero; return new Vector3(axis[0], axis[1], axis[2]); }
        }
        public Vector2 Vector4Value
        {
            get { if (axis == null || axis.Length < 4) return Vector4.zero; return new Vector4(axis[0], axis[1], axis[3], axis[4]); }
        }


        public static implicit operator Point(float value)
        {
            return new Point(value);
        }
        public static implicit operator float(Point point)
        {
            return point.axis[0];
        }

        public static implicit operator Point(Vector2 value)
        {
            return new Point(value);
        }
        public static implicit operator Vector2(Point point)
        {
            return point.Vector2Value;
        }


        public static implicit operator Point(Vector3 value)
        {
            return new Point(value);
        }
        public static implicit operator Vector3(Point point)
        {
            return point.Vector3Value;
        }

        public static implicit operator Point(Vector4 value)
        {
            return new Point(value);
        }
        public static implicit operator Vector4(Point point)
        {
            return point.Vector4Value;
        }

        public static Point operator +(Point a, Point b)
        {
            Debug.Assert(a.type == b.type,"类型不匹配!");
            var point = new Point(a.type);
            for (int i = 0; i < a.axis.Length; i++)
            {
                point.axis[i] = a.axis[i] + b.axis[i];
            }
            return point;
        }
        public static Point operator -(Point a, Point b)
        {
            Debug.Assert(a.type == b.type, "类型不匹配!");
            var point = new Point(a.type);
            for (int i = 0; i < a.axis.Length; i++)
            {
                point.axis[i] = a.axis[i] - b.axis[i];
            }
            return point;
        }
        public static Point operator *(float d, Point a)
        {
            var point = new Point(a.type);
            for (int i = 0; i < a.axis.Length; i++)
            {
                point.axis[i] *= d;
            }
            return point;
        }
        public static Point operator *(Point a, float d)
        {
            var point = new Point(a.type);
            for (int i = 0; i < a.axis.Length; i++)
            {
                point.axis[i] *= d;
            }
            return point;
        }
        public static Point operator /(Point a, float d)
        {
            var point = new Point(a.type);
            for (int i = 0; i < a.axis.Length; i++)
            {
                point.axis[i] /= d;
            }
            return point;
        }
    }
}