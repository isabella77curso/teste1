using Aula02.App;
using System;
using System.Web.Http;
using System.Web.Routing;

namespace Aula02.Api
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        public ClienteApp _app;

        public ClienteController()
        {
            _app = new ClienteApp();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var ret = _app.GetAll();
                return Ok(ret);

            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("id")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var ret = _app.GetById(id);
                return Ok(ret);

            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("aniversariantes/{dia}/{mes}")]
        public IHttpActionResult GetAniversariantes(int dia, int mes)
        {
            try
            {
                var ret = _app.GetAniversariantes(dia, mes);
                return Ok(ret);

            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        

    }
}