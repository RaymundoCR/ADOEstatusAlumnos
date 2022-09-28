using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    public class Program
    {
        static Estatus objEstatus = new Estatus();
        public static List<Estatus> _listaStatusAl = new List<Estatus>();
        static void Main(string[] args)
        {
            string opcion;
            CRUDEstatus objCrud = new CRUDEstatus();
            do
            {
                Console.WriteLine("SELECIONE UNA OPCION \n1.- Consultar Todos \n2.- Consultar Solo uno \n3.- Agregar  \n4.- Actualizar \n5.- Eliminar \n6.- Terminar");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Usted selecciono la opcion 1 Consultar todos\n\n");
                        _listaStatusAl = objCrud.Consultar();
                        try
                        {
                            foreach (Estatus s in _listaStatusAl)
                            {
                                Console.Write($"{s.id} {s.Clave} {s.Nombre}");
                                Console.WriteLine();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Usted selecciono la opcion 2 Consultar uno\n\n");
                        Console.WriteLine("Por favor ingrese el id status a consultar");
                        int val = Convert.ToInt32(Console.ReadLine());
                        objEstatus = objCrud.Consultar(val);
                        Console.Write($"{objEstatus.id} {objEstatus.Clave} {objEstatus.Nombre}");
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        objEstatus = new Estatus();
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Usted selecciono la opcion 3 Agregar un nuevo EstatusAlumnos\n\n");
                            //Console.WriteLine("Por favor digite el id");
                            //objEstatus.id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Por favor digite la clave del status");
                            objEstatus.Clave = Console.ReadLine();
                            Console.WriteLine("Por favor digite el nombre del status");
                            objEstatus.Nombre = Console.ReadLine();
                            int res = objCrud.Agregar(objEstatus);
                            Console.WriteLine($"Se ha agregado correctamente, agregado con el id: {res}");
                            Console.ReadKey();
                        }catch(Exception e) { Console.WriteLine(e.Message); }
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Usted selecciono la opcion 4 Actualizar estatusAlumnos\n\n");
                            Console.WriteLine("Por favor digite el id del estatus que se requiere actualizar");
                            objEstatus.id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Por favor digite la nueva clave del estatus");
                            objEstatus.Clave = Console.ReadLine();
                            Console.WriteLine("Por favor digite el nuevo nombre");
                            objEstatus.Nombre = Console.ReadLine();
                            objCrud.Actualizar(objEstatus);
                            Console.WriteLine("Se ha actualizado correctamente");
                            Console.ReadKey();
                        }catch( Exception e) { Console.WriteLine(e.Message); }
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Usted selecciono la opcion 5 Eliminar estatusAlumnos\n\n");
                        Console.WriteLine("Por favor digite el id del estatus a eliminar");
                        objEstatus.id = Convert.ToInt32(Console.ReadLine());
                        objCrud.Eliminar(objEstatus);
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Usted a salido de la áplicación\n\n");

                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion seleccionada no existe\n\n");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "6");

        }
    }
}
