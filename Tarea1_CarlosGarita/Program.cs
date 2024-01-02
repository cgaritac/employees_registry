/*
 Universidad: UNED
Curso:        Programación Avanzada
Código:       00830
Tema:         Tarea 1
Estudiante:   Carlos Garita Campos
Periodo:      II Cuatrimestre 2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarea1_CarlosGarita
{
    //Clase principal desde donde se inicializa el programa
    class Program
    {
        //Metodo main que ejecuta el programa
        static void Main(string[] args)
        {
            // Definición de variables 
            string salir = "N";
            int opcion = 0;
            Supervisores[] Supervisor = new Supervisores[20];
            Cajeros[] Cajero = new Cajeros[20];
            Categorias[] Categoria = new Categorias[20];
            Productos[] Producto = new Productos[20];
            int[] contador = new int[4] {0,0,0,0};
            
            //Ciclo do-while que impide salir hasta que el usuario confirme que efectivamente desea salir
            do
            {
                //Ciclo do-while que controla la salida del programa cuando el usuario selecciona la opción 6 del menú para posteriormente confirmar con el usuario si realmente desea salir
                do
                {
                    // Escribe en pantalla el menú y solicita al usuario que seleccione una opción
                    Console.Write
                      ("**************************  Menú   ************************** \n" +
                      " \n" +                      
                      "1) Registro de supervisores \n" +
                      "2) Registro de cajeros \n" +
                      "3) Registro de categorías \n" +
                      "4) Registro de productos \n" +
                      "5) Mostrar todos los registros \n" +
                      "6) Salir del sistema \n" +
                      " \n" +
                      "Seleccione la opción que desea: \n" +
                      " \n" 
                      );

                    //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros en la variable "opción"
                    try
                    {
                        //Obtención de valor ingresado por el usuario y conversión de string a int, para luego asignarlo a la variable opcion
                        opcion = int.Parse(Console.ReadLine());

                        Console.WriteLine(""); //Escribe un espacio en blanco

                        // Definición de variables 
                        bool error = true, error2 = true, error3 = true;
                        string continuar = "N";
                        Validacion validar = new Validacion();

                        //Switch para ejecutar la acción seleccionada por el usuario de acuerdo a las opciones del menú
                        switch (opcion)
                        {
                            case 1: //Ejecución para cuando el usuario selecciona la opcion 1

                                //Ciclo do-while que controla si el usuario quiere ingresar más supervisores
                                do
                                {                                    
                                    Supervisores sup = new Supervisores();

                                    Console.WriteLine("__________________ Registro de supervisores __________________ \n");

                                    //Solicitud de datos a usuario                                
                                    Console.WriteLine("\nIndique el número de identificación (alfanumerico): \n");
                                    sup.Identificacion = Console.ReadLine();

                                    Console.WriteLine("\nIndique el nombre: \n");
                                    sup.Nombre = Console.ReadLine();

                                    Console.WriteLine("\nIndique el primer apellido: \n");
                                    sup.Apellido1 = Console.ReadLine();

                                    Console.WriteLine("\nIndique el segundo apellido: \n");
                                    sup.Apellido2 = Console.ReadLine();

                                    Console.WriteLine("\nIndique la sucursal asignada: \n");
                                    sup.Sucursal = Console.ReadLine();

                                    //Asignación del objeto "sup" al arreglo "Supervisor" en la posición del contador respectiva
                                    Supervisor[contador[0]] = sup;

                                    //Ciclo do-while que valida si el usuario ingresó la opción correcta entre "S" o "N"
                                    do
                                    {
                                        //Solicita en pantalla al usuario que indique si desea ingresar más datos nuevos y asigna lo indicado por el usuario en la variable "continuar"
                                        Console.WriteLine("\n¿Desea ingresar datos de otro supervisor? S/N\n");
                                        continuar = Console.ReadLine();

                                        continuar = continuar.ToUpper(); //Convierte el dato ingresado por el usuario a mayúsculas

                                        Console.WriteLine("");

                                        //Condicional para indicar al usuario que no ingresó una opción válida
                                        if (continuar != "N" && continuar != "S")
                                        {
                                            Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta\n");
                                        }

                                    } while (continuar != "N" && continuar != "S");

                                    //Suma un 1 al contador
                                    contador[0] = contador[0] + 1;

                                } while (continuar == "S" && contador[0] < 20);                                

                                break;

                            case 2: //Ejecución para cuando el usuario selecciona la opcion 2

                                //Ciclo do-while que controla si el usuario quiere ingresar más cajeros
                                do
                                {
                                    Cajeros caj = new Cajeros();

                                    Console.WriteLine("__________________ Registro de cajeros __________________ \n");

                                    //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente 
                                    Console.WriteLine("\nIndique el número de identificación (alfanumerico): \n");
                                    caj.Identificacion = Console.ReadLine();

                                    Console.WriteLine("\nIndique el nombre: \n");
                                    caj.Nombre = Console.ReadLine();

                                    Console.WriteLine("\nIndique el primer apellido: \n");
                                    caj.Apellido1 = Console.ReadLine();

                                    Console.WriteLine("\nIndique el segundo apellido: \n");
                                    caj.Apellido2 = Console.ReadLine();

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a entero
                                            Console.WriteLine("\nIndique el número de caja asignada: \n");
                                            caj.Caja = int.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(caj.Caja); //Validación para determinar si hay números negativos
                                            error2 = validar.validacionCeros(caj.Caja); //Validación para determinar si se ingresó el número cero
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar el número de caja asignada en enteros positivos \n");
                                            error = true;
                                        }

                                        //Condicional para forzar que se repita el ciclo en caso de que el usuario ingrese un valor repetido
                                        if (error2 == true)
                                        {
                                            error = true;
                                        }
                                    } while (error == true);

                                    //Asignación del objeto "caj" al arreglo "Cajero" en la posición del contador respectiva
                                    Cajero[contador[1]] = caj;

                                    //Ciclo do-while que valida si el usuario ingresó la opción correcta entre "S" o "N"
                                    do
                                    {
                                        //Solicita en pantalla al usuario que indique si desea ingresar más datos nuevos y asigna lo indicado por el usuario en la variable "continuar"
                                        Console.WriteLine("\n¿Desea ingresar datos de otro cajero? S/N\n");
                                        continuar = Console.ReadLine();

                                        continuar = continuar.ToUpper(); //Convierte el dato ingresado por el usuario a mayúsculas

                                        Console.WriteLine("");

                                        //Condicional para indicar al usuario que no ingresó una opción válida
                                        if (continuar != "N" && continuar != "S")
                                        {
                                            Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta\n");
                                        }

                                    } while (continuar != "N" && continuar != "S");

                                    //Suma un 1 al contador
                                    contador[1] = contador[1] + 1;

                                } while (continuar == "S" && contador[1] < 20);                                                      

                                break;

                            case 3: //Ejecución para cuando el usuario selecciona la opcion 3

                                //Ciclo do-while que controla si el usuario quiere ingresar más categorías
                                do
                                {
                                    Categorias cat = new Categorias();

                                    Console.WriteLine("__________________ Registro de categorías __________________ \n");

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a entero
                                            Console.WriteLine("\nIndique el código de la categoría (solo números): \n");
                                            cat.CodigoCategoria = int.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(cat.CodigoCategoria); //Validación para determinar si hay números negativos
                                            error2 = validar.codigoRepetido(Producto, Categoria, cat.CodigoCategoria, contador[2], 1); //Validación para determinar si el valor ingresado por el usuario
                                                                                                                                       //se encuentra repetido
                                            error3 = validar.validacionCeros(cat.CodigoCategoria); //Validación para determinar si hay ceros
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar el código de la categoría en enteros positivos \n");
                                            error = true;
                                        }

                                        //Condicional para forzar que se repita el ciclo en caso de que el usuario ingrese un valor repetido
                                        if (error2 == true || error3 == true)
                                        {
                                            error = true;
                                        }
                                    } while (error == true);

                                    //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente
                                    Console.WriteLine("\nIndique la descripción de la categoría: \n");
                                    cat.DescripcionCategoria = Console.ReadLine();

                                    //Asignación del objeto "cat" al arreglo "Categoria" en la posición del contador respectiva
                                    Categoria[contador[2]] = cat;

                                    //Ciclo do-while que valida si el usuario ingresó la opción correcta entre "S" o "N"
                                    do
                                    {
                                        //Solicita en pantalla al usuario que indique si desea ingresar más datos nuevos y asigna lo indicado por el usuario en la variable "continuar"
                                        Console.WriteLine("\n¿Desea ingresar datos de otra categoría? S/N\n");
                                        continuar = Console.ReadLine();

                                        continuar = continuar.ToUpper();//Convierte el dato ingresado por el usuario a mayúsculas

                                        Console.WriteLine("");

                                        //Condicional para indicar al usuario que no ingresó una opción válida
                                        if (continuar != "N" && continuar != "S")
                                        {
                                            Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta \n");
                                        }

                                    } while (continuar != "N" && continuar != "S");

                                    //Suma un 1 al contador
                                    contador[2] = contador[2] + 1;

                                } while (continuar == "S" && contador[2] < 20);                               

                                break;
                            case 4: //Ejecución para cuando el usuario selecciona la opcion 4

                                //Ciclo do-while que controla si el usuario quiere ingresar más productos
                                do
                                {
                                    Productos prod = new Productos();

                                    Console.WriteLine("__________________ Registro de productos __________________ \n");

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a entero
                                            Console.WriteLine("\nIndique el código del producto (solo números): \n");
                                            prod.CodigoProducto = int.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(prod.CodigoProducto); //Validación para determinar si hay números negativos
                                            error2 = validar.codigoRepetido(Producto, Categoria, prod.CodigoProducto, contador[3], 2); //Validación para determinar si el valor ingresado por el usuario
                                                                                                                                       //se encuentra repetido
                                            error3 = validar.validacionCeros(prod.CodigoProducto); //Validación para determinar si hay ceros
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar el código de producto en enteros positivos \n");
                                            error = true;
                                        }

                                        //Condicional para forzar que se repita el ciclo en caso de que el usuario ingrese un valor repetido
                                        if (error2 == true || error3 == true)
                                        {
                                            error = true;
                                        }

                                    } while (error == true);

                                    //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente
                                    Console.WriteLine("\nIndique la descripción del producto: \n");
                                    prod.DescripcionProducto = Console.ReadLine();

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a entero
                                            Console.WriteLine("\nIndique la cantidad existente del producto: \n");
                                            prod.CantidadExistente = int.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(prod.CantidadExistente); //Validación para determinar si hay números negativos
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar la cantidad existente del producto en enteros positivos \n");
                                            error = true;
                                        }
                                    } while (error == true);

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no decimales 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a decimal
                                            Console.WriteLine("\nIndique el precio: \n");
                                            prod.Precio = double.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(prod.Precio); //Validación para determinar si hay números negativos
                                            error2 = validar.validacionCeros(prod.Precio); //Validación para determinar si se ingresó el número cero
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar el precio en números positivos \n");
                                            error = true;
                                        }

                                        //Condicional para forzar que se repita el ciclo en caso de que el usuario ingrese un valor repetido
                                        if (error2 == true)
                                        {
                                            error = true;
                                        }
                                    } while (error == true);

                                    //Ciclo do-while que controla que se repita la solicitud de datos al usuario hasta que se ingresen datos válidos
                                    do
                                    {
                                        //Try-Catch para capturar el error generado cuando el usuario ingresa valores no enteros 
                                        try
                                        {
                                            //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente después
                                            //de convertirlo a entero
                                            Console.WriteLine("\nIndique el código de la categoría (solo números): \n");
                                            prod.Categor.CodigoCategoria = int.Parse(Console.ReadLine());
                                            error = validar.validacionNegativos(prod.Categor.CodigoCategoria); //Validación para determinar si hay números negativos
                                            error2 = validar.validacionCeros(prod.Categor.CodigoCategoria); //Validación para determinar si hay ceros
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError!, debe indicar el código de la categoría en enteros positivos \n");
                                            error = true;
                                        }

                                        //Condicional para forzar que se repita el ciclo en caso de que el usuario ingrese un valor repetido
                                        if (error2 == true)
                                        {
                                            error = true;
                                        }
                                    } while (error == true);

                                    //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva del objeto correspondiente
                                    Console.WriteLine("\nIndique la descripción de la categoría: \n");
                                    prod.Categor.DescripcionCategoria = Console.ReadLine();

                                    //Asignación del objeto "prod" al arreglo "Producto" en la posición del contador respectiva
                                    Producto[contador[3]] = prod;

                                    //Ciclo do-while que valida si el usuario ingresó la opción correcta entre "S" o "N"
                                    do
                                    {
                                        //Solicita en pantalla al usuario que indique si desea ingresar más datos nuevos y asigna lo indicado por el usuario en la variable "continuar"
                                        Console.WriteLine("\n¿Desea ingresar datos de otro producto? S/N\n");
                                        continuar = Console.ReadLine();

                                        continuar = continuar.ToUpper(); //Convierte el dato ingresado por el usuario a mayúsculas

                                        Console.WriteLine("");

                                        //Condicional para indicar al usuario que no ingresó una opción válida
                                        if (continuar != "N" && continuar != "S")
                                        {
                                            Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta \n");
                                        }

                                    } while (continuar != "N" && continuar != "S");

                                    //Contador un 1 al contador
                                    contador[3] = contador[3] + 1;

                                } while (continuar == "S" && contador[3] < 20);       
                                
                                break;

                            case 5: //Ejecución en para cuando el usuario selecciona la opcion 5
                                Console.WriteLine("__________________ Mostrar todos los registros __________________ \n");

                                Console.WriteLine("-------------- Datos del supervisor -------------- \n");

                                //Try-Catch para capturar el error generado cuando el arreglo de 20 espacios no se encuentra lleno 
                                try
                                {
                                    //Ciclo "for" para recorrer el arreglo
                                    for (int i = 0; i < contador[0]; i++)
                                    {
                                        //Imprime en pantalla los datos del arreglo en la posición respectiva de acuerdo al avance del ciclo
                                        Console.WriteLine("Identificación: {0}, Nombre: {1}, Primer apellido: {2}, Segundo apellido: {3}, Sucursal asignada: {4}\n", Supervisor[i].Identificacion, Supervisor[i].Nombre, Supervisor[i].Apellido1, Supervisor[i].Apellido2, Supervisor[i].Sucursal);
                                    }                                        
                                }
                                catch (Exception e)
                                {
                                    //Muestra en pantalla mensaje en caso de que no se hayan ingresado datos en el arreglo
                                    Console.WriteLine("No hay supervisores ingresados");
                                }
                                                                
                                Console.WriteLine("\n-------------- Datos del cajero -------------- \n");

                                //Try-Catch para capturar el error generado cuando el arreglo de 20 espacios no se encuentra lleno 
                                try
                                {
                                    //Ciclo "for" para recorrer el arreglo
                                    for (int i = 0; i < contador[1]; i++)
                                    {
                                        //Imprime en pantalla los datos del arreglo en la posición respectiva de acuerdo al avance del ciclo
                                        Console.WriteLine("Identificación: {0}, Nombre: {1}, Primer apellido: {2}, Segundo apellido: {3}, Caja asignada: {4}\n", Cajero[i].Identificacion, Cajero[i].Nombre, Cajero[i].Apellido1, Cajero[i].Apellido2, Cajero[i].Caja);
                                    }               
                                }
                                catch (Exception e)
                                {
                                    //Muestra en pantalla mensaje en caso de que no se hayan ingresado datos en el arreglo
                                    Console.WriteLine("No hay cajeros ingresados");
                                }
                                
                                Console.WriteLine("\n-------------- Datos de la categoría -------------- \n");

                                //Try-Catch para capturar el error generado cuando el arreglo de 20 espacios no se encuentra lleno 
                                try
                                {
                                    //Ciclo "for" para recorrer el arreglo
                                    for (int i = 0; i < contador[2]; i++)
                                    {
                                        //Imprime en pantalla los datos del arreglo en la posición respectiva de acuerdo al avance del ciclo
                                        Console.WriteLine("Código de la categoría: {0}, Descripción de la categoría: {1}\n", Categoria[i].CodigoCategoria, Categoria[i].DescripcionCategoria);
                                    }
                                }
                                catch (Exception e)
                                {
                                    //Muestra en pantalla mensaje en caso de que no se hayan ingresado datos en el arreglo
                                    Console.WriteLine("No hay categorías ingresadas");
                                }

                                Console.WriteLine("\n-------------- Datos del producto -------------- \n");

                                //Try-Catch para capturar el error generado cuando el arreglo de 20 espacios no se encuentra lleno 
                                try
                                {
                                    //Ciclo "for" para recorrer el arreglo
                                    for (int i = 0; i < contador[3]; i++)
                                    {
                                        //Imprime en pantalla los datos del arreglo en la posición respectiva de acuerdo al avance del ciclo
                                        Console.WriteLine("Código de la categoría: {0}, Descripción de la categoría: {1}, Código del producto: {2}, Descripción del producto: {3}, Cantidad del producto: {4}, Precio del producto: {5}\n", Producto[i].Categor.CodigoCategoria, Producto[i].Categor.DescripcionCategoria, Producto[i].CodigoProducto, Producto[i].DescripcionProducto, Producto[i].CantidadExistente, Producto[i].Precio);
                                    }                              
                                }
                                catch (Exception e)
                                {
                                    //Muestra en pantalla mensaje en caso de que no se hayan ingresado datos en el arreglo
                                    Console.WriteLine("No hay productos ingresados\n");
                                }

                                break;

                            case 6: //Ejecución en para cuando el usuario selecciona la opcion 6

                                break;
                        }

                        //Condicional para indicar al usuario que no ingresó una opción válida
                        if (opcion < 1 || opcion > 6)
                        {
                            Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta\n");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta\n");
                        opcion = 0;
                    }
                } while (opcion != 6);

                //Ciclo do-while que valida si el usuario ingresó la opción correcta entre "S" o "N"
                do
                {
                    //Solicita en pantalla al usuario que indique un dato y asigna lo indicado por el usuario en la variable respectiva
                    Console.WriteLine("¿Está realmente seguro de que desea salir ? S/N \n");
                    salir = Console.ReadLine();

                    salir = salir.ToUpper(); //Convierte el dato ingresado por el usuario a mayúsculas

                    Console.WriteLine("");

                    //Condicional para indicar al usuario que no ingresó una opción válida
                    if (salir != "N" && salir != "S")
                    {
                        Console.WriteLine("\nOpción incorrecta!, Favor seleccione la opción correcta\n");
                    }
                } while (salir!="N" && salir !="S");                

            } while (salir!="S");
        }
    }

    //Clase "Empleados" para información general de la cual heredan las clases "Supervisores" y "Cajeros"
    class Empleados
    {
        //Definición de variables globales
        private string identificacion, nombre, apellido1, apellido2;

        //Constructor
        public Empleados() { }

        //Metodo de get y set de la variable correspondiente
        public string Identificacion
        {
            get { return identificacion; }

            set { identificacion = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public string Nombre
        {
            get { return nombre; }

            set { nombre = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public string Apellido1
        {
            get { return apellido1; }

            set { apellido1 = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public string Apellido2
        {
            get { return apellido2; }

            set { apellido2 = value; }
        }
    }

    //Clase "Cajeros" que hereda de la clase "Empleados"
    class Cajeros : Empleados
    {
        //Definición de variables globales
        private int caja;

        //Constructor
        public Cajeros() { }

        //Metodo de get y set de la variable correspondiente
        public int Caja
        {
            get { return caja; }

            set { caja = value; }
        }
    }

    //Clase "Supervisores" que hereda de la clase "Empleados"
    class Supervisores : Empleados
    {
        //Definición de variables globales
        private string sucursal;

        //Constructor
        public Supervisores() { }

        //Metodo de get y set de la variable correspondiente
        public string Sucursal
        {
            get { return sucursal; }

            set { sucursal = value; }
        }
    }

    //Clase "Categorías" para los datos de las categorías de productos
    class Categorias
    {
        //Definición de variables globales
        private int codigoCategoria;
        private string descripcionCategoria;

        //Constructor
        public Categorias() { }

        //Metodo de get y set de la variable correspondiente
        public int CodigoCategoria
        {
            get { return codigoCategoria; }

            set { codigoCategoria = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public string DescripcionCategoria
        {
            get { return descripcionCategoria; }

            set { descripcionCategoria = value; }
        }
    }

    //Clase "Productos" para los datos de los productos que se venden
    class Productos
    {
        //Definición de variables globales
        private double precio;
        private int codigoProducto, cantidadExistente;
        private string descripcionProducto;

        private Categorias categor = new Categorias();

        //Constructor
        public Productos() { }

        //Metodo de get y set de la variable correspondiente
        public string DescripcionProducto
        { 
            get { return descripcionProducto; }

            set { descripcionProducto = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public int CodigoProducto
        {
            get { return codigoProducto; }

            set { codigoProducto = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public int CantidadExistente
        {
            get { return cantidadExistente; }

            set { cantidadExistente = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public double Precio
        {
            get { return precio; }

            set { precio = value; }
        }

        //Metodo de get y set de la variable correspondiente
        public Categorias Categor
        {
            get { return categor; }

            set { }
        }
    }

    //Clase "Validación" para ejecutar métodos de validación de datos ingresados por el usuario
    class Validacion
    {
        //Constructor
        public Validacion() { }

        //Método para validar si el usuario ingresó valores numéricos negativos
        public bool validacionNegativos(double numero)
        {
            //Definición de variables globales
            bool valor = true;

            //Condicional para determinar si el número ingresado por el usuario es negativo y asignar el booleano respectivo de acuerdo a ello
            if (numero < 0)
            {
                valor = true;
                Console.WriteLine("\nError!, debe indicar en valores positivos \n");
            }

            else
            {
                valor = false;
            }

            return valor; //Devolución de valor booleano
        }

        public bool validacionCeros(double numero)
        {
            //Definición de variables globales
            bool valor = true;

            //Condicional para determinar si el número ingresado por el usuario es cero y asignar el booleano respectivo de acuerdo a ello
            if (numero == 0)
            {
                valor = true;
                Console.WriteLine("\nError!, debe indicar un valor superior a cero \n");
            }

            else
            {
                valor = false;
            }

            return valor; //Devolución de valor booleano
        }

        //Método para validar si el usuario ingresó un código ya existente
        public bool codigoRepetido (Productos[] arreglo1, Categorias[] arreglo2, int codigo, int contador, int tipo)
        {
            //Definición de variables globales
            bool valor = false;

            //Condicional para determinar si se está valorando el código de categoría de producto
            if (tipo == 1)
            {
                //Ciclo para recorrer el arreglo de datos de categorías de productos 
                for (int i = 0; i < contador; i++)
                {
                    //Condicional para determinar si el código ingresado por el usuario ya fue ingresado anteriormente al arreglo de datos de categorías de productos
                    if (arreglo2[i].CodigoCategoria == codigo)
                    {
                        valor = true;
                        Console.WriteLine("\nError!, el valor ya existe, favor ingrese un valor nuevo \n");
                    }
                }
            }

            //Condicional para determinar si se está valorando el código de producto
            if (tipo == 2)
            {
                //Ciclo para recorrer el arreglo de datos de productos 
                for (int i = 0; i < contador; i++)
                {
                    //Condicional para determinar si el código ingresado por el usuario ya fue ingresado anteriormente al arreglo de datos de productos
                    if (arreglo1[i].CodigoProducto == codigo)
                    {
                        valor = true;
                        Console.WriteLine("\nError!, el valor ya existe, favor ingrese un valor nuevo \n");
                    }
                }
            }

            return valor; //Devolución de valor booleano
        }
    }
}
