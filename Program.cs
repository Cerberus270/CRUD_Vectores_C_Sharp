using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] codigo = new int[10];//este array guarda los codigos de las facturas
            int[] cantidad_productos = new int[10];//este la cantidad de los productos
            int[] clientes_credito_fiscal = new int[10];//este guarda los clientes que tienen credito fiscal(guarda el codigo de la factura)
            double[] precios = new double[10];//este guarda los precios de los productos
            double[] totales_pagar = new double[10];//este guarda los totales de las facturas, total=subtotal+iva(en caso que exista)
            double[] ivas = new double[10];//si hay iva lo calcula y los guarda aqui
            double[] sub_totales = new double[10];//este guarda los subtotales, subtotal=precio*cantidad
            string[] nombres_clientes = new string[10];//este guarda los apelldios de los clientes
            string[] apellidos = new string[10];//este los nombres de los clientes
            string[] nombre_productos = new string[10];//este los nombres de los productos
            DateTime[] fecha = new DateTime[10];//este guarda las fechas

            int i = 0, j = 0, x;//estas solo sirven de acumulador y se ocupan en los for
            int centinela, c;//variable centinela, y c la utilizaremos mas abajo

            int seleccion, seleccion2, seleccion3, contador;//las selecciones, sirven para los 3 switch case que tenemos
            int codigo_agregar, cantidad;//estas variable son las que van cambiando con los precios de los productos
            double precio_agregar, sub_total, iva, total, aux, aux2;//estas lo mismo, el precio es de tipo double, porque podria ser $30.50
            string nombre_cliente, nombre_producto, apellido_cliente, fecha_ingresada;//estos guardan nombres por esoson de tipo string

            bool bandera = true;//esta una bandera de tipo booleano
            DateTime fecha_modificacion;//este tipo de datos guarda fechas


            while (bandera == true)//aqui ocupamos un while para poder ejecutar el menu
            {
                Console.WriteLine("Seleccione una opcion: ");
                Console.WriteLine("1) Facturar una Venta");
                Console.WriteLine("2) Modificar Facturas Existentes");
                Console.WriteLine("3) Mostrar el Registro de las Facturas");
                Console.WriteLine("4) Salir");
                Console.Write("=================> ");
                seleccion = int.Parse(Console.ReadLine());
                //Console.WriteLine("\n");
                //Console.WriteLine(" ");

                switch (seleccion)
                {//este switch es el que funciona como menu
                    case 1://en el caso 1 hacemos una factura, e ingresamos todos los datos

                        Console.WriteLine("Ingrese el tipo de cliente: \n");
                        Console.WriteLine("1) Credito Fiscal ");
                        Console.WriteLine("2) Solo Consumidor Final\n");
                        Console.Write("=================> ");
                        seleccion2 = int.Parse(Console.ReadLine());//un switch case anidado, esto para saber si el cliente es credito fiscal
                        while (seleccion2 < 1 || seleccion2 > 2)
                        {
                            Console.WriteLine("La opcion debe ser 1 o 2, no puede ingresar otro valor \n ");
                            Console.WriteLine("Ingrese el tipo de cliente: \n");
                            Console.WriteLine("1) Credito Fiscal ");
                            Console.WriteLine("2) Consumidor Final\n");
                            Console.Write("=================> ");
                            seleccion2 = int.Parse(Console.ReadLine());//un switch case anidado, esto para saber si el cliente es credito fiscal
                            
                        }
                        Console.WriteLine("\n");

                        //***********************************************************************//
                        Console.WriteLine("\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\// \n");
                        Console.Write("Ingrese el codigo de la factura, por favor => ");
                        codigo_agregar = int.Parse(Console.ReadLine());
                        while (codigo_agregar <= 0)
                        {
                            Console.WriteLine("El codigo de la factura, no puede ser negativo o 0 \n");
                            Console.Write("Ingrese el codigo de la factura, por favor => ");
                            codigo_agregar = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("\n");
                        contador = 0;

                        for (x = 0; x <= 9; x++)//
                        {
                            if (codigo_agregar == codigo[x])//
                            {
                                contador++;
                                break;
                            }
                        }

                        //Console.WriteLine(contador);
                        if (contador < 1)//
                        {
                            if (seleccion2 == 1)//en este caso el si es 1, tiene credito fiscal
                            {
                                fecha[i] = DateTime.Now;//esto agrega al array(vector) fecha la fecha del momento al que se factura automaticamente
                                codigo[i] = codigo_agregar;//esto agrega el codigo de la factura al array codigo, i vale 0 por lo cual se agregara a la posicion 0 del array
                                clientes_credito_fiscal[i] = codigo_agregar;//y como tiene credito fiscal agregamos el codigo de su factura, al arrray credito fiscal

                                Console.Write("Ingrese el Nombre del Cliente, Por Favor => ");
                                nombre_cliente = Console.ReadLine();
                                nombres_clientes[i] = nombre_cliente;//esto agrega el nombre del cliente al array nombre de los clientes
                                Console.WriteLine("\n");


                                Console.Write("Ingrese el Apellido del Cliente, Por Favor => ");
                                apellido_cliente = Console.ReadLine();
                                apellidos[i] = apellido_cliente;//este agrega el apellido al array apellidos de los clientes
                                Console.WriteLine("\n");

                                Console.Write("Ingrese el nombre del producto, Por Favor => ");
                                nombre_producto = Console.ReadLine();
                                nombre_productos[i] = nombre_producto;//este agrega el nombre del producto al array apellidos 
                                Console.WriteLine("\n");

                                Console.Write("Ingrese la cantidad del producto, Por Favor => ");
                                cantidad = int.Parse(Console.ReadLine());
                                while (cantidad <= 0)
                                {
                                    Console.WriteLine("\t***************************");
                                    Console.WriteLine("la cantidad del producto no puede ser negativa \n ");
                                    Console.Write("Ingrese la cantidad nuevamente: \n");
                                    cantidad = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\t***************************");
                                }
                                cantidad_productos[i] = cantidad;//este agrega la cantidad del producto al array cantidad_productos 
                                Console.WriteLine("\n");

                                Console.Write("Ingrese el precio del producto C/U, Por Favor($) => ");
                                precio_agregar = double.Parse(Console.ReadLine());
                                aux = precio_agregar;
                                while (precio_agregar <= 0)
                                {
                                    Console.WriteLine("\t***************************");
                                    Console.WriteLine("El precio del producto no puede ser negativo \n ");
                                    Console.Write("Ingrese el precio del producto nuevamente($): \n");
                                    precio_agregar = double.Parse(Console.ReadLine());
                                    Console.WriteLine("\t***************************");

                                }
                                precios[i] = Math.Round((precio_agregar/1.13),2);//este agrega el precio del producto al array de precios
                                Console.WriteLine("\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\// \n");
                                Console.WriteLine("\n");

                                sub_total = ((precio_agregar/1.13) * cantidad);//el subtotal es (precio*cantidad), 
                                sub_totales[i] = Math.Round(sub_total,2);//y lo agrega al array subtotales

                                total = (aux*cantidad);//y como no hay impuestos, el total es el subtotal
                                totales_pagar[i] = total;//lo mismo se agrega al array

                                iva = (total-sub_total);//en este caso se calcula el iva
                                ivas[i] = Math.Round(iva,2);//y se agrega al array

                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "COMPRE AHORA PAGE DESPUES S.A DE C.V"));
                                Console.WriteLine("\n");
                                Console.WriteLine("GIRO: ALMACEN");
                                Console.WriteLine("1A Calle Oriente #15 BARRIO SANTA TERESA ");
                                Console.WriteLine("IVA DL. NO. ###");
                                Console.WriteLine("**PRECIOS EN USD** \n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Codigo de la Factura: " + codigo[i]));
                                Console.WriteLine("Cliente: " + nombres_clientes[i] + " " + apellidos[i] + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Nombre: " + "\t Cantidad: " + "\t C/U($):" + " \t Subtotal($)" + " \n");
                                Console.WriteLine(nombre_productos[i] + " \t " + cantidad_productos[i] + " \t " + " \t " + (precios[i]) + " \t " + " \t " + (sub_totales[i]) + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "SUBTOTALES($): " + (sub_totales[i])));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "IVA($): " + ivas[i]));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " TOTAL($) 'A PAGAR': " + totales_pagar[i] + "\n"));
                                Console.WriteLine("\t Gracias por comprar con nosotros \n");
                                Console.WriteLine("\t Hora y Fecha: " + fecha[i] + " \n");
                                Console.WriteLine("");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                            }
                            else if (seleccion2 == 2)//esto se ejecuta si no tiene credito fiscal
                            {
                                fecha[i] = DateTime.Now;//esto agrega al array(vector) fecha la fecha del momento al que se factura automaticamente
                                codigo[i] = codigo_agregar;//esto agrega el codigo de la factura al array codigo, i vale 0 por lo cual se agregara a la posicion 0 del array



                                Console.Write("Ingrese el Nombre del Cliente, Por Favor => ");
                                nombre_cliente = Console.ReadLine();
                                nombres_clientes[i] = nombre_cliente;//esto agrega el nombre del cliente al array nombre de los clientes
                                Console.WriteLine("\n");


                                Console.Write("Ingrese el Apellido del Cliente, Por Favor => ");
                                apellido_cliente = Console.ReadLine();
                                apellidos[i] = apellido_cliente;//este agrega el apellido al array apellidos de los clientes
                                Console.WriteLine("\n");

                                Console.Write("Ingrese el nombre del producto, Por Favor => ");
                                nombre_producto = Console.ReadLine();
                                nombre_productos[i] = nombre_producto;//este agrega el nombre del producto al array apellidos 
                                Console.WriteLine("\n");

                                Console.Write("Ingrese la cantidad del producto, Por Favor => ");
                                cantidad = int.Parse(Console.ReadLine());
                                while (cantidad <= 0)
                                {
                                    Console.WriteLine("\t***************************");
                                    Console.WriteLine("la cantidad del producto no puede ser negativa \n ");
                                    Console.Write("Ingrese la cantidad nuevamente: \n");
                                    cantidad = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\t***************************");
                                }
                                cantidad_productos[i] = cantidad;//este agrega la cantidad del producto al array cantidad_productos 
                                Console.WriteLine("\n");

                                Console.Write("Ingrese el precio del producto C/U, Por Favor($) => ");
                                precio_agregar = double.Parse(Console.ReadLine());
                                while (precio_agregar <= 0)
                                {
                                    Console.WriteLine("\t***************************");
                                    Console.WriteLine("El precio del producto no puede ser negativo \n ");
                                    Console.Write("Ingrese el precio del producto nuevamente($): \n");
                                    precio_agregar = double.Parse(Console.ReadLine());
                                    Console.WriteLine("\t***************************");

                                }
                                precios[i] = precio_agregar;//este agrega el precio del producto al array de precios
                                Console.WriteLine("\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\// \n");
                                Console.WriteLine("\n");

                                sub_total = (precio_agregar * cantidad);//el subtotal es (precio*cantidad), 
                                sub_totales[i] = sub_total;//y lo agrega al array subtotales

                                ivas[i] = 0;//el iva vale 0, ya que ya va implicito en cada compra

                                total = (sub_total);//en este caso al no tener credito fiscal, el total es igual al subtotal
                                totales_pagar[i] = total;//y se agrega al array, recordemos que "i" guarda la posicion que toma en el array
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "COMPRE AHORA PAGE DESPUES S.A DE C.V"));
                                Console.WriteLine("\n");
                                Console.WriteLine("GIRO: ALMACEN");
                                Console.WriteLine("1A Calle Oriente #15 BARRIO SANTA TERESA ");
                                Console.WriteLine("IVA DL. NO. ###");
                                Console.WriteLine("**PRECIOS EN USD** \n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Codigo de la Factura: " + codigo[i]));
                                Console.WriteLine("Cliente: " + nombres_clientes[i] + " " + apellidos[i] + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Nombre: " + "\t Cantidad: " + "\t C/U($):" + " \t Subtotal($)" + " \n");
                                Console.WriteLine(nombre_productos[i] + " \t " + cantidad_productos[i] + " \t " + " \t " + (precios[i]) + " \t " + " \t " + (sub_totales[i]) + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "SUBTOTALES($): " + (sub_totales[i])));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " TOTAL($) 'A PAGAR': " + totales_pagar[i] + "\n"));
                                Console.WriteLine("\t Gracias por comprar con nosotros \n");
                                Console.WriteLine("\t Hora y Fecha: " + fecha[i] + " \n");
                                Console.WriteLine("");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));


                            }
                            
                            //Console.WriteLine("#############################\n");
                            i++;//esta variable es el acumuluador de quien dependen los arrays, el acumulador aumenta despues de agregar un articulo, por lo cual en la siguiente iteracion, se guardara en la posicion i+1 en los arrays 
                        }
                        else//ESTO SE EJECUTA SI HAY DOS CODIGOS DE VENTA IGUALES
                        {
                            Console.WriteLine("El codigo de la factura que ha ingresado ya existe, por favor intente de nuevo");
                            Console.WriteLine("\n");
                            Console.WriteLine("#############################\n");
                        }
                        break;
                    case 2://EDITAR UNA FACTURA
                        Console.Write("\nIngrese el codigo de la Factura=> ");
                        c = int.Parse(Console.ReadLine());//introduciomos el codigo de la factura que queremos editar
                        Console.WriteLine("\n");
                        centinela = -1;//centinela vale -1

                        for (x = 0; x <= 9; x++)//este for recorre el array codigo
                        {
                            if (c == codigo[x])//"c" es el codigo que ingresamos, el cual queremos editar, si el codigo se encuentra en el array
                            {
                                centinela = x;//la variable centinela toma el valor de x, que es la posicion en el array del codigo y rompemos el ciclo
                                break;
                            }
                        }
                        Console.Clear();
                        if (centinela < 0)//si la centinela vale -1, es decir se recorrio el for, y nunca se cumplio el if, la factura no existe
                        {
                            Console.WriteLine("La factura no existe, por favor intente de nuevo");
                            Console.WriteLine("\n");
                            Console.WriteLine("#############################\n");
                        }
                        else//si la centinela es mayor o igual a 0 es porque si existe, y centinela tiene el valor de la pocision en los arrays
                        {
                            //Console.WriteLine("Fsg");
                            Console.WriteLine("Ingrese el dato que desea modificar: \n");
                            Console.WriteLine("1) Fecha");
                            Console.WriteLine("2) Nombre del Cliente");
                            Console.WriteLine("3) Apellido del Cliente");
                            Console.WriteLine("4) Nombre del Producto");
                            Console.WriteLine("5) Cantidad del Producto");
                            Console.WriteLine("6) Precio del Producto($)\n");
                            Console.Write("=========================> ");
                            seleccion3 = int.Parse(Console.ReadLine());//este sirve para el switch case
                            Console.WriteLine("\n");
                            switch (seleccion3)
                            {//este switch case es el menu para que dato de la factura se quiere editar
                                case 1://fecha
                                    Console.WriteLine("Ha Seleccionado hacer Cambio en la Fecha: \n");
                                    Console.WriteLine("Su antigua fecha es: " + fecha[centinela] + " \n");
                                    Console.Write("Por favor ingrese la nueva fecha, en este formato dd/mm/yyyy || hh:mm:ss=> ");
                                    fecha_ingresada = Console.ReadLine();//leemos la nueva fecha ingresada en formato string
                                    fecha_modificacion = DateTime.Parse(fecha_ingresada);//con esto lo convertimos a un dato tipo fecha
                                    fecha[centinela] = fecha_modificacion;//y se agrega al array
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su Nueva fecha es: " + fecha[centinela] + " \n");
                                    break;
                                case 2://nombre
                                    Console.WriteLine("Ha Seleccionado hacer Cambio de Nombre del Cliente: \n");
                                    Console.WriteLine("Su antiguo Nombre es: " + nombres_clientes[centinela] + " \n");
                                    Console.Write("Por favor ingrese el nuevo nombre del Cliente => ");
                                    nombre_cliente = Console.ReadLine();//leemos el nuevo nombre del cliente
                                    nombres_clientes[centinela] = nombre_cliente;//y lo agregamos al array
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su Nuevo Nombre es: " + nombres_clientes[centinela] + " \n");
                                    break;
                                case 3://apellido
                                    Console.WriteLine("Ha Seleccionado hacer Cambio de Apellido del Cliente: \n");
                                    Console.WriteLine("Su antiguo apellido es: " + apellidos[centinela] + " \n");
                                    Console.Write("Por favor ingrese el nuevo nombre del Cliente => ");
                                    apellido_cliente = Console.ReadLine();//leemos el nuevo nombre del cliente
                                    apellidos[centinela] = apellido_cliente;//lo agregamos al array
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su Nuevo Apellido es: " + apellidos[centinela] + " \n");
                                    break;// recordemos que centinela tiene el valor de la posicion en el array que modificaremos
                                case 4://nombre
                                    Console.WriteLine("Ha Seleccionado hacer Cambio de Nombre del Producto: \n");
                                    Console.WriteLine("Su antiguo Nombre de Producto es: " + nombre_productos[centinela] + " \n");
                                    Console.Write("Por favor ingrese el Nuevo Nombre del Producto => ");
                                    nombre_producto = Console.ReadLine();//leemos el nuevo apellido del cliente
                                    nombre_productos[centinela] = nombre_producto;//lo agregamos al array
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su nuevo nombre de Producto es: " + nombre_productos[centinela] + " \n");
                                    break;
                                case 5://cantidad
                                    Console.WriteLine("Ha Seleccionado hacer Cambio en Cantidad del Producto: \n");
                                    Console.WriteLine("Su antigua Cantidad de Producto es: " + cantidad_productos[centinela] + " \n");
                                    Console.Write("Por favor ingrese la nueva Cantidad del Producto => ");
                                    cantidad = int.Parse(Console.ReadLine());//leemos la nueva cantidad del producto
                                    while (cantidad <= 0)
                                    {
                                        Console.WriteLine("\t***************************");
                                        Console.WriteLine("la cantidad del producto no puede ser negativa \n ");
                                        Console.Write("Ingrese la cantidad nuevamente: \n");
                                        cantidad = int.Parse(Console.ReadLine());
                                        Console.WriteLine("\t***************************");
                                    }
                                    cantidad_productos[centinela] = cantidad;
                                    //cantidad_productos[centinela] = cantidad;//lo agregamos all array
                                    if (codigo[centinela] == clientes_credito_fiscal[centinela])
                                    {
                                        aux = precios[centinela];

                                        //aqui cantidad producto centinela ya lleva los cambios, por cual ya podemos utilizarla para realizar cambios
                                        sub_total = ((aux) *cantidad);//se recalculan los subtotales, ya que al modificar el precio o la cantidad el subtotal y el total se recalculara
                                        sub_totales[centinela] = Math.Round(sub_total, 2);//se agrega al array subtotal

                                        total = ((aux+(aux*0.13))*cantidad);//se recalcula el total 
                                        totales_pagar[centinela] = Math.Round(total,2);//se agrega al array

                                        ivas[centinela] = Math.Round((total - sub_total),2);//se recalcula el iva, ya que al ser credito fical el iva se tiene que imprimir
                                    }
                                    else
                                    {
                                        aux = precios[centinela];

                                        sub_total = ((aux) * cantidad);
                                        sub_totales[centinela] = Math.Round(sub_total,2);

                                        totales_pagar[centinela] = sub_total;
                                    }
                                    
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su nueva cantidad de Producto es: " + cantidad_productos[centinela] + " \n");
                                    break;

                                case 6://precio
                                    Console.WriteLine("Ha Seleccionado hacer Cambio en Precio del Producto: \n");
                                    Console.WriteLine("Su antiguo Precio del Producto es ($): " + precios[centinela] + " \n");
                                    Console.Write("Por favor ingrese el nuevo Precio  del Producto($) => ");
                                    precio_agregar = double.Parse(Console.ReadLine());//leemos el nuevo precio a pagar
                                    while (precio_agregar <= 0)
                                    {
                                        Console.WriteLine("\t***************************");
                                        Console.WriteLine("El precio del producto no puede ser negativo \n ");
                                        Console.Write("Ingrese el precio del producto nuevamente($): \n");
                                        precio_agregar = double.Parse(Console.ReadLine());
                                        Console.WriteLine("\t***************************");

                                    }
                                    //precios[centinela] = precio_agregar;//Lo agregamos al array
                                    if (codigo[centinela] == clientes_credito_fiscal[centinela])
                                    {
                                        precios[centinela] = Math.Round((precio_agregar / 1.13), 2);
                                        aux = precios[centinela];

                                        //aqui cantidad producto centinela ya lleva los cambios, por cual ya podemos utilizarla para realizar cambios
                                        sub_total = (aux*cantidad_productos[centinela]);//se recalculan los subtotales, ya que al modificar el precio o la cantidad el subtotal y el total se recalculara
                                        sub_totales[centinela] = Math.Round(sub_total, 2);//se agrega al array subtotal

                                        total = ((aux + (aux * 0.13)) * cantidad_productos[centinela]);//se recalcula el total 
                                        totales_pagar[centinela] = Math.Round(total, 2);//se agrega al array

                                        ivas[centinela] = Math.Round((total - sub_total), 2);//se recalcula el iva, ya que al ser credito fical el iva se tiene que imprimir
                                    }
                                    else
                                    {
                                        precios[centinela] = precio_agregar;
                                        aux = precios[centinela];

                                        sub_total = ((aux) * cantidad_productos[centinela]);
                                        sub_totales[centinela] = Math.Round(sub_total, 2);

                                        totales_pagar[centinela] = sub_total;
                                    }
                                    Console.WriteLine("\n !Cambio realizado con exito! \n");
                                    Console.WriteLine("Su nuevo precio de Producto es ($): " + precios[centinela] + " \n");
                                    break;
                                
                                default:
                                    Console.WriteLine("Ingreso una opcion no valida");
                                    break;
                            }

                        }

                        break;

                    case 3://Cuando se busca una factura por medio del codigp
                        //************************************//
                        Console.Write("\nIngrese el codigo de la factura=> ");
                        c = int.Parse(Console.ReadLine());//c es el codigo del la factura que queremos buscar
                        Console.WriteLine("\n");
                        centinela = -1;//la centinela vale -1 lo cual no representa ninguna posicion dentro del array

                        for (x = 0; x <= 9; x++)//un for de x=0 a x-1 del array en este caso como el array es de 10, el for va hasta el 9
                        {
                            if (c == codigo[x])//codigo[x] recorre todo el array y lo compara con "c", si es verdad centinela toma la posicion en que esta el valor que queremos
                            {
                                centinela = x;//recordemos que todos los datos correspondientes a una factura comparten una posicion equivalente en los distintos arrays 
                                break;//rompemos
                            }
                        }
                        if (centinela < 0)//si el if dentro del for nunca se cumplio centinela saldra con el valor de -1 por lo cual el codigo de la factura
                        {//                 no existe
                            Console.WriteLine("!Esa factura no existe en el registro!");
                            Console.WriteLine("\n");
                            Console.WriteLine("Por Favor intente de nuevo");
                            Console.WriteLine("#############################\n");
                        }
                            
                        else//si la centinela vale >=0, ese el valor de la posicion en los arrays
                        {//aqui hay que imprimir en forma de factura!
                            if (clientes_credito_fiscal[centinela] > 0)
                            {
                                
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "COMPRE AHORA PAGE DESPUES S.A DE C.V"));
                                Console.WriteLine("\n");
                                Console.WriteLine("GIRO: ALMACEN");
                                Console.WriteLine("1A Calle Oriente #15 BARRIO SANTA TERESA ");
                                Console.WriteLine("IVA DL. NO. ###");
                                Console.WriteLine("**PRECIOS EN USD** \n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Tipo de Cliente: Credito Fiscal");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Codigo de la Factura: " + codigo[centinela]));
                                Console.WriteLine("Cliente: " + nombres_clientes[centinela] + " " + apellidos[centinela] + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Nombre: " + "\t Cantidad: " + "\t C/U($):" + " \t Subtotal($)" + " \n");
                                Console.WriteLine(nombre_productos[centinela] + " \t " + cantidad_productos[centinela] + " \t " + " \t " + (precios[centinela]) + " \t " + " \t " + (sub_totales[centinela]) + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "SUBTOTALES($): " + (sub_totales[centinela])));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "IVA($): " + ivas[centinela]));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " TOTAL($) 'A PAGAR': " + totales_pagar[centinela] + "\n"));
                                Console.WriteLine("\t Gracias por comprar con nosotros \n");
                                Console.WriteLine("\t Hora y Fecha: " + fecha[centinela] + " \n");
                                Console.WriteLine("");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                            }
                            else
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "COMPRE AHORA PAGE DESPUES S.A DE C.V"));
                                Console.WriteLine("\n");
                                Console.WriteLine("GIRO: ALMACEN");
                                Console.WriteLine("1A Calle Oriente #15 BARRIO SANTA TERESA ");
                                Console.WriteLine("IVA DL. NO. ###");
                                Console.WriteLine("**PRECIOS EN USD** \n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Tipo de Cliente: Consumidor Final");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Codigo de la Factura: " + codigo[centinela]));
                                Console.WriteLine("Cliente: " + nombres_clientes[centinela] + " " + apellidos[centinela] + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("Nombre: " + "\t Cantidad: " + "\t C/U($):" + " \t Subtotal($)" + " \n");
                                Console.WriteLine(nombre_productos[centinela] + " \t " + cantidad_productos[centinela] + " \t " + " \t " + (precios[centinela]) + " \t " + " \t " + (sub_totales[centinela]) + "\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "SUBTOTALES($): " + sub_totales[centinela]));
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " TOTAL($) 'A PAGAR': " + totales_pagar[centinela] + "\n"));
                                Console.WriteLine("\t Gracias por comprar con nosotros \n");
                                Console.WriteLine("\t Hora y Fecha: " + fecha[centinela] + " \n");
                                Console.WriteLine("");
                                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "###########################################################################################################"));
                            }

                        }
                        break;
                    case 4://si en el menu se selecciona 4 saldremos de la aplicacion
                        Console.WriteLine("Adios");
                        bandera = false;//hacemos la bandera false por lo cual terminara el while
                        break;

                    default:
                        Console.WriteLine("\n!Ingreso una opcion no valida!");
                        Console.WriteLine("Intente de Nuevo\n");
                        break;
                }
            }
            Console.ReadLine();
        }

    }
}




