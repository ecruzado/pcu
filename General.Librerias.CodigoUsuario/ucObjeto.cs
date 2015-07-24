using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General.Librerias.CodigoUsuario
{
    public class ucObjeto<T>
    {
        public static void grabarArchivoTexto(T obj, string archivo)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            using (FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        sw.Write(propiedad.Name);
                        sw.Write(" = ");
                        sw.WriteLine(propiedad.GetValue(obj, null) == null ? "" : propiedad.GetValue(obj, null).ToString());
                    }
                    sw.WriteLine(new String('_', 50));
                }
            }
        }

        public static string[] listarPropiedades(T obj)
        {
            List<string> lista = new List<string>();
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                lista.Add(propiedad.Name);
            }
            return (lista.ToArray());
        }

        public static void grabarLista(string archivo, List<T> lista, string separador)
        {
            PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.Default))
            {
                StringBuilder sb = new StringBuilder();
                //Escribir la primera linea con las cabeceras de los campos
                for (int i = 0; i < propiedades.Length - 1; i++)
                {
                    sb.Append(propiedades[i].Name);
                    sb.Append(separador);
                }
                sb.Append(propiedades[propiedades.Length - 1].Name);
                sw.WriteLine(sb.ToString());
                //Escribir los registros separador por algo
                foreach (T obj in lista)
                {
                    sb = new StringBuilder();
                    //sb.Clear();
                    for (int i = 0; i < propiedades.Length - 1; i++)
                    {
                        sb.Append(propiedades[i].GetValue(obj, null).ToString());
                        sb.Append(separador);
                    }
                    sb.Append(propiedades[propiedades.Length - 1].GetValue(obj, null).ToString());
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        public static void exportarXls(string archivoTxt, List<T> lista, string separador, string hoja)
        {
            grabarLista(archivoTxt, lista, separador);
            string ruta = Path.GetDirectoryName(archivoTxt);
            string nombre = Path.GetFileNameWithoutExtension(archivoTxt);
            string archivoExcel = ruta + "\\" + nombre + ".xlsx";
            if (File.Exists(archivoExcel)) File.Delete(archivoExcel);
            using (OleDbConnection con = new OleDbConnection("provider=Microsoft.Ace.oledb.12.0;data source=" + ruta + ";extended properties=Text;"))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Select * Into " + hoja + " In ''[Excel 12.0 xml;Database=" + archivoExcel + "]From " + nombre + "#TXT", con);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
