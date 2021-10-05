using Microsoft.EntityFrameworkCore;
using P1_AP1_LUIS_20170581.Dal;
using P1_AP1_LUIS_20170581.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_LUIS_20170581.Bll
{
    public class AportesBll 
    {
        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="rol">La entidad que se desea guardar</param>
        public static bool Guardar(Aportes rol)
        {
            if (!Existe(rol.AporteId))
            {
                return Insertar(rol);
            }
            else
            {
                return Modificar(rol);
            }
        }
        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="rol">La entidad que se desea modificar</param> 

        private static bool Modificar(Aportes rol)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(rol).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="rol">La entidad que se desea guardar</param>
        private static bool Insertar(Aportes rol)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aportes.Add(rol);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        /// <summary>
        /// Permite eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="aporteid">El Id de la entidad que se desea eliminar</param>
        public static bool Eliminar(int aporteid)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var rol = contexto.Aportes.Find(aporteid);

                if (rol != null)
                {
                    contexto.Aportes.Remove(rol);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Existe(int aporteId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.AporteId == aporteId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="aporteid">El Id de la entidad que se desea buscar</param>
        public static Aportes Buscar(int aporteid)
        {
            Contexto contexto = new Contexto();
            Aportes rol;

            try
            {
                rol = contexto.Aportes.Find(aporteid);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return rol;
        }
        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool ExisteConcepto(string Concepto)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.Concepto == Concepto);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Aportes> GetAportes()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
