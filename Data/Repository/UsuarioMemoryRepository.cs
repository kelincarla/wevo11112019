
using Data.Models;
using Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioMemoryRepository : IRepository<UsuarioDto, int>
    {



        public bool Delete(int id)
        {

            try
            {
                var usuariosSingleton = UsuarioSingleton.Instance;
                var usuario = usuariosSingleton.Usuarios.Find(u => u.Id == id);

                if (usuario != null)
                {
                    usuariosSingleton.Usuarios.Remove(usuario);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao excluir o usuário em memória, pelo Id: {0}. {1}.", id, ex.ToString()));
            }


        }

        public List<UsuarioDto> GetAll()
        {
            try
            {
                var usuariosSingleton = UsuarioSingleton.Instance;
                var usuarios = (from users in usuariosSingleton.Usuarios
                                select new UsuarioDto
                                {
                                    Id = users.Id,
                                    Cpf = users.Cpf,
                                    DataNascimento = users.DataNascimento,
                                    Email = users.Email,
                                    Nome = users.Nome,
                                    Sexo = users.Sexo,
                                    Telefone = users.Telefone
                                }).ToList();

                return usuarios;


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao obter todos os usuários em memória. {0}.", ex.ToString()));
            }

        }

        public UsuarioDto GetById(int id)
        {
            try
            {
                var usuariosSingleton = UsuarioSingleton.Instance;
                var usuario = (from users in usuariosSingleton.Usuarios
                               where users.Id == id
                               select new UsuarioDto
                               {
                                   Id = users.Id,
                                   Cpf = users.Cpf,
                                   DataNascimento = users.DataNascimento,
                                   Email = users.Email,
                                   Nome = users.Nome,
                                   Sexo = users.Sexo,
                                   Telefone = users.Telefone
                               }).FirstOrDefault();

                return usuario;


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao obter o usuário em memória, pelo Id: {0}. {1}.", id, ex.ToString()));
            }



        }

        public int Save(UsuarioDto entity)
        {
            try
            {
                var usuariosSingleton = UsuarioSingleton.Instance;
                var usuarios = usuariosSingleton.Usuarios;
                int identity = usuarios.Count > 0 ? usuarios.Max(u => u.Id) : 0;
                identity += 1;

                usuariosSingleton.Usuarios.Add(new Usuario()
                {
                    Id = identity,
                    Cpf = entity.Cpf,
                    DataNascimento = entity.DataNascimento,
                    Email = entity.Email,
                    Nome = entity.Nome,
                    Sexo = entity.Sexo,
                    Telefone = entity.Telefone
                });

                return identity;

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao incluir o usuário em memória. {0}.", ex.ToString()));
            }

        }

        public void Update(UsuarioDto entity)
        {
            try
            {
                var usuariosSingleton = UsuarioSingleton.Instance;
                var usuario = usuariosSingleton.Usuarios.Find(u => u.Id == entity.Id);


                if (usuario != null)
                {
                    int index = usuariosSingleton.Usuarios.IndexOf(usuario);
                    usuariosSingleton.Usuarios[index].Nome = entity.Nome;
                    usuariosSingleton.Usuarios[index].Sexo = entity.Sexo;
                    usuariosSingleton.Usuarios[index].Telefone = entity.Telefone;
                    usuariosSingleton.Usuarios[index].Email = entity.Email;
                    usuariosSingleton.Usuarios[index].DataNascimento = entity.DataNascimento;
                    usuariosSingleton.Usuarios[index].Cpf = entity.Cpf;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro ao atualizar o usuário em memória. {0}.", ex.ToString()));
            }

        }
    }
}
