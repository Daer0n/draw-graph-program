using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystAnalys_lr1
{
    class Vertex
    {
        public int x, y;
        public String info;

        public Vertex(int x, int y, string info)
        {
            this.x = x;
            this.y = y;
            this.info = info;
        }
    }

    class Edge
    {
        public int v1, v2;
        /*public double weight;

        public Edge(int v1, int v2, double weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }
        */
        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            //darkGoldPen = new Pen(Color.Black);
            //darkGoldPen.Width = 2;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {

            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E)
        {
            double angle = Math.Atan((float)(V1.y - V2.y) / (float)(V1.x - V2.x));
            if (V1.x < V2.x)
                angle += 3.14;
            float pointOnCircleX = (float)(V2.x + 20 * Math.Cos(angle)), 
                    pointOnCircleY = (float)(V2.y + 20 * Math.Sin(angle));
            
            PointF[] curvePoints =
            {
                new PointF(pointOnCircleX, pointOnCircleY),
                new PointF((float)(pointOnCircleX + 20 * Math.Cos(angle + 0.261799)), (float)(pointOnCircleY + 20 * Math.Sin(angle + 0.261799))),
                new PointF((float)(pointOnCircleX + 20 * Math.Cos(angle - 0.261799)), (float)(pointOnCircleY + 20 * Math.Sin(angle - 0.261799)))
            };

            gr.DrawLine(blackPen, V1.x, V1.y, V2.x, V2.y);
            gr.DrawPolygon(blackPen, curvePoints);
            string s = " ";
            point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
            gr.DrawString(s, fo, br, point);
            drawVertex(V1.x, V1.y, V1.info);
            drawVertex(V2.x, V2.y, V2.info);
            
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 != E[i].v2)
                {
                    Vertex V1 = V[E[i].v1], V2 = V[E[i].v2];
                    double angle = Math.Atan((float)(V1.y - V2.y) / (float)(V1.x - V2.x));
                    if (V1.x < V2.x)
                        angle += 3.14;
                    float pointOnCircleX = (float)(V2.x + 20 * Math.Cos(angle)),
                            pointOnCircleY = (float)(V2.y + 20 * Math.Sin(angle));

                    PointF[] curvePoints =
                    {
                        new PointF(pointOnCircleX, pointOnCircleY),
                        new PointF((float)(pointOnCircleX + 20 * Math.Cos(angle + 0.261799)), (float)(pointOnCircleY + 20 * Math.Sin(angle + 0.261799))),
                        new PointF((float)(pointOnCircleX + 20 * Math.Cos(angle - 0.261799)), (float)(pointOnCircleY + 20 * Math.Sin(angle - 0.261799)))
                    };

                    gr.DrawLine(blackPen, V1.x, V1.y, V2.x, V2.y);
                    gr.DrawPolygon(blackPen, curvePoints);
                    string s = " ";

                    point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                    gr.DrawString(s, fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, V[i].info);
            }
        }
        
    }
}