using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiAgenda.Dao.Dao;
using WebApiAgenda.ViewModel.ViewModel;

namespace WebApiAgenda.Controllers
{
    [RoutePrefix("api/Contactos")]
    public class ContactoController : BaseApiController
    {
        #region Properties
        private readonly ContactoDao contactoDao;
        #endregion

        #region Constructor
        public ContactoController()
        {
            this.contactoDao = new ContactoDao();
        }
        #endregion

        #region Public Methods
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Log.Debug("Inicio - GET - Contactos");
            List<ContactoViewModel> contactos = new List<ContactoViewModel>();

            try
            {
                contactos = contactoDao.GetAll();

                if (contactos == null)
                {
                    Log.Error("No hay contactos disponibles.");
                    Log.Debug("No hay contactos disponibles.");
                    return BadRequest("No hay contactos disponibles");
                }
                else
                {
                    Log.Debug("Se devuelven los contactos obtenidos");
                    return Ok(contactos);
                }
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Error: {0}", exception.Message));
                Log.Debug(string.Format("Error: {0}", exception.Message));
                return InternalServerError(exception);
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Log.Debug("Inicio - GET - Contactos");
            if (!IsIdValid(id))
            {
                return BadRequest("Error en los datos ingresados. Id invalido");
            }
            ContactoViewModel contacto = null;

            try
            {
                contacto = contactoDao.GetById(id);

                if (contacto == null)
                {
                    Log.Error("No hay contactos disponibles.");
                    Log.Debug("No hay contactos disponibles.");
                    return BadRequest("No hay contactos disponibles");
                }
                else
                {
                    Log.Debug("Se devuelven los contactos obtenidos");
                    return Ok(contacto);
                }
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Error: {0}", exception.Message));
                Log.Debug(string.Format("Error: {0}", exception.Message));
                return InternalServerError(exception);
            }
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Post(ContactoViewModel viewModel)
        {
            Log.Debug("Inicio - POST - Contactos");

            if (IsNameInvalid(viewModel.NombreContacto) && (IsNameInvalid(viewModel.TelefonoContacto.ToString())))
            {
                Log.Error("Error: parametro vacio");
                Log.Debug("Error: parametro vacio");
                return BadRequest("Error en los datos ingresados.");
            }
            try
            {
                contactoDao.Add(viewModel);
                return Ok();
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Error: {0}", exception.Message));
                Log.Debug(string.Format("Error: {0}", exception.Message));
                return InternalServerError(exception);
            }
        }

        [Route("Edit")]
        [HttpPut]
        public IHttpActionResult Put(ContactoViewModel viewModel)
        {
            Log.Debug("Inicio - PUT - Contactos");

            if ((IsNameInvalid(viewModel.NombreContacto) || IsIdValid(viewModel.Id)))
            {
                Log.Debug("Error en los datos ingresados.");
                Log.Error("Error en los datos ingresados.");
                return BadRequest("Error en los datos ingresados.");
            }

            try
            {
                bool isEdited = contactoDao.Edit(viewModel);

                if (isEdited)
                {
                    Log.Debug("Se edito el contacto.");
                    return Ok();
                }
                else
                {
                    Log.Debug("No se edito el contacto.");
                    Log.Error("No se edito el contacto.");
                    return BadRequest("No se edito el contacto.");
                }
            }
            catch (Exception exception)
            { 
                Log.Debug(string.Format("Error: {0}", exception.Message));
                Log.Error(string.Format("Error: {0}", exception.Message));
                return InternalServerError(exception);
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Log.Debug("Inicio - DELETE - Contacto");

            if (!IsIdValid(id))
            {
                Log.Debug("Error en los datos ingresados.");
                Log.Error("Error en los datos ingresados.");
                return BadRequest("Error en los datos ingresados.");
            }

            try
            {
                bool isDeleted = contactoDao.Delete(id);

                if (isDeleted)
                {
                    Log.Debug("El contacto fue eliminado.");
                    return Ok();
                }
                else
                {
                    Log.Debug("El no contacto fue eliminado.");
                    Log.Error("El no contacto fue eliminado.");
                    return BadRequest("El no contacto fue eliminado.");
                }
            }
            catch (Exception exception)
            {
                Log.Debug(string.Format("Error: {0}", exception.Message));
                Log.Error(string.Format("Error: {0}", exception.Message));
                return InternalServerError(exception);
            }
        }
        #endregion

        #region Private Methods
        private bool IsIdValid(int id)
        {
            return id > 0;
        }

        private bool IsNameInvalid(string name)
        {
            return string.IsNullOrEmpty(name);
        }
        #endregion
    }
}