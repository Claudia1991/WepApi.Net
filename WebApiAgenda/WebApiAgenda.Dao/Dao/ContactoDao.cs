using System.Collections.Generic;
using WebApiAgenda.ViewModel.ViewModel;
using WebApiAgenda.DataModel.DataModel;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace WebApiAgenda.Dao.Dao
{
    public class ContactoDao : BaseDao , 
                               IDao<ContactoViewModel>
    {
        #region Public Methods
        public void Add(ContactoViewModel viewModel)
        {
            ContactoEntity contactoEntity = new ContactoEntity()
            {
                NombreContacto = viewModel.NombreContacto,
                ApellidoContacto = viewModel.ApellidoContacto,
                TelefonoContacto = viewModel.TelefonoContacto,
                MailContacto = viewModel.MailContacto
            };
            try
            {
                using (var context = new AgendaContext())
                {
                    context.Contactos.Add(new ContactoEntity()
                    {
                        NombreContacto = viewModel.NombreContacto,
                        ApellidoContacto = viewModel.ApellidoContacto,
                        TelefonoContacto = viewModel.TelefonoContacto,
                        MailContacto = viewModel.MailContacto
                    });
                    context.SaveChanges();
                }
                Log.Debug("Se agrego el contacto.");
            }
            catch (SqlException ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            bool isExistElement = false;
            ContactoEntity contactoEntity = new ContactoEntity()
            {
                IdContacto = id
            };
            try
            {
                using (var context = new AgendaContext())
                {
                    isExistElement = context.Contactos.ToList().Any(c=>c.IdContacto == contactoEntity.IdContacto);
                    if (isExistElement)
                    {
                        context.Entry(contactoEntity).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                        Log.Debug("Se elimino el contacto.");
                        isDeleted = !isDeleted;
                    }
                    else
                    {
                        Log.Debug("No existe el id del contacto a eliminar.");
                        Log.Error("No existe el id del contacto a eliminar.");
                        throw new Exception("Error en el id ingresado, no existe en la base de datos.");
                    }
                }

            }
            catch (SqlException ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            return isDeleted;
        }

        public bool Edit(ContactoViewModel viewModel)
        {
            bool isEdited = false;
            bool isExistElement = false;
            ContactoEntity contactoEntity = new ContactoEntity()
            {
                IdContacto = viewModel.Id,
                NombreContacto = viewModel.NombreContacto,
                ApellidoContacto = viewModel.ApellidoContacto,
                TelefonoContacto = viewModel.TelefonoContacto,
                MailContacto = viewModel.MailContacto
            };
            try
            {
                using (var context = new AgendaContext())
                {
                    isExistElement = context.Contactos.ToList().Any(c => c.IdContacto == contactoEntity.IdContacto);
                    if (isExistElement)
                    {
                        context.Entry(contactoEntity).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        Log.Debug("Se edito el contacto.");
                        isEdited = !isEdited;
                    }
                    else
                    {
                        Log.Debug("No existe el id del contacto a editar.");
                        Log.Error("No existe el id del contacto a editar.");
                        throw new Exception("Error en el id ingresado, no existe en la base de datos.");
                    }
                }

            }
            catch (SqlException ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            return isEdited;
        }

        public List<ContactoViewModel> GetAll()
        {
            List<ContactoViewModel> contactos = new List<ContactoViewModel>();
            try
            {
                using (var context = new AgendaContext())
                {
                    foreach(var contacto in context.Contactos.ToList())
                    {
                        contactos.Add(new ContactoViewModel()
                        {
                            Id = contacto.IdContacto,
                            NombreContacto = contacto.NombreContacto,
                            ApellidoContacto = contacto.ApellidoContacto,
                            TelefonoContacto = contacto.TelefonoContacto,
                            MailContacto = contacto.MailContacto
                        });
                    }
                }
                Log.Debug("Se devuelve la lista de contactos obtenida.");
            }
            catch (SqlException ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            return contactos;
        }

        public ContactoViewModel GetById(int id)
        {
            ContactoViewModel contacto = new ContactoViewModel();
            try
            {
                using (var context = new AgendaContext())
                {
                    ContactoEntity contactoEntity = context.Contactos.FirstOrDefault(c=> c.IdContacto == id);
                    if (contactoEntity != null)
                    {
                        contacto.Id = contactoEntity.IdContacto;
                        contacto.NombreContacto = contactoEntity.NombreContacto;
                        contacto.ApellidoContacto = contactoEntity.ApellidoContacto;
                        contacto.TelefonoContacto = contactoEntity.TelefonoContacto;
                        contacto.MailContacto = contactoEntity.MailContacto;
                    }
                    else
                    {
                        Log.Debug("No existe contacto con ese id.");
                        Log.Error("No existe contacto con ese id.");
                        throw new Exception("No existe contacto con ese id.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format("Error: {0}", ex.InnerException));
                Log.Error(string.Format("Error: {0}", ex.InnerException));
                throw ex;
            }
            return contacto;
        }
        #endregion
    }
}
