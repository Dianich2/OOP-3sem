using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9_OOP
{
    internal class MyCollection : IEnumerator 
    {
        List<GeometryFigure> listFigure;
        int pos;
        public MyCollection(){
            this.listFigure = new List<GeometryFigure>();
        }
        public int GetCount()
        {
            return this.listFigure.Count;
        }

        public void AddFigure(GeometryFigure f)
        {
            this.listFigure.Add(f);
        }

        public void RemoveFigureAt(int pos)
        {
            this.listFigure.RemoveAt(pos);
        }
        public void RemoveFigure(GeometryFigure f)
        {
            this.listFigure.Remove(f);
        }

        public bool Contains(GeometryFigure f)
        {
            return this.listFigure.IndexOf(f) != -1;
        }

        public void OutputCollection()
        {
            foreach(GeometryFigure f in this.listFigure)
            {
               f.PrintInformationAboutFigure();
            }
        }


        public object Current
        {
            get
            {
                if (pos < 0 || pos >= listFigure.Count) throw new IndexOutOfRangeException("Неверный индекс\n");
                return this.listFigure[pos];
            }
        }

        public bool MoveNext()
        {
            pos++;
            return pos < this.listFigure.Count;
        }

        public void Reset()
        {
            pos = -1;
        }
    }
}
