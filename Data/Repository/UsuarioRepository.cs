using Data.Context;
using Data.Models;
using Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : IRepository<UsuarioDto, int>
    {
        public bool Delete(int id)
        {

            using (WevoDbContext ctx = new WevoDbContext())
            {

                bool isDeleted = false;

                try
                {

                    var user = ctx.Usuarios.Find(id);

                    if (user != null)
                    {
                        ctx.Usuarios.Remove(user);

                        ctx.SaveChanges();

                        isDeleted = true;
                    }

                    return isDeleted;


                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro ao excluir o usuário. {0}.", ex.ToString()));
                }

            }
        }

        public List<UsuarioDto> GetAll()
        {
            using (WevoDbContext ctx = new WevoDbContext())
            {

                try
                {
                    var dto = from user in ctx.Usuarios
                              select new UsuarioDto()
                              {
                                  Id = user.Id,
                                  Nome = user.Nome,
                                  Cpf = user.Cpf,
                                  Email = user.Email,
                                  Sexo = user.Sexo,
                                  Telefone = user.Telefone,
                                  DataNascimento = user.DataNascimento
                              };

                    return dto.ToList();
                }
                catch (Exception ex)
                {

                    throw new Exception(string.Format("Erro ao obter todos os usuários. {0}.", ex.ToString()));
                }

            }
        }

        public UsuarioDto GetById(int id)
        {
            using (WevoDbContext ctx = new WevoDbContext())
            {
                try
                {

                    var dto = from user in ctx.Usuarios.Where(a => a.Id == id)
                              select new UsuarioDto()
                              {
                                  Id = user.Id,
                                  Nome = user.Nome,
                                  Cpf = user.Cpf,
                                  Email = user.Email,
                                  Sexo = user.Sexo,
                                  Telefone = user.Telefone,
                                  DataNascimento = user.DataNascimento
                              };

                    return dto.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro ao obter o usuário pelo Id: {0}. {1}.", id, ex.ToString()));
                }

            }
        }

        public int Save(UsuarioDto entity)
        {
            var user = new Data.Models.Usuario()
            {
                Nome = entity.Nome,
                Cpf = entity.Cpf,
                Email = entity.Email,
                Sexo = entity.Sexo,
                Telefone = entity.Telefone,
                DataNascimento = entity.DataNascimento
            };

            using (WevoDbContext ctx = new WevoDbContext())
            {

                try
                {
                    ctx.Usuarios.Add(user);
                    ctx.SaveChanges();

                    return user.Id;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro ao incluir o usuário. {0}.", ex.ToString()));
                }

            }
        }

        public void Update(UsuarioDto entity)
        {
            var user = new Data.Models.Usuario()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Cpf = entity.Cpf,
                Email = entity.Email,
                Sexo = entity.Sexo,
                Telefone = entity.Telefone,
                DataNascimento = entity.DataNascimento
            };

            using (WevoDbContext ctx = new WevoDbContext())
            {

                try
                {
                    ctx.Usuarios.Attach(user);
                    ctx.Entry(user).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro ao atualizar o usuário. {0}.", ex.ToString()));
                }

            }
        }





    }
}
