using Aula02.App;
using System;
using System.Web.Http;

namespace Aula02.Api
{
    [RoutePrefix("api/produto")]
    public class ProdutoController: ApiController
    {
        public ProdutoApp _app;

        public ProdutoController()
        {
            _app = new ProdutoApp();
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var ret = _app.GetAll();
                return Ok(ret);

            }
            catch (Exception ex)
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

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}