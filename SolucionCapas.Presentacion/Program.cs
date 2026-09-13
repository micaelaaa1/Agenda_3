using System;
using Agenda3.Entidades;
using SolucionCapas.Negocio;

namespace SolucionCapas.Presentacion
{
    class Program
    {
        static ContactoNegocio negocio =
            new ContactoNegocio();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== AGENDA 3 =====");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Buscar contacto");
                Console.WriteLine("3. Modificar contacto");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                int.TryParse(
                    Console.ReadLine(),
                    out opcion);

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Agregar();
                        break;

                    case 2:
                        Buscar();
                        break;

                    case 3:
                        Modificar();
                        break;

                    case 4:
                        Eliminar();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }


        static void Agregar()
        {
            Contacto contacto = CargarContacto();

            Console.WriteLine();
            Console.WriteLine("¿Desea agregar una Cuenta Corriente?");
            Console.Write("S/N: ");

            string respuesta =
                Console.ReadLine().ToUpper();

            if (respuesta == "S")
            {
                contacto.CuentaCte =
                    CargarCuentaCorriente(contacto.DNI);
            }

            bool resultado =
                negocio.Agregar(contacto);

            if (resultado)
                Console.WriteLine("Contacto agregado correctamente.");
            else
                Console.WriteLine("No se pudo agregar el contacto.");
        }


        static void Buscar()
        {
            Console.Write("Ingrese DNI: ");
            string dni = Console.ReadLine();

            Contacto contacto =
                negocio.BuscarPorDni(dni);

            if (contacto == null)
            {
                Console.WriteLine("No existe el contacto.");
                return;
            }

            MostrarContacto(contacto);
        }


        static void Modificar()
        {
            Console.Write("Ingrese DNI del contacto a modificar: ");
            string dni = Console.ReadLine();

            Contacto contacto =
                negocio.BuscarPorDni(dni);

            if (contacto == null)
            {
                Console.WriteLine("No existe el contacto.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Datos actuales:");
            MostrarContacto(contacto);

            Console.WriteLine();
            Console.WriteLine("Ingrese los nuevos datos.");

            Contacto nuevoContacto =
                CargarContacto();

            nuevoContacto.DNI = dni;

            if (contacto.CuentaCte != null)
            {
                nuevoContacto.CuentaCte =
                    CargarCuentaCorriente(dni);
            }

            bool resultado =
                negocio.Modificar(nuevoContacto);

            if (resultado)
                Console.WriteLine(
                    "Contacto modificado correctamente.");
            else
                Console.WriteLine(
                    "No se pudo modificar el contacto.");
        }


        static void Eliminar()
        {
            Console.Write("Ingrese DNI a eliminar: ");
            string dni = Console.ReadLine();

            bool resultado =
                negocio.Eliminar(dni);

            if (resultado)
                Console.WriteLine(
                    "Contacto eliminado correctamente.");
            else
                Console.WriteLine(
                    "No se pudo eliminar el contacto.");
        }


        static Contacto CargarContacto()
        {
            Contacto contacto = new Contacto();

            Console.Write("DNI: ");
            contacto.DNI = Console.ReadLine();

            Console.Write("Apellido: ");
            contacto.Apellido = Console.ReadLine();

            Console.Write("Nombres: ");
            contacto.Nombres = Console.ReadLine();

            Console.Write("Calle: ");
            contacto.Calle = Console.ReadLine();

            Console.Write("Departamento: ");
            contacto.Depto = Console.ReadLine();

            Console.Write("Piso: ");
            contacto.Piso = Console.ReadLine();

            Console.Write("Ciudad: ");
            contacto.Ciudad = Console.ReadLine();

            Console.Write("Teléfono: ");
            contacto.Telefono = Console.ReadLine();

            Console.Write("Email: ");
            contacto.Email = Console.ReadLine();

            Console.Write("CUIL/CUIT: ");
            contacto.CUIL_CUIT = Console.ReadLine();

            Console.Write("Fecha de alta (AAAA-MM-DD): ");

            DateTime fecha;

            DateTime.TryParse(
                Console.ReadLine(),
                out fecha);

            contacto.FechaAlta = fecha;

            Console.Write("Estado civil: ");
            contacto.EstadoCivil = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            contacto.Nacionalidad = Console.ReadLine();

            Console.Write("Provincia: ");
            contacto.Provincia = Console.ReadLine();

            Console.Write("Código postal: ");
            contacto.CodigoPostal = Console.ReadLine();

            Console.Write("Barrio: ");
            contacto.Barrio = Console.ReadLine();

            Console.Write("Teléfono alternativo: ");
            contacto.TelefonoAlternativo =
                Console.ReadLine();

            Console.Write("Instagram: ");
            contacto.Instagram = Console.ReadLine();

            Console.Write("Profesión/Ocupación: ");
            contacto.ProfesionOcupacion =
                Console.ReadLine();

            Console.Write("Empresa/Lugar de trabajo: ");
            contacto.EmpresaLugarTrabajo =
                Console.ReadLine();

            Console.Write("Nivel de estudios: ");
            contacto.NivelEstudios =
                Console.ReadLine();

            Console.Write("Estado: ");
            contacto.Estado = Console.ReadLine();

            Console.Write("Método de pago preferido: ");
            contacto.MetodoPagoPreferido =
                Console.ReadLine();

            Console.Write("Observaciones: ");
            contacto.Observaciones =
                Console.ReadLine();

            return contacto;
        }


        static CuentaCte CargarCuentaCorriente(
            string dni)
        {
            CuentaCte cuenta = new CuentaCte();

            cuenta.PersonaId = dni;

            Console.Write(
                "Fecha de apertura (AAAA-MM-DD): ");

            DateTime fecha;

            DateTime.TryParse(
                Console.ReadLine(),
                out fecha);

            cuenta.FechaApertura = fecha;

            Console.Write("Límite de crédito: ");

            decimal limite;

            decimal.TryParse(
                Console.ReadLine(),
                out limite);

            cuenta.LimiteCredito = limite;

            Console.Write(
                "Estado del crédito (Activo/Suspendido): ");

            cuenta.EstadoCredito =
                Console.ReadLine();

            return cuenta;
        }


        static void MostrarContacto(Contacto contacto)
        {
            Console.WriteLine("===== CONTACTO =====");

            Console.WriteLine(
                $"DNI: {contacto.DNI}");

            Console.WriteLine(
                $"Apellido: {contacto.Apellido}");

            Console.WriteLine(
                $"Nombres: {contacto.Nombres}");

            Console.WriteLine(
                $"Calle: {contacto.Calle}");

            Console.WriteLine(
                $"Depto: {contacto.Depto}");

            Console.WriteLine(
                $"Piso: {contacto.Piso}");

            Console.WriteLine(
                $"Ciudad: {contacto.Ciudad}");

            Console.WriteLine(
                $"Teléfono: {contacto.Telefono}");

            Console.WriteLine(
                $"Email: {contacto.Email}");

            Console.WriteLine(
                $"CUIL/CUIT: {contacto.CUIL_CUIT}");

            Console.WriteLine(
                $"Fecha de alta: {contacto.FechaAlta:dd/MM/yyyy}");

            Console.WriteLine(
                $"Estado civil: {contacto.EstadoCivil}");

            Console.WriteLine(
                $"Nacionalidad: {contacto.Nacionalidad}");

            Console.WriteLine(
                $"Provincia: {contacto.Provincia}");

            Console.WriteLine(
                $"Código postal: {contacto.CodigoPostal}");

            Console.WriteLine(
                $"Barrio: {contacto.Barrio}");

            Console.WriteLine(
                $"Teléfono alternativo: {contacto.TelefonoAlternativo}");

            Console.WriteLine(
                $"Instagram: {contacto.Instagram}");

            Console.WriteLine(
                $"Profesión/Ocupación: {contacto.ProfesionOcupacion}");

            Console.WriteLine(
                $"Empresa/Lugar de trabajo: {contacto.EmpresaLugarTrabajo}");

            Console.WriteLine(
                $"Nivel de estudios: {contacto.NivelEstudios}");

            Console.WriteLine(
                $"Estado: {contacto.Estado}");

            Console.WriteLine(
                $"Método de pago: {contacto.MetodoPagoPreferido}");

            Console.WriteLine(
                $"Observaciones: {contacto.Observaciones}");

            if (contacto.CuentaCte != null)
            {
                Console.WriteLine();
                Console.WriteLine("===== CUENTA CORRIENTE =====");

                Console.WriteLine(
                    $"ID: {contacto.CuentaCte.Id}");

                Console.WriteLine(
                    $"Persona ID: {contacto.CuentaCte.PersonaId}");

                Console.WriteLine(
                    $"Fecha apertura: {contacto.CuentaCte.FechaApertura:dd/MM/yyyy}");

                Console.WriteLine(
                    $"Límite de crédito: {contacto.CuentaCte.LimiteCredito}");

                Console.WriteLine(
                    $"Estado crédito: {contacto.CuentaCte.EstadoCredito}");
            }
        }
    }
}