using Data;
using Data.Context;
using Data.Repository;
using Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Usuario
{
    public class UsuarioService
    {

        #region Usuários em base de dados
        public List<UsuarioDto> GetUsuarios()
        {

            try
            {
                return new UsuarioRepository().GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public UsuarioDto GetUsuarioId(int id)
        {

            try
            {
                return new UsuarioRepository().GetById(id);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public int SaveUsuario(UsuarioDto usuarioDto)
        {

            try
            {
                return new UsuarioRepository().Save(usuarioDto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                new UsuarioRepository().Update(usuarioDto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteUsuario(int id)
        {
            try
            {
                return new UsuarioRepository().Delete(id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region Usuários em memória
        public List<UsuarioDto> GetUsuariosMemoria()
        {

            try
            {
                return new UsuarioMemoryRepository().GetAll();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public UsuarioDto GetUsuarioIdMemoria(int id)
        {

            try
            {
                return new UsuarioMemoryRepository().GetById(id);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public int SaveUsuarioMemoria(UsuarioDto usuarioDto)
        {

            try
            {
                return new UsuarioMemoryRepository().Save(usuarioDto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateUsuarioMemoria(UsuarioDto usuarioDto)
        {
            try
            {
                new UsuarioMemoryRepository().Update(usuarioDto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteUsuarioMemoria(int id)
        {
            try
            {
                return new UsuarioMemoryRepository().Delete(id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion


    }
}
